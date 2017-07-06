using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace 学生信息管理系统
{
    public partial class FormProperty : Form
    {
        string studentID;
        byte[] images;
        public FormProperty(string studentID)
        {
            InitializeComponent();
            this.studentID = studentID;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditForm ef = new EditForm(studentID);
            ef.Owner = this;
            ef.ShowDialog();
        }
        void BinderBaseInfo()
        {
            string sql = "select * from Students where Student_ID=@0";     
            DataTable student = DataBaseHelper.ExecDataTable(sql,studentID);
            if (student.Rows.Count == 0)
            {
                MessageBox.Show("加载出错！");
                this.Close();
                return;
            }
            DataRow row = student.Rows[0];

            string sqlimage = "select * from StudentImage where Image_Student=@0";
            DataTable studentImage = DataBaseHelper.ExecDataTable(sqlimage, studentID);
            if (studentImage.Rows.Count == 0)
            {
                MessageBox.Show("加载出错！", "错误!");
                this.Close();
                return;
            }
            DataRow rowImage = studentImage.Rows[0];

            //基本信息
            labelName.Text = row["Student_Name"].ToString();
            labelSex.Text = row["Student_Sex"].ToString();
            labelIDCardNum.Text = row["StudentCard"].ToString();
            labelBirthday.Text = row["StudentBirthDay"].ToString();
            labelNative.Text = row["StudentOrigin"].ToString();
            try
            {
                images = (byte[])rowImage["Images"];
                MemoryStream ms = new MemoryStream(images);
                Bitmap bmp = new Bitmap(ms);
                pBStudentImage.Image = bmp;
            }
            catch
            {
                pBStudentImage.Image = null;
                images = null;
            }
            //联系方法
            labelHomeAdd.Text = row["StudentAddress"].ToString();
            labelHomeTel.Text = row["FamilyTel"].ToString();
            labelMobile.Text = row["Mobile"].ToString();
            labelQQ.Text = row["QQ"].ToString();
            //学籍信息
            sql = "select s.Speciality_Name,c.Classes_Name,Colleges.College_Name,SpeYears.SpeYears_Name from ((( Students join Classes as c on Students.StudentClass=c.Classes_ID and Students.Student_ID=@0 ) join Speciality as s on c.Classes_Speciality=s.Speciality_ID) join Colleges on s.Speciality_College=Colleges.College_ID) join SpeYears on SpeYears.SpeYears_ID=s.Speciality_Years";
            DataTable dt = DataBaseHelper.ExecDataTable(sql, studentID);
            string SpecialityName = dt.Rows[0]["Speciality_Name"].ToString();
            string ClassesName = dt.Rows[0]["Classes_Name"].ToString();
            string CollegeName = dt.Rows[0]["College_Name"].ToString();
            string SpeYearsName = dt.Rows[0]["SpeYears_Name"].ToString();
            labelCollege.Text = CollegeName;
            labelStuType.Text = SpeYearsName;
            labelSpeciality.Text = SpecialityName;
            labelClass.Text = ClassesName;
            labelStuID.Text = row["StudentNum"].ToString();
            labelEnterYear.Text = row["StudentEnterYear"].ToString();
            BinderStudentinfo(studentID);
            BinderAwards();
            BinderPunishment();
        }
        void BinderAwards()
        {
            string sql = "select p.PunishmentAwardsRecode_ID as 获奖编号,pat.PunishmentAwardTypes_Name as 获奖类型,stu.Student_Name as 学生姓名,p.PunishmentAwardContent as 获奖内容,p.PunishmentAwardReason as 获奖原因,p.PUnishmentAwardDate as 获奖时间 from (PunishmentAwardsRecode as p join Students as stu on p.PunishmentAwardStudentID=stu.Student_ID and p.PunishmentAwardStudentID=@0 and p.PunishmentAwardsRecode_ID>0) join PunishmentAwardTypes as pat on p.PunishmentAwardsType_ID=pat.PunishmentAwardTypes_ID ";
            DataTable awards = DataBaseHelper.ExecDataTable(sql,studentID);
            dgvAwards.DataSource = awards;
        }
        void BinderPunishment()
        {
            string sql = "select p.PunishmentAwardsRecode_ID as 处分编号,pat.PunishmentAwardTypes_Name as 处分类型,stu.Student_Name as 学生姓名, p.PunishmentAwardContent as 处分内容,p.PunishmentAwardReason as 处分原因,p.PUnishmentAwardDate as 处分时间 from (PunishmentAwardsRecode as p join Students as stu on p.PunishmentAwardStudentID=stu.Student_ID and p.PunishmentAwardStudentID=@0 and p.PunishmentAwardsRecode_ID<0) join PunishmentAwardTypes as pat on p.PunishmentAwardsType_ID=pat.PunishmentAwardTypes_ID ";
            DataTable punishment = DataBaseHelper.ExecDataTable(sql,studentID);
            dgvPunishments.DataSource = punishment;
        }
        void BinderStudentinfo(string studentID)
        {
            string sql = "select ctr.ChangeTypesRecode_ID as 变动编号,st.Student_Name as 学生姓名, ct.ChangeTypes_Name as 变动,ctr.ChangeReason as 异动原因,ctr.ChangeDate as 异动时间 from (ChangeTypesRecode as ctr join Students as st on ctr.ChangeStudentID=st.Student_ID and ctr.ChangeStudentID=@0 ) join ChangeTypes as ct on ct.ChangeTypes_ID=ctr.ChangeTypes_ID";
            DataTable dt = DataBaseHelper.ExecDataTable(sql, studentID);
            dgvChanges.DataSource = dt;
        }
        private void FormProperty_Load(object sender, EventArgs e)
        {
            try
            {
                BinderBaseInfo();
            }
            catch
            {
                MessageBox.Show("加载数据出错！请到数据字典添加相应的数据！");
                this.Close();
            }
        }
    }
}
