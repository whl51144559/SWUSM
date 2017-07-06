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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();        
        }
        bool level;
        public int adminID;
        private void MainForm_Load(object sender, EventArgs e)
        {
            UserLoginForm ulf = new UserLoginForm();
            ulf.Owner = this;
            level = ulf.ShowDialog() == DialogResult.Yes;
            BinderTreeView();

        }
        void BinderTreeView()
        {
            try
            {
                //查询学院
                tvStudentsInfo.Nodes.Clear();
                string sql = "select * from Colleges";
                DataTable colleges = DataBaseHelper.ExecDataTable(sql);
                foreach (DataRow row in colleges.Rows)
                {
                    TreeNode coll = new TreeNode(row["College_Name"].ToString());
                    coll.Name = row["College_ID"].ToString();
                    coll.Tag = "Colleges";
                    tvStudentsInfo.Nodes.Add(coll);
                    //查询专业
                    sql = "select Speciality_ID,Speciality_Name from Speciality where Speciality_College=@0";
                    DataTable speciality = DataBaseHelper.ExecDataTable(sql, row["College_ID"]);
                    foreach (DataRow spec in speciality.Rows)
                    {
                        TreeNode tnspec = new TreeNode(spec["Speciality_Name"].ToString());
                        tnspec.Name = spec["Speciality_ID"].ToString();
                        tnspec.Tag = "Speciality";
                        coll.Nodes.Add(tnspec);
                        //查询班级
                        sql = "select Classes_ID,Classes_Name from Classes where Classes_Speciality=@0";
                        DataTable classes = DataBaseHelper.ExecDataTable(sql, spec["Speciality_ID"]);
                        foreach (DataRow clas in classes.Rows)
                        {
                            TreeNode tnclass = new TreeNode(clas["Classes_Name"].ToString());
                            tnclass.Name = clas["Classes_ID"].ToString();
                            tnclass.Tag = "Classes";
                            tnspec.Nodes.Add(tnclass);
                        }
                    }
                }
                //tvStudentsInfo.ExpandAll();  
                //string x y z;
                //this.tvStudentsInfo.SelectedNode = tvStudentsInfo.Nodes[14].Nodes[2].Nodes[0];
            }
            catch
            {
                MessageBox.Show("加载树形菜单时出现错误！", "警告！");
            }

        }
        private void tvStudentsInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e == null)
                    return;
                else if (e.Node.Tag.ToString() == "Colleges")
                {
                    //TreeNode node = this.tvStudentsInfo.SelectedNode;
                    //lvStudentsinfo.Items.Clear();
                    //this.tvStudentsInfo.SelectedNode = node;
                    lvStudentsinfo.Items.Clear();
                    string sql = "select stu.*,spec.Speciality_Name,coll.College_Name,spy.SpeYears_Name from ((( Students as stu join Classes as cla on stu.StudentClass=cla.Classes_ID) join Speciality as spec on cla.Classes_Speciality=spec.Speciality_ID ) join SpeYears as spy on spec.Speciality_Years=spy.SpeYears_ID) join Colleges as coll on spec.Speciality_College=coll.College_ID where coll.College_ID =@0";
                    DataTable students = DataBaseHelper.ExecDataTable(sql, e.Node.Name);
                    foreach (DataRow student in students.Rows)
                    {
                        //绑定该班级的学生信息
                        ListViewItem stu = new ListViewItem();
                        //学生姓名
                        stu.Text = student["Student_Name"].ToString();
                        //通过性别设置图标样式
                        stu.ImageIndex = student["Student_Sex"].ToString() == "男" ? 1 : 0;
                        //保存学生信息的主键
                        stu.Name = student["Student_ID"].ToString();
                        //添加学号
                        stu.SubItems.Add(student["StudentNum"].ToString());
                        //添加性别
                        stu.SubItems.Add(student["Student_Sex"].ToString());
                        //所在学院
                        stu.SubItems.Add(student["College_Name"].ToString());
                        //所属专业
                        stu.SubItems.Add(student["Speciality_Name"].ToString());
                        //年级
                        stu.SubItems.Add(Convert.ToDateTime(student["StudentEnterYear"]).ToString("yyyy") + "级");
                        //stu.SubItems.Add(student["StudentEnterYear"].ToString());
                        //学制
                        stu.SubItems.Add(student["SpeYears_Name"].ToString());
                        //出生日期
                        //stu.SubItems.Add(student["SpeYears_Name"].ToString());
                        stu.SubItems.Add(Convert.ToDateTime(student["StudentBirthDay"]).ToString("yyyy-MM-dd"));
                        //籍贯
                        stu.SubItems.Add(student["StudentOrigin"].ToString());
                        lvStudentsinfo.Items.Add(stu);
                    }
                    int cuco = tvStudentsInfo.SelectedNode.Index + 1;                 
                    tSSLTreeview.Text = "共" + tvStudentsInfo.Nodes.Count + "个学院，当前第" + cuco + "个学院";
                    tSSLListView.Text = "本学院共" + lvStudentsinfo.Items.Count + "个学生";
                    tSSLListViewCu.Text = "";


                }
                else if (e.Node.Tag.ToString() == "Speciality")
                {

                    lvStudentsinfo.Items.Clear();
                    string sql = "select stu.*,spec.Speciality_Name,coll.College_Name,spy.SpeYears_Name from ((( Students as stu join Classes as cla on stu.StudentClass=cla.Classes_ID) join Speciality as spec on cla.Classes_Speciality=spec.Speciality_ID ) join SpeYears as spy on spec.Speciality_Years=spy.SpeYears_ID) join Colleges as coll on spec.Speciality_College=coll.College_ID where spec.Speciality_ID =@0";
                    DataTable students = DataBaseHelper.ExecDataTable(sql, e.Node.Name);
                    foreach (DataRow student in students.Rows)
                    {
                        //绑定该班级的学生信息
                        ListViewItem stu = new ListViewItem();
                        //学生姓名
                        stu.Text = student["Student_Name"].ToString();
                        //通过性别设置图标样式
                        stu.ImageIndex = student["Student_Sex"].ToString() == "男" ? 1 : 0;
                        //保存学生信息的主键
                        stu.Name = student["Student_ID"].ToString();
                        //添加学号
                        stu.SubItems.Add(student["StudentNum"].ToString());
                        //添加性别
                        stu.SubItems.Add(student["Student_Sex"].ToString());
                        //所在学院
                        stu.SubItems.Add(student["College_Name"].ToString());
                        //所属专业
                        stu.SubItems.Add(student["Speciality_Name"].ToString());
                        //年级
                        stu.SubItems.Add(Convert.ToDateTime(student["StudentEnterYear"]).ToString("yyyy") + "级");
                        //stu.SubItems.Add(student["StudentEnterYear"].ToString());
                        //学制
                        stu.SubItems.Add(student["SpeYears_Name"].ToString());
                        //出生日期
                        //stu.SubItems.Add(student["SpeYears_Name"].ToString());
                        stu.SubItems.Add(Convert.ToDateTime(student["StudentBirthDay"]).ToString("yyyy-MM-dd"));
                        //籍贯
                        stu.SubItems.Add(student["StudentOrigin"].ToString());
                        lvStudentsinfo.Items.Add(stu);
                    }
                    tSSLListView.Text = "本专业共" + lvStudentsinfo.Items.Count + "个学生";
                    tSSLListViewCu.Text = "";
                }
                else if (e.Node.Tag.ToString() == "Classes")
                {
                    
                    lvStudentsinfo.Items.Clear();
                    //查询选择的班级的学生信息
                    string sql = "select stu.*,spec.Speciality_Name,coll.College_Name,spy.SpeYears_Name from ((( Students as stu join Classes as cla on stu.StudentClass=cla.Classes_ID) join Speciality as spec on cla.Classes_Speciality=spec.Speciality_ID ) join SpeYears as spy on spec.Speciality_Years=spy.SpeYears_ID) join Colleges as coll on spec.Speciality_College=coll.College_ID where cla.Classes_ID=@0";
                    DataTable students = DataBaseHelper.ExecDataTable(sql, e.Node.Name);
                    foreach (DataRow student in students.Rows)
                    {
                        //绑定该班级的学生信息
                        ListViewItem stu = new ListViewItem();
                        //学生姓名
                        stu.Text = student["Student_Name"].ToString();
                        //通过性别设置图标样式
                        stu.ImageIndex = student["Student_Sex"].ToString() == "男" ? 1 : 0;
                        //保存学生信息的主键
                        stu.Name = student["Student_ID"].ToString();
                        //添加学号
                        stu.SubItems.Add(student["StudentNum"].ToString());
                        //添加性别
                        stu.SubItems.Add(student["Student_Sex"].ToString());
                        //所在学院
                        stu.SubItems.Add(student["College_Name"].ToString());
                        //所属专业
                        stu.SubItems.Add(student["Speciality_Name"].ToString());
                        //年级
                        stu.SubItems.Add(Convert.ToDateTime(student["StudentEnterYear"]).ToString("yyyy") + "级");
                        //stu.SubItems.Add(student["StudentEnterYear"].ToString());
                        //学制
                        stu.SubItems.Add(student["SpeYears_Name"].ToString());
                        //出生日期
                        //stu.SubItems.Add(student["SpeYears_Name"].ToString());
                        stu.SubItems.Add(Convert.ToDateTime(student["StudentBirthDay"]).ToString("yyyy-MM-dd"));
                        //籍贯
                        stu.SubItems.Add(student["StudentOrigin"].ToString());
                        lvStudentsinfo.Items.Add(stu);
                    }
                    tSSLListView.Text = "本班级共" + lvStudentsinfo.Items.Count + "个学生";
                    tSSLListViewCu.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("加载数据出现错误！","警告！");
            }
            lvStudentsinfo.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); 
        }
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewStudentForm nform = new NewStudentForm();
            nform.Owner = this;
            nform.ShowDialog();
            刷新ToolStripMenuItem_Click(sender, e);
        }
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvStudentsinfo.SelectedItems.Count == 1)
            {
                EditForm ef = new EditForm(lvStudentsinfo.SelectedItems[0].Name);
                ef.Owner = this;
                ef.ShowDialog();
                tvStudentsInfo_AfterSelect(null, null);
                刷新ToolStripMenuItem_Click(sender, e);
            }
            else if (lvStudentsinfo.SelectedItems.Count > 1)
            {
                MessageBox.Show("你只能选择一个学生！");
            }
            else
                MessageBox.Show("请先选择学生！");
        }
        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvStudentsinfo.SelectedItems.Count ==1)             
            {                 
                FormProperty fp = new FormProperty(lvStudentsinfo.SelectedItems[0].Name);                 
                fp.Owner = this;
                fp.ShowDialog();                 
                tvStudentsInfo_AfterSelect(null, null);             
                }             
                else if (lvStudentsinfo.SelectedItems.Count > 1)             
                {                 
                    MessageBox.Show("你只能选择一个学生！");             
                }             
                else             
                {                
                    MessageBox.Show("请先选择学生！");             
                }
        
        }
        
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lvStudentsinfo.SelectedItems.Count > 0)             
            {
                int dm = lvStudentsinfo.SelectedItems.Count;
                if (MessageBox.Show("确定删除这"+dm+"个学生的信息？", "警告！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        string sql = "delete Students where Student_ID=@0";
                        int sucess = 0, error = 0, r = 0;
                        foreach (ListViewItem item in lvStudentsinfo.SelectedItems)
                        {
                            r = DataBaseHelper.ExecNoneQuery(sql, item.Name);
                            if (r > 0)
                                sucess++;
                            else
                                error++;
                        }
                        string msg = string.Format("总共需要删除{0}个学生信息 \n成功删除{1}个学生信息 \n共有{2}个学生信息删除失败！", sucess + error, sucess, error);
                        MessageBox.Show(msg);
                        刷新ToolStripMenuItem_Click(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("删除数据遇到严重错误！", "警告！");
                    }
                }

            }
            else             
            {                
                MessageBox.Show("请选择要删除的学生！");             
            }
        
        }
        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode); 
        }
        private void 工具栏ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            toolStrip1.Visible = 工具栏ToolStripMenuItem.Checked;
        }
        private void 状态栏ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip1.Visible = 状态栏ToolStripMenuItem.Checked;
        }
        private void 列表栏ToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            tvStudentsInfo.Visible = 列表栏ToolStripMenuItem.Checked;
        }
        private void 工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (工具栏ToolStripMenuItem.Checked)
            {
                工具栏ToolStripMenuItem.Checked = false;
            }
            else
            {
                工具栏ToolStripMenuItem.Checked = true;
            }
            
        }
        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (状态栏ToolStripMenuItem.Checked)
            {
                状态栏ToolStripMenuItem.Checked = false;
            }
            else
            {
                状态栏ToolStripMenuItem.Checked = true;
            }

        }
        private void 列表栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (列表栏ToolStripMenuItem.Checked)
            {
                列表栏ToolStripMenuItem.Checked = false;
            }
            else
            {
                列表栏ToolStripMenuItem.Checked = true;
            }
        }
        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvStudentsinfo.View = View.LargeIcon; 
            OnlyChecked((ToolStripMenuItem)sender); 
        }
        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvStudentsinfo.View = View.SmallIcon; 
            OnlyChecked((ToolStripMenuItem)sender); 

        }
        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvStudentsinfo.View = View.List;
            OnlyChecked((ToolStripMenuItem)sender);
        }
        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvStudentsinfo.View = View.Details;
            OnlyChecked((ToolStripMenuItem)sender);
        }
        void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvStudentsinfo.Items.Clear();
            TreeNode node = this.tvStudentsInfo.SelectedNode;
            this.tvStudentsInfo.SelectedNode = null;
            this.tvStudentsInfo.SelectedNode = node;
            //BinderTreeView();
        }
        void OnlyChecked(ToolStripMenuItem toolStripMenuItem)
        {
            大图标ToolStripMenuItem.Checked = false;
            小图标ToolStripMenuItem.Checked = false;
            列表ToolStripMenuItem.Checked = false;
            详细信息ToolStripMenuItem.Checked = false;
            toolStripMenuItem.Checked = true;
        }
        private void 排名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderScore os = new OrderScore(); 
            os.Owner = this;
            os.Show();
            //os.ShowDialog();
        }
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddScore ds = new AddScore();             
            ds.Owner = this;
            ds.ShowDialog();
        }
        private void 添加班级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClass ac = new AddClass(); 
            ac.Owner = this;
            ac.ShowDialog();
        }
        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchClass sc = new SearchClass(); 
            sc.Owner = this;
            sc.ShowDialog();
        }
        private void 浏览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassesInfo cf = new ClassesInfo(); 
            cf.Owner = this;
            cf.ShowDialog();
        }
        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (level) 
            { 
                UserManagement um = new UserManagement(); 
                um.Owner = this;
                um.ShowDialog(); 
            } 
            else 
            {
                MessageBox.Show("您无权进行此操作","警告"); 
            }
        }
        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(); 
            cp.Owner = this;
            cp.ShowDialog(); 
        }
        private void 组织机构设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrgSetForm osf = new OrgSetForm(); 
            osf.Owner = this;
            osf.ShowDialog();
        }
        private void 参数类型设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TypesSetForm tsf = new TypesSetForm(); 
            tsf.Owner = this;
            tsf.ShowDialog(); 
        }
        private void 关于学生信息管理系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMe am = new AboutMe(); 
            am.Owner = this;
            am.ShowDialog();
        }

        private void lvStudentsinfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStudentsinfo.SelectedItems.Count > 0)
            {
                int si = lvStudentsinfo.SelectedItems[0].Index+1;
                int s = si + 1;
                tSSLListViewCu.Text= "，当前第" + si + "个学生";
            }
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            BinderTreeView();
        }

        private void 更换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


    }
}
