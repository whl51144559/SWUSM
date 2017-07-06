using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace 学生信息管理系统
{
    public partial class AddClass : Form
    {
        public string FormText;
        string classid;
        public AddClass()
        {
            InitializeComponent();
        }
        private void AddClass_Load(object sender, EventArgs e)
        {
            string sql = "select * from Colleges";
            DataTable college = DataBaseHelper.ExecDataTable(sql);
            cbCollege.DataSource = college;
            cbCollege.DisplayMember = "College_Name";
            cbCollege.ValueMember = "College_ID";

            sql = "select * from Teachers";
            DataTable headmaster = DataBaseHelper.ExecDataTable(sql);
            cbHeadMaster.DataSource = headmaster;
            cbHeadMaster.DisplayMember = "Teacher_Name";
            cbHeadMaster.ValueMember = "Teacher_ID";

            if (FormText == "修改班级信息")
            {
                this.Text = FormText;
                btnOK.Text = "确定修改";
                classid = this.Tag.ToString();
                string sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,College_Name as 所在学院,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s,Colleges where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and s.Speciality_College=Colleges.College_ID and Classes_ID=@0";
                DataTable dt = DataBaseHelper.ExecDataTable(sqlStr, classid);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbCollege.Text = dt.Rows[i]["所在学院"].ToString();
                    cbSpeciality.Text = dt.Rows[i]["所属专业"].ToString();
                    lblPre.Text = classid.Substring(0, 4);
                    txtClassID.Text = classid.Substring(4, 4);

                    cbCollege.Enabled = false;
                    cbSpeciality.Enabled = false;
                    txtClassID.Enabled = false;

                    txtClassName.Text = dt.Rows[i]["班级名称"].ToString();
                    cbHeadMaster.Text = dt.Rows[i]["班主任"].ToString();
                    txtPS.Text = dt.Rows[i]["备注"].ToString();
                }
            }
        }


        private void cbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cid = cbCollege.SelectedValue.ToString();
            string sqlstr = "select * from Speciality where Speciality_College=@0";
            DataTable speciality = DataBaseHelper.ExecDataTable(sqlstr,cid);
            cbSpeciality.DataSource = speciality;
            cbSpeciality.DisplayMember = "Speciality_Name";
            cbSpeciality.ValueMember = "Speciality_ID";
        }

        private void cbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSpeciality.SelectedValue.ToString() != "")
            {
                lblPre.Text = cbCollege.SelectedValue.ToString()+ cbSpeciality.SelectedValue.ToString();
            }
        }
        #region 确定添加或修改班级信息
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (FormText == null)
            {
                if (cbCollege.Text.ToString() == "")
                {
                    MessageBox.Show("学院信息不允许空！请添加学院信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbSpeciality.Text.ToString() == "")
                {
                    MessageBox.Show("专业信息不允许空！请添加专业信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtClassID.Text.Trim() == "")
                {
                    MessageBox.Show("班级编号不允许空！", "警告",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txtClassName.Text.Trim() == "")
                {
                    MessageBox.Show("班级名称不允许空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbHeadMaster.Text.ToString() == "")
                {
                    MessageBox.Show("班主任信息不允许空！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtClassID.Text.Trim().Length != 4)
                {
                    MessageBox.Show("班级编号需写四位！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    string cid = lblPre.Text.Trim()+txtClassID.Text.Trim();//班级编号
                    string cname = txtClassName.Text.Trim();//班级名称
                    string c_s = cbSpeciality.SelectedValue.ToString();//专业编号
                    string c_t = cbHeadMaster.SelectedValue.ToString();//班主任编号

                    string sqlstr = "insert into Classes(Classes_ID,Classes_Name,Classes_Speciality,ClassHeadTeacher,Classes_PS) values(@0,@1,@2,@3,@4)";
                    int i = DataBaseHelper.ExecNoneQuery(sqlstr, cid, cname, c_s, c_t, txtPS.Text);
                    if (i > 0)
                    {
                        MessageBox.Show("添加班级成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtClassID.Text = "";
                        txtClassName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("添加班级失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("已经存在该班级编号,请重新填写！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            if (FormText == "修改班级信息")
            {
                string sqlstr = "update Classes set Classes_Name=@0,ClassHeadTeacher=@1,Classes_PS=@2 where Classes_ID=@3";
                string cname=txtClassName.Text.Trim();
                string tid = cbHeadMaster.SelectedValue.ToString();
                string ps=txtPS.Text;
                string cid=lblPre.Text.Trim()+txtClassID.Text.Trim();
                int i=DataBaseHelper.ExecNoneQuery(sqlstr, cname, tid, ps,cid);

                if (i > 0)
                {
                    MessageBox.Show("修改班级信息成功！", "信息提示");
                }
                else
                {
                    MessageBox.Show("修改班级信息失败！", "错误",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
