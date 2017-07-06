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
    public partial class SearchClass : Form
    {
        public SearchClass()
        {
            InitializeComponent();
        }
        bool locked = false;
        private void SearchClass_Load(object sender, EventArgs e)
        {
            //绑定班主任名称
            string sql = "select * from Teachers";
            DataTable teachers = DataBaseHelper.ExecDataTable(sql);
            cbHeadMaster.DataSource = teachers;
            cbHeadMaster.DisplayMember = "Teacher_Name";
            cbHeadMaster.ValueMember = "Teacher_ID";

            //绑定学院名称
            sql = "select * from Colleges";
            DataTable colleges = DataBaseHelper.ExecDataTable(sql);
            locked = true;
            cbCollege.DataSource = colleges;
            cbCollege.DisplayMember = "College_Name";
            cbCollege.ValueMember = "College_ID";
            locked = false;
            cbCollege.SelectedIndex = -1;
            cbCollege_SelectedIndexChanged(null, null);
        }

        private void cbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked)
            {
                return;
            }
            //当选择了学院时显示该学院的所属专业
            cbSpeciality.Text = "";
            cbClass.Text = "";
            string cid = "0";
            if (cbCollege.SelectedValue != null)
            {
                //获取学院ID
                cid = cbCollege.SelectedValue.ToString();
            }
            //根据学院ID查询专业
            string sqlstr = "select * from Speciality where Speciality_College=@0";
            locked = true;
            cbSpeciality.DataSource = DataBaseHelper.ExecDataTable(sqlstr,cid);
            cbSpeciality.DisplayMember = "Speciality_Name";
            cbSpeciality.ValueMember = "Speciality_ID";
            locked = false;
            cbSpeciality_SelectedIndexChanged(null, null);
        }
        private void cbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked)
            {
                return;
            }
            //当选择了专业时显示该专业的所属班级
            cbClass.Text = "";
            string sid = "0";
            if (cbSpeciality.SelectedValue != null)
            {
                //获取专业ID
                sid= cbSpeciality.SelectedValue.ToString();
            }
            string sqlstr = "select * from Classes where Classes_Speciality=@0";
            cbClass.DataSource = DataBaseHelper.ExecDataTable(sqlstr, sid);
            cbClass.DisplayMember = "Classes_Name";
            cbClass.ValueMember = "Classes_ID";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //查询信息——可以根据其中任意多个条件进行查询
            if (cbCollege.Text.Trim() == "" && cbSpeciality.Text.Trim() == "" &&
            cbClass.Text.Trim() == "" && cbHeadMaster.Text.Trim() == "")
            {
                MessageBox.Show("至少选择一个条件进行查询!", "信息提示");
                return;
            }
            string sqlStr = "";
            string name = "";
            DataTable result = new DataTable();

            //如果没有教师名称
            if (cbHeadMaster.Text.Trim() == "")
            {
                if (cbClass.Text.Trim() != "")
                {
                    name = cbClass.Text;
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and Classes_Name like '%'+@0+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name);
                }
                else if (cbSpeciality.Text.Trim() != "")
                {
                    name = cbSpeciality.Text;
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and s.Speciality_Name like '%'+@0+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name);
                }
                else if (cbCollege.Text.Trim() != "")
                {
                    name = cbCollege.Text;
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s,Colleges where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and s.Speciality_College=Colleges.College_ID and College_Name like '%'+@0+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name);
                }
            }
            else
            {
                string tName = cbHeadMaster.Text;
                if (cbClass.Text.Trim() != "")
                {
                    name = cbClass.Text;
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and Classes_Name like '%'+@0+'%' and Teacher_Name like '%'+@1+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name,tName);
                }
                else if (cbSpeciality.Text.Trim() != "")
                {
                    name = cbSpeciality.Text;
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and Speciality_Name like '%'+@0+'%' and Teacher_Name like '%'+@1+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name,tName);
                }
                else if (cbCollege.Text.Trim() != "")
                {
                    name = cbCollege.Text;
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s,Colleges where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and s.Speciality_College=Colleges.College_ID and College_Name like '%'+@0+'%' and Teacher_Name like '%'+@1+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name, tName);
                }
                else
                {
                    sqlStr = "select c.Classes_ID as 班级编号,c.Classes_Name as 班级名称,s.Speciality_Name as 所属专业,t.Teacher_Name as 班主任,c.Classes_PS as 备注 from Classes as c,Teachers as t,Speciality as s where c.ClassHeadTeacher=t.Teacher_ID and c.Classes_Speciality=s.Speciality_ID and Teacher_Name like '%'+@1+'%'";
                    result = DataBaseHelper.ExecDataTable(sqlStr, name,tName);
                }
            }
            if (result.Rows.Count == 0)
            {
                MessageBox.Show("没有符合查询条件的记录，请重新填写！", "信息提示");
            }
            dataGridView1.DataSource = result;
        }

        

    }
}
