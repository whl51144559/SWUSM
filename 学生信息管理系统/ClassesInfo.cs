using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生信息管理系统
{
    public partial class ClassesInfo : Form
    {
        public ClassesInfo()
        {
            InitializeComponent();
        }
        private void ClassForm_Load(object sender, EventArgs e)
        {
            bindCollege();
            bindSpeciality();
        }

        #region 绑定学院、专业、班级
        #region 绑定学院名称
        void bindCollege()
        {
            string sql = "select * from Colleges";
            DataTable dt = DataBaseHelper.ExecDataTable(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode tn = new TreeNode(dt.Rows[i]["College_Name"].ToString());
                tn.Tag = dt.Rows[i]["College_ID"].ToString();

                tvClassInfo.Nodes.Add(tn);
            }
        }
        #endregion

        #region 绑定专业名称
        void bindSpeciality()
        {
            DataTable dt=null;
            foreach(TreeNode node in tvClassInfo.Nodes)
            {
                string sql="select * from Speciality where Speciality_College=@0";
                dt=DataBaseHelper.ExecDataTable(sql,node.Tag.ToString());
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    TreeNode tn=new TreeNode(dt.Rows[i]["Speciality_Name"].ToString());
                    tn.Tag=dt.Rows[i]["Speciality_ID"].ToString();
                    node.Nodes.Add(tn);
                    BindClass(tn);
                }
            }
        }
        #endregion

        #region 绑定班级名称
        void BindClass(TreeNode tn)
        {
            string sql="select Classes_ID,Classes_Name from Classes where Classes_Speciality=@0";
            DataTable dt=DataBaseHelper.ExecDataTable(sql,tn.Tag.ToString());
            for(int i=0;i<dt.Rows.Count;i++)
            {
                TreeNode stn=new TreeNode(dt.Rows[i]["Classes_Name"].ToString());
                stn.Tag=dt.Rows[i]["Classes_ID"].ToString();
                tn.Nodes.Add(stn);
            }
        }
        #endregion
        #endregion

        private void tvClassInfo_AfterSelect(object sender,TreeViewEventArgs e)
        {
            bindGridView(e,null);;
        }
        void bindGridView(TreeViewEventArgs e,TreeNode tn)
        {
            string sqlStr="";
            string id="";
            if(e !=null)
            {
                id=e.Node.Tag.ToString();
            }
            else
            {
                id=tn.Tag.ToString();
            }

            if (id.Length == 2)
            {
                sqlStr = "select Speciality_Name as 专业名称,Classes_ID as 班级编号,Classes_Name as 班级名称,Teacher_Name as 班主任姓名,Classes_PS as 备注 from Colleges,Speciality,Classes,Teachers where College_ID=Speciality_College and Speciality_ID=Classes_Speciality and ClassHeadTeacher=Teacher_ID and College_ID=@0";
            }

            if(id.Length==4)
            {
                sqlStr = "select Speciality_Name as 专业名称,Classes_ID as 班级编号,Classes_Name as 班级名称,Teacher_Name as 班主任姓名,Classes_PS as 备注 from Speciality,Classes,Teachers where Speciality_ID=Classes_Speciality and ClassHeadTeacher=Teacher_ID and Classes_Speciality=@0";
            }
            if(id.Length==8)
            {
                sqlStr = "select Speciality_Name as 专业名称,Classes_ID as 班级编号,Classes_Name as 班级名称,Teacher_Name as 班主任姓名,Classes_PS as 备注 from Speciality,Classes,Teachers where Speciality_ID=Classes_Speciality and ClassHeadTeacher=Teacher_ID and Classes_ID=@0";
            }

            DataTable dt=DataBaseHelper.ExecDataTable(sqlStr,id);
            dGClassInfo.DataSource=dt;
        }

        private void New_Click(object sender, EventArgs e)
        {
            AddClass addClass = new AddClass();
            addClass.ShowDialog();
            bindGridView(null, tvClassInfo.SelectedNode);
        }

        private void Property_Click(object sender, EventArgs e)
        {
            SearchClass search = new SearchClass();
            search.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            deleteClass();
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            if (dGClassInfo.SelectedRows.Count > 1)
            {
                MessageBox.Show("只能选择一条班级信息进行修改!","信息提示");
                return;
            }
            else if (dGClassInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要修改的班级!", "信息提示");
                return;
            }
            else
            {
                AddClass update = new AddClass();
                update.FormText = "修改班级信息";
                update.Tag = dGClassInfo.SelectedRows[0].Cells["班级编号"].Value;
                update.ShowDialog();
                bindGridView(null, tvClassInfo.SelectedNode);
            }
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //刷新信息,重新绑定
            tvClassInfo.Nodes.Clear();
            bindCollege();
            bindSpeciality();
            //展开所有节点
            tvClassInfo.ExpandAll();
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //删除班级信息
            deleteClass();
        }
        private void 刷新ToolStripMenuItem1_Click(object sender,EventArgs e)
        {
            //刷新DataGridView
            bindGridView(null, tvClassInfo.SelectedNode);
        }
        void deleteClass()
        {
            if (dGClassInfo.SelectedRows.Count > 0)
            {
                try
                {
                    int n = dGClassInfo.SelectedRows.Count;
                    DialogResult result = MessageBox.Show("确认删除这" + Convert.ToString(n) + "项吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = dGClassInfo.SelectedRows.Count - 1; i >= 0; i--)
                        {
                            String ClassID = dGClassInfo.SelectedRows[i].Cells["班级序号"].Value.ToString();
                            string sqlstr = "delete from Classes where Classes_ID=@0";
                            DataBaseHelper.ExecNoneQuery(sqlstr, ClassID);
                            dGClassInfo.Rows.Remove(dGClassInfo.SelectedRows[i]);

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("该班还有学生信息,无法删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的班级信息", "信息提示",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
