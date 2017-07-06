using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace 学生信息管理系统
{
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }
        List<string> arrSubjects = new List<string>();
        bool locked = false;
        private void AddScore_Load(object sender, EventArgs e)
        {
            string sql = "select * from Colleges";
            DataTable college = DataBaseHelper.ExecDataTable(sql);
            locked = true;
            cbCollege.DataSource = college;
            cbCollege.DisplayMember = "College_Name";
            cbCollege.ValueMember = "College_ID";
            locked = false;
        }

        private void default_Selected(object sender, EventArgs e)
        {

        }
        private void cbCollege_SelectedIndexChanged(object sender,EventArgs e)
        {
            //当选择了学院时显示该学院的所属专业
            if (locked)
            {
                return;
            }
            //将原课程清空
            gbSubjects.Controls.Clear();
            //获取学院ID
            string cid = cbCollege.SelectedValue.ToString();
            //根据学院ID查询专业
            string sqlstr = "select * from Speciality where Speciality_College=@0";
            DataTable speciality = DataBaseHelper.ExecDataTable(sqlstr,cid);
            locked = true;
            cbSpeciality.DataSource = speciality;
            cbSpeciality.DisplayMember = "Speciality_Name";
            cbSpeciality.ValueMember = "Speciality_ID";
            locked = false;
            if (cbSpeciality.Items.Count == 0)
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            cbSpeciality_SelectedIndexChanged(null, null);
        }
        private void cbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当选择了专业时显示该专业的所属班级
            if (locked)
            {
                return;
            }
            gbSubjects.Controls.Clear();
            arrSubjects.Clear();
            string sid = "0";
            if (cbSpeciality.SelectedValue != null)
            {
                //获取专业ID
                sid = cbSpeciality.SelectedValue.ToString();
            }
            string sqlstr = "select * from Classes where Classes_Speciality=@0";
            DataTable classes = DataBaseHelper.ExecDataTable(sqlstr, sid);
            locked = true;
            cbClass.DataSource = classes;
            cbClass.DisplayMember = "Classes_Name";
            cbClass.ValueMember = "Classes_ID";
            locked = false;
            //当选择好专业后,应显示该专业的所有科目
            string str = "select Subjects.Subjects_ID,Subjects_Name from Subjects,Sepc_Subjects where Sepc_Subjects.Subjects_ID=Subjects.Subjects_ID and Sepc_ID=@0";
            DataTable dt = DataBaseHelper.ExecDataTable(str, sid);
            for(int i=0; i<dt.Rows.Count;i++)
            {
                Subjects sj = new Subjects();
                sj.lblSubjectName.Text=dt.Rows[i]["Subjects_Name"].ToString();
                gbSubjects.Controls.Add(sj);
                //给用户控件定位
                sj.Location = new Point(10,15 + 30 * i);
                //将课程ID存储,方便提交成绩时使用
                arrSubjects.Add(dt.Rows[i]["Subjects_ID"].ToString());
                int os = this.Height - gbSubjects.Height;
                this.Height = os + sj.Location.Y+30 ;


            }
            if (cbClass.Items.Count == 0)
            {
                //无班级则无学生
                button1.Enabled = false;
                button2.Enabled = false;
            }
            cbClass_SelectedIndexChanged(null,null);
        }
        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当选择了班级时显示该班级的所有学生
            if (locked)
            {
                return;
            }
            string classid = "0";
            if (cbClass.SelectedValue != null)
            {
                //获取班级ID
                classid = cbClass.SelectedValue.ToString();
            }
            string sqlstr = "select Student_ID,Student_Name,StudentNum from Students where StudentClass=@0";
            DataTable students = DataBaseHelper.ExecDataTable(sqlstr,classid);
            locked = true;
            cbStuName.DataSource = students;
            cbStuName.DisplayMember = "Student_Name";
            cbStuName.ValueMember = "Student_ID";
            locked = false;
            if (cbStuName.Items.Count > 0)
            {
                cbStuName.SelectedIndex = 0;
                if (gbSubjects.Controls.Count == 0)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                }
            }
            else
            {
                lblStuID.Text = "0";
                button1.Enabled = false;
                button2.Enabled = false;
            }
            cbStuName_SelectedIndexChanged(null, null);
        }
        private void cbStuName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当选择学生后显示该学生的学号
            if (locked)
                return;
            if (cbStuName.SelectedValue != null)
            {

                string sqlnum = "select StudentNum from Students where Student_ID=@0";
                string Student_ID = cbStuName.SelectedValue.ToString();
                lblStuID.Text = cbStuName.SelectedValue.ToString();
                lblStuNum.Text = DataBaseHelper.ExecScalar(sqlnum, Student_ID).ToString();
                
                //string sqlstr = "select Student_ID,Student_Name,StudentNum from Students where StudentClass=@0";
                //DataTable students = DataBaseHelper.ExecDataTable(sqlstr, classid);
            }
            else
            {

                lblStuID.Text = "0";

            }
            //如果该学生已经录入成绩则显示成绩,并不能填写成绩
            string sqlstr = "select * from Examination where StudentID=@0";
            DataTable dt= DataBaseHelper.ExecDataTable(sqlstr,lblStuID.Text);
            int i = 0;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Subjects sub = (Subjects)(gbSubjects.Controls[j]);
                sub.txtScore.Text = dt.Rows[j]["ExamScore"].ToString();
                sub.txtScore.Enabled = false;
                i++;
            }
            if (gbSubjects.Controls.Count > 0)
            {
                if (i == 0) //说明该学生没有成绩记录,应该提交成绩
                {
                    foreach (Control c in gbSubjects.Controls)
                    {
                        Subjects sub = (Subjects)c;
                        sub.txtScore.Enabled = true;
                        sub.txtScore.Text = "";
                    }
                    button1.Enabled = true;
                    button2.Enabled = false;
                }
                else//说明该学生有成绩记录,应该可以修改成绩
                {
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //提交成绩
            try
            {
                int count = gbSubjects.Controls.Count;
                string sqlstr = "insert into Examination(StudentID,SubjectsID, ExamScore) values({0},{1},{2})";
                StringBuilder sql = new StringBuilder();
                string score = "";
                for (int i = 0; i < count; i++)
                {
                    Subjects sub = (Subjects)(gbSubjects.Controls[i]);
                    if (sub.txtScore.Text.Trim() == "")
                {
                    score = "0";
                }
                else
                {
                    score = sub.txtScore.Text.Trim();
                }
                sql.AppendFormat(sqlstr,
                cbStuName.SelectedValue.ToString(), arrSubjects[i], score);
                }
                    DataBaseHelper.BeginTranExecNoneQuery(sql.ToString());
                    int result = DataBaseHelper.EndTranExecNoneQuery(count);
                    if (result == count)
                {
                    MessageBox.Show("提交成绩成功！", "信息提示");
                }
                else
                {
                    MessageBox.Show("提交成绩失败！", "信息提示");
                }
            }
            catch
            {
                MessageBox.Show("分数格式错误");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //修改成绩
            try
            {
                //要修改成绩的学生编号
                string sid = lblStuID.Text;
                if (sid != "0")
                {
                string sqlstr = "update Examination set ExamScore={0} where StudentID={1} and SubjectsID={2} ";
                StringBuilder sql = new StringBuilder();
                int i = 0;
                foreach (Control c in gbSubjects.Controls)
                {
                    Subjects sub = (Subjects)c;
                    if (sub.txtScore.Enabled)
                    {
                        string score = sub.txtScore.Text.Trim();
                        sql.AppendFormat(sqlstr, score, sid,arrSubjects[i].ToString());
                        sub.txtScore.Enabled = false;
                    }
                    i++;
                }
                    DataBaseHelper.BeginTranExecNoneQuery(sql.ToString());
                    int r= DataBaseHelper.EndTranExecNoneQuery(i);
                    if (r == i)
                    {
                        MessageBox.Show("修改成功!","信息提示");
                    }
                    else
                    {
                        MessageBox.Show("修改失败!","信息提示");
                    }
                }
                else
                {
                    MessageBox.Show("请选择学生!", "信息提示");
                }
            }
            catch
            {
                MessageBox.Show("分数格式错误");
            }
        }
    }
}
