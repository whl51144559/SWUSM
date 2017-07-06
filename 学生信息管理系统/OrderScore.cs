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
    public partial class OrderScore : Form
    {
        public OrderScore()
        {
            InitializeComponent();
        }
        private void OrderScore_Load(object sender, EventArgs e)
        {
            //1、绑定tabPage1中的学院信息
            string sql = "select * from Colleges";
            cbCollege.DataSource = DataBaseHelper.ExecDataTable(sql);
            cbCollege.DisplayMember = "College_Name";
            cbCollege.ValueMember = "College_ID";
            //2、在tabPage2中将班级表中的班级信息进行绑定
            sql = "select * from Classes";
            cbClass.DataSource = DataBaseHelper.ExecDataTable(sql);
            cbClass.DisplayMember = "Classes_Name";
            cbClass.ValueMember = "Classes_ID";
        }
        #region 按专业查询成绩信息
        private void cbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当选择了学院时显示该学院的所属专业
            string cid = "0";
            if (cbCollege.SelectedValue !=null)
            {
                //获取学院ID
                cid = cbCollege.SelectedValue.ToString();
            }
            //根据学院ID查询专业
            string sqlstr = "select * from Speciality where Speciality_College='" +cid + "'";
            cbSpeciality.DataSource = DataBaseHelper.ExecDataTable(sqlstr);
            cbSpeciality.DisplayMember = "Speciality_Name";
            cbSpeciality.ValueMember = "Speciality_ID";
            cbSpeciality_SelectedIndexChanged(null,null);
        }
        private void cbSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当选择好专业后,应显示该专业的所有科目
            string sid = "0";
            if (cbSpeciality.SelectedValue != null)
            {
                sid = cbSpeciality.SelectedValue.ToString();
            }
            string str = "select Subjects.Subjects_ID,Subjects_Name from Subjects,Sepc_Subjects where Sepc_Subjects.Subjects_ID=Subjects.Subjects_ID and Sepc_ID=@0";
            cbSubject1.DataSource = DataBaseHelper.ExecDataTable(str,sid);
            cbSubject1.DisplayMember = "Subjects_Name";
            cbSubject1.ValueMember = "Subjects_ID";
        }
        #region 根据专业进行成绩查询和排序

        private void btnOK1_Click(object sender, EventArgs e)
        {
            if (cbSpeciality.SelectedIndex != -1)
            {
                dataGridView1.DataSource = null;
                if (cbSubject1.Items.Count == 0)
                {
                    return;
                }
                DataTable scores = new DataTable();
                DataColumn colClass = new DataColumn("班级", typeof(string));
                scores.Columns.Add(colClass);

                DataColumn colName = new DataColumn("姓名", typeof(string));
                scores.Columns.Add(colName);

                for(int i=0;i<cbSubject1.Items.Count;i++)
                {
                    DataColumn colScore = new DataColumn(((DataRowView)cbSubject1.Items[i])["Subjects_Name"].ToString(), typeof(int));
                    colScore.DefaultValue = 0;
                    scores.Columns.Add(colScore);
                }
                DataColumn colTotal = new DataColumn("总分", typeof(int));
                scores.Columns.Add(colTotal);

                string sql="select e.* from Examination as e,Students as s,Classes as c where e.StudentID=s.Student_ID and s.StudentClass=c.Classes_ID and c.Classes_Speciality=@0";
                string specialityID = cbSpeciality.SelectedValue.ToString();
                DataTable exam = DataBaseHelper.ExecDataTable(sql, specialityID);

                sql = "select Student_ID,Student_Name,Classes_Name from Students,Classes where Students.StudentClass=Classes.Classes_ID and Classes_Speciality=@0";
                DataTable students = DataBaseHelper.ExecDataTable(sql, specialityID);
                DataRow row;
                int total=0;
                for(int i=0;i<students.Rows.Count;i++)
                {
                    row=scores.NewRow();
                    row["班级"]=students.Rows[i]["Classes_Name"].ToString();
                    row["姓名"]=students.Rows[i]["Student_Name"].ToString();

                    DataRow[] rows=exam.Select("StudentID="+students.Rows[i]["Student_ID"].ToString());
                    
                    total = 0;
                    int tempScore;
                    string tempSubName;
                    for (int j = 1; j <= rows.Length; j++)
                    {
                        tempScore = (int)rows[j - 1]["ExamScore"];
                        tempSubName = ((DataRowView)cbSubject1.Items[j - 1]).Row["Subjects_Name"].ToString();

                        row[tempSubName] = tempScore;
                        total += tempScore;
                    }
                    row["总分"] = total;
                    scores.Rows.Add(row);
                }
                DataView view = scores.DefaultView;

                if (checkBoxAll1.Checked)
                {
                    view.Sort = "总分 desc";
                }
                else if (cbSubject1.SelectedItem != null)
                {
                    view.Sort = ((DataRowView)cbSubject1.SelectedItem)["Subjects_Name"].ToString() + " desc";
                }

                dataGridView1.DataSource = view;
                groupBox1.Text = ((DataRowView)cbSpeciality.SelectedItem)["Speciality_Name"].ToString();
            }
            else
            {
                MessageBox.Show("请选择要查询的专业", "信息提示");
            }

        }
        #endregion
        #endregion

        #region 按班级查询成绩
        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当选择好班级后,应显示该班级所有应考科目
            if (cbClass.SelectedValue == null)
            {
                return;
            }
            groupBox1.Text = cbClass.SelectedText;
            string cid =cbClass.SelectedValue.ToString();
            string str = "select s.Subjects_ID,s.Subjects_Name from Subjects as s,Sepc_Subjects as ss,Classes as c where ss.Subjects_ID=s.Subjects_ID and ss.Sepc_ID=c.Classes_Speciality and c.Classes_ID=@0";
            cbSubject2.DataSource = DataBaseHelper.ExecDataTable(str,cid);
            cbSubject2.DisplayMember = "Subjects_Name";
            cbSubject2.ValueMember = "Subjects_ID";
        }
        private void btnOK2_Click(object sender, EventArgs e)
        {
            if (cbClass.SelectedIndex != -1)
            {
                dataGridView1.DataSource = null;
                if (cbSubject2.Items.Count == 0)
                {
                    return;
                }

                DataTable scores = new DataTable();
                DataColumn colName = new DataColumn("姓名", typeof(string));
                scores.Columns.Add(colName);
                for (int i = 0; i < cbSubject2.Items.Count; i++)
                {
                    DataColumn colScore = new DataColumn(((DataRowView)cbSubject2.Items[i])["Subjects_Name"].ToString(), typeof(int));
                    colScore.DefaultValue = 0;
                    scores.Columns.Add(colScore);
                }
                DataColumn colTotal = new DataColumn("总分", typeof(int));
                scores.Columns.Add(colTotal);

                string sql = "select e.* from Examination as e,Students as s where e.StudentID=s.Student_ID and StudentClass=@0";
                string classID = cbClass.SelectedValue.ToString();
                DataTable exam = DataBaseHelper.ExecDataTable(sql, classID);

                sql = "select Student_ID,Student_Name from Students where StudentClass=@0";
                DataTable students = DataBaseHelper.ExecDataTable(sql, classID);
                DataRow row;
                int total = 0;

                for (int i = 0; i < students.Rows.Count; i++)
                {
                    row = scores.NewRow();
                    row["姓名"] = students.Rows[i]["Student_Name"].ToString();
                    DataRow[] rows = exam.Select("StudentID=" + students.Rows[i]["Student_ID"].ToString());
                    total = 0;
                    int tempScore;
                    string tempSubName;
                    for (int j = 1; j <= rows.Length; j++)
                    {
                        tempScore = (int)rows[j - 1]["ExamScore"];
                        tempSubName = ((DataRowView)cbSubject2.Items[j - 1]).Row["Subjects_Name"].ToString();
                        row[tempSubName] = tempScore;
                        total += tempScore;
                    }
                    row["总分"] = total;
                    scores.Rows.Add(row);
                }
                DataView view = scores.DefaultView;
                if (checkBoxAll2.Checked)
                {
                    view.Sort = "总分 desc";
                }
                else if (cbSubject2.SelectedItem != null)
                {
                    view.Sort = ((DataRowView)cbSubject2.SelectedItem)["SubJects_Name"].ToString() + " desc";
                }

                dataGridView1.DataSource = view;
                groupBox1.Text = ((DataRowView)cbClass.SelectedItem)["Classes_Name"].ToString();
            }
            else
            {
                MessageBox.Show("请选择要查询的班级","信息提示");
            }
        }
        #endregion
        private void default_Selected(object sender, EventArgs e)
        {
            if (cbCollege.Items.Count > 0)
            {
                cbCollege.SelectedIndex = 14;
            }
            if (cbSpeciality.Items.Count > 0)
            {
                cbSpeciality.SelectedIndex = 2;
            }
        }
        private void checkBoxAll_Changed(object sender, EventArgs e)
        {
            if (checkBoxAll1.Checked)
                cbSubject1.Enabled = false;
            else
                cbSubject1.Enabled = true;
            if (checkBoxAll2.Checked)
                cbSubject2.Enabled = false;
            else
                cbSubject2.Enabled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btnOK1_Click(sender, e);
            }
            if (tabControl1.SelectedIndex == 1)
            {
                btnOK2_Click(sender, e);
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex==0)
                default_Selected(sender, e);
            else 
                cbClass_SelectedIndexChanged(sender, e);
        }
    }
}
