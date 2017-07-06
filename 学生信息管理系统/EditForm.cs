using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace 学生信息管理系统
{
    public partial class EditForm : Form
    {
        string StudentID;
        byte[] images= null;
        public EditForm(string ID)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            StudentID = ID;
            this.ControlBox = false;
        }
        private void EditForm_Load(object sender, EventArgs e)
        {
            
            try
            {
                BinderBaseInfo();
            }
            catch
            {
                MessageBox.Show("加载数据时出现错误！请到\"系统->数据字典\"中 添加基本数据！");
                this.Close();
            }
        }
        void BinderBaseInfo()
        {
            string sql = "select * from Students where Student_ID=@0";
            DataTable student = DataBaseHelper.ExecDataTable(sql, StudentID);
            if (student.Rows.Count == 0)
            {
                MessageBox.Show("加载出错！", "错误!");
                this.Close();
                return;
            }
            DataRow row = student.Rows[0];

            string sqlimage = "select * from StudentImage where Image_Student=@0";
            DataTable studentImage = DataBaseHelper.ExecDataTable(sqlimage, StudentID);
            if (studentImage.Rows.Count == 0)
            {
                MessageBox.Show("加载出错！", "错误!");
                this.Close();
                return;
            }
            DataRow rowImage = studentImage.Rows[0];

            //基本信息
            txtBoxName.Text = row["Student_Name"].ToString();
            if (row["Student_Sex"].ToString() == "男")
                rdoBtnMale.Checked = true; 
            else
                rdoBtnFemale.Checked = true; 
            txtBoxIDCardNum.Text = row["StudentCard"].ToString();
            dateTimePickerBirth.Value = (DateTime)row["StudentBirthDay"];
            txtBoxNative.Text = row["StudentOrigin"].ToString();
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

            //联系方式
            txtBoxHomeAdd.Text = row["StudentAddress"].ToString();
            txtBoxHomeTel.Text = row["FamilyTel"].ToString();
            txtBoxMobile.Text = row["Mobile"].ToString();
            txtBoxQQ.Text = row["QQ"].ToString();
            //学籍信息
            sql = "select s.Speciality_College,c.Classes_Speciality from ( Students join Classes as c on Students.StudentClass=c.Classes_ID and Students.Student_ID=@0 ) join Speciality as s on c.Classes_Speciality=s.Speciality_ID";
            DataTable dt = DataBaseHelper.ExecDataTable(sql, StudentID);
            string SpecialityID = dt.Rows[0]["Classes_Speciality"].ToString();
            string CollegeID = dt.Rows[0]["Speciality_College"].ToString();
            BinderColleges();
            BinderSpeciality(CollegeID);
            BinderClasses(SpecialityID);
            string classID = row["StudentClass"].ToString();
            if (cmbBoxCollege.Items.Count > 0)
            {
                cmbBoxCollege.SelectedValue = CollegeID;
            }
            if (cmbBoxSpeciality.Items.Count > 0)
            {
                cmbBoxSpeciality.SelectedValue = SpecialityID;
                //学制
                BinderSpeYears(SpecialityID);
            }
            if (cmbBoxClass.Items.Count > 0)
            {
                cmbBoxClass.SelectedValue = classID;
            }
            
            //学号
            string num = row["StudentNum"].ToString();
            //txtBoxNum.Text = num.Substring(num.Length - 4); 
            txtBoxNum.Text = num;
            dateTimePickerEnterDate.Value = (DateTime)row["StudentEnterYear"];
            //学籍变动
            BinderStudentinfo(StudentID);
            sql = "select * from ChangeTypes";
            DataTable changetypes = DataBaseHelper.ExecDataTable(sql);
            cmbChangeType.DataSource = changetypes;
            cmbChangeType.DisplayMember = "ChangeTypes_Name";
            cmbChangeType.ValueMember = "ChangeTypes_ID";
            dateTimeChange.Value = DateTime.Now;
            //获奖记录
            BinderAwards();
            BinderAwardsType();
            dateTimeAward.Value = DateTime.Now;
            //处分记录
            BinderPunishment();
            BinderPunishmentType();
            dateTimePunishment.Value = DateTime.Now;
        }
        //获奖记录         
        void BinderAwards()
        {
            string sql = "select p.PunishmentAwardsRecode_ID as 获奖编号, pat.PunishmentAwardTypes_Name as 获奖类型,stu.Student_Name as 学生姓名, p.PunishmentAwardContent as 获奖内容,p.PunishmentAwardReason as 获奖原因, p.PUnishmentAwardDate as 获奖时间 from (PunishmentAwardsRecode as p join Students as stu on p.PunishmentAwardStudentID=stu.Student_ID  and p.PunishmentAwardStudentID=@0 and p.PunishmentAwardsRecode_ID>0) join PunishmentAwardTypes as pat on p.PunishmentAwardsType_ID=pat.PunishmentAwardTypes_ID ";
            DataTable awards = DataBaseHelper.ExecDataTable(sql, StudentID);
            dgvAwards.DataSource = awards;
        }
        //获奖类别
        void BinderAwardsType()
        {
            string sql = "select * from PunishmentAwardTypes where PunishmentAwardTypes_ID>0";
            DataTable awardsTypes = DataBaseHelper.ExecDataTable(sql);
            //cmbBoxArardsType.DataSource = awardsTypes; 
            //cmbBoxArardsType.DisplayMember = "PunishmentAwardTypes_Name";
            //cmbBoxArardsType.ValueMember = "PunishmentAwardTypes_ID"; 
            cmbAwardType.DataSource = awardsTypes;
            cmbAwardType.DisplayMember = "PunishmentAwardTypes_Name";
            cmbAwardType.ValueMember = "PunishmentAwardTypes_ID";
        }
        //处分记录
        void BinderPunishment()
        {
            string sql = "select p.PunishmentAwardsRecode_ID as 处分编号,pat.PunishmentAwardTypes_Name as 处分类型,stu.Student_Name as 学生姓名, p.PunishmentAwardContent as 处分内容,p.PunishmentAwardReason as 处分原因, p.PUnishmentAwardDate as 处分时间 from (PunishmentAwardsRecode as p join Students as stu on p.PunishmentAwardStudentID=stu.Student_ID  and p.PunishmentAwardStudentID=@0 and p.PunishmentAwardsRecode_ID<0) join PunishmentAwardTypes as pat on p.PunishmentAwardsType_ID=pat.PunishmentAwardTypes_ID ";
            DataTable punishment = DataBaseHelper.ExecDataTable(sql, StudentID);
            dgvPunishments.DataSource = punishment;
        }
        //处分类别
        void BinderPunishmentType()
        {
            string sql = "select * from PunishmentAwardTypes where PunishmentAwardTypes_ID<0";
            DataTable punishmentTypes = DataBaseHelper.ExecDataTable(sql);
            cmbPunishmentType.DataSource = punishmentTypes;
            cmbPunishmentType.DisplayMember = "PunishmentAwardTypes_Name";
            cmbPunishmentType.ValueMember = "PunishmentAwardTypes_ID";
        }

        //学院
        private void BinderColleges() 
        { 
            string collegesql = "select College_ID,College_Name from Colleges"; 
            DataTable dt = DataBaseHelper.ExecDataTable(collegesql); 
            cmbBoxCollege.DataSource = dt; 
            cmbBoxCollege.DisplayMember = "College_Name"; 
            cmbBoxCollege.ValueMember = "College_ID"; 
        }
        //专业
        private void BinderSpeciality(string collegeID)         
        {             
            string specsql = "select * from Speciality where Speciality_College=@0";             
            DataTable spectable = DataBaseHelper.ExecDataTable(specsql, collegeID);             
            cmbBoxSpeciality.DataSource = spectable;             
            cmbBoxSpeciality.DisplayMember = "Speciality_Name";             
            cmbBoxSpeciality.ValueMember = "Speciality_ID";         
        }
        //学制
        private void BinderSpeYears(string SpecialityID)
        {
            string yearssql = "select SpeYears_Name from SpeYears join Speciality on Speciality.Speciality_Years=SpeYears.SpeYears_ID where Speciality.Speciality_ID=@0 ";
            labStuType.Text = DataBaseHelper.ExecScalar(yearssql, SpecialityID).ToString();
        }
        //班级
         private void BinderClasses(string SpecialityID)         
         {             
             string classsql = "select * from Classes where Classes_Speciality=@0 ";             
             DataTable classdt = DataBaseHelper.ExecDataTable(classsql, SpecialityID);             
             cmbBoxClass.DataSource = classdt;
             cmbBoxClass.DisplayMember = "Classes_Name"; 
             cmbBoxClass.ValueMember = "Classes_ID";
         }
        //学籍变动
        void BinderStudentinfo(string studentID)         
        {             
            string sql = "select ctr.ChangeTypesRecode_ID as 变动编号, st.Student_Name as 学生姓名,ct.ChangeTypes_Name as 变动类型,ctr.ChangeReason as 变动原因,ctr.ChangeDate as 变动时间 from (ChangeTypesRecode as ctr join Students as st on ctr.ChangeStudentID=st.Student_ID and ctr.ChangeStudentID=@0 ) join ChangeTypes as ct on ct.ChangeTypes_ID=ctr.ChangeTypes_ID";             
            DataTable dt = DataBaseHelper.ExecDataTable(sql,studentID);             
            dgvChanges.DataSource = dt;         
        }
        private void cmbBoxCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxCollege.SelectedValue == null)
            {
                cmbBoxCollege.DataSource = null; 
                cmbBoxClass.DataSource = null; 
                return;
            }
            BinderSpeciality(cmbBoxCollege.SelectedValue.ToString());
            if (cmbBoxSpeciality.Items.Count > 0) 
            { 
                cmbBoxSpeciality.SelectedIndex = 0; 
                BinderClasses(cmbBoxSpeciality.SelectedValue.ToString()); 
            } 
            else 
            { 
                cmbBoxClass.DataSource = null; 
            }
        }
        private void cmbBoxSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBoxSpeciality.SelectedValue != null) 
            { 
                BinderClasses(cmbBoxSpeciality.SelectedValue.ToString()); 
                BinderSpeYears(cmbBoxSpeciality.SelectedValue.ToString()); 
            }
        }
        private void btnAddChange_Click(object sender, EventArgs e)
        {
            string sql = "insert into ChangeTypesRecode(ChangeTypes_ID, ChangeReason,ChangeStudentID,ChangeDate) values(@0,@1,@2,@3)";
            try
            {
                int r = DataBaseHelper.ExecNoneQuery(sql, cmbChangeType.SelectedValue, txtChangeReason.Text, StudentID, dateTimeChange.Value);
                if (r > 0)
                {
                    MessageBox.Show("添加成功！");
                    BinderStudentinfo(StudentID);
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch
            {
                MessageBox.Show("添加数据遇到严重错误！请检测你的相关数据是否合法！");
            }
        }
        private void btnDeleteChange_Click(object sender, EventArgs e)         
        {             
            if (dgvChanges.SelectedRows.Count > 0)             
            {                 
                try                 
                {                     
                    string sql = "delete ChangeTypesRecode  where ChangeTypesRecode_ID=@0"; 
                    int sucess = 0, error = 0, r;                     
                    foreach (DataGridViewRow row in dgvChanges.SelectedRows)                     
                    {                         
                        r = DataBaseHelper.ExecNoneQuery(sql, row.Cells["异动编号"].Value);                         
                        if (r > 0)                             
                            sucess++;                         
                        else                             
                            error++;                     
                    }                     
                    string msg = string.Format("总共需要删除{0}个对象,已经成功 删除{1}个对象,共有{2}个对象操作失败！", sucess + error, sucess, error);                     
                    BinderStudentinfo(StudentID);                     
                    MessageBox.Show(msg);                 
                }                 
                catch                 
                {                    
                    MessageBox.Show("删除数据遇到严重错误,请及时与技术人员取 得联系,以获得此错误的解决方法！");                 
                }             
            }             
            else             
            {                
                MessageBox.Show("请先选择要删除的记录！");            
            }        
        }
        private void btnAddAward_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select max(PunishmentAwardsRecode_ID) from PunishmentAwardsRecode";                 
                object obj = DataBaseHelper.ExecScalar(sql);                 
                int id = 1;                 
                if (!string.IsNullOrEmpty(obj.ToString()))                     
                    id = (int)obj;                 
                if (id < 1)                     
                    id = 1;                 
                else                     
                    id++;                
                sql = "insert into PunishmentAwardsRecode(PunishmentAwardsRecode_ID, PunishmentAwardsType_ID,PunishmentAwardStudentID, PunishmentAwardContent,PunishmentAwardReason,PunishmentAwardDate) values(@0,@1,@2,@3,@4,@5)";                 
                int r = DataBaseHelper.ExecNoneQuery(sql, id, cmbAwardType .SelectedValue.ToString(), StudentID, txtAwardContent.Text, txtAwardReason.Text, dateTimeAward.Value);                 
                if (r > 0)                 
                {                     
                    MessageBox.Show("添加成功！");                     
                    BinderAwards();                 
                }                 
                else                     
                    MessageBox.Show("添加失败！");             
            }             
            catch             
            {
                MessageBox.Show("添加数据遇到严重错误,请检测你的相关数据是否正确！");            
            }
        }
        private void btnDeleteAward_Click(object sender, EventArgs e)         
        {             
            if (dgvAwards.SelectedRows.Count > 0)             
            {                 
                try                 
                {                     
                    string sql = "delete PunishmentAwardsRecode  where PunishmentAwardsRecode_ID=@0";                     
                    int sucess = 0, error = 0, r;                     
                    foreach (DataGridViewRow row in dgvAwards.SelectedRows)                     
                    {                        
                        r = DataBaseHelper.ExecNoneQuery(sql, row.Cells["获奖编号"].Value);                         
                        if (r > 0)                             
                            sucess++;                         
                        else                             
                            error++;                     
                    }                     
                    string msg = string.Format("总共需要删除{0}个对象,已经成功 删除{1}个对象,共有{2}个对象操作失败！", sucess + error, sucess, error);                     
                    BinderAwards();                     
                    MessageBox.Show(msg);                 
                }                 
                catch                 
                {
                    MessageBox.Show("删除数据遇到严重错误,请及时与技术人员取得联系,以获得此错误的解决方法！");                 
                }             
            }             
            else             
            {                 
                MessageBox.Show("请选择要删除的记录！");             
            }         
        }
         private void btnAddPunishment_Click(object sender, EventArgs e)         
         {             
             try             
             {                 
                 string sql = "select min(PunishmentAwardsRecode_ID) from PunishmentAwardsRecode";                 
                 object obj = DataBaseHelper.ExecScalar(sql);                 
                 int id = -1;                 
                 if (!string.IsNullOrEmpty(obj.ToString()))                     
                     id = (int)obj;                 
                 if (id > -1)                     
                     id = -1;                
                 else                     
                     id--;                 
                 sql = "insert into PunishmentAwardsRecode(PunishmentAwardsRecode_ID, PunishmentAwardsType_ID,PunishmentAwardStudentID, PunishmentAwardContent,PunishmentAwardReason,PunishmentAwardDate) values(@0,@1,@2,@3,@4,@5)";                 
                 int r = DataBaseHelper.ExecNoneQuery(sql, id, cmbPunishmentType.SelectedValue.ToString(), StudentID, txtBoxPunishmentAwardContent.Text, txtPunishmentReason.Text, dateTimePunishment.Value);              
                 if (r > 0)                 
                 {                    
                     MessageBox.Show("添加成功！");                     
                     BinderPunishment();                 
                 }                 
                 else                     
                     MessageBox.Show("添加失败！");             
             }             
             catch           
             {               
                 MessageBox.Show("添加数据遇到严重错误,请检测你的相关数据是否正确！");     
             }      
         }
         private void btnDeletePunishment_Click(object sender, EventArgs e)         
         {            
             if (dgvPunishments.SelectedRows.Count > 0)             
             {                 
                 try                 
                 {                     
                     string sql = "delete PunishmentAwardsRecode  where PunishmentAwardsRecode_ID=@0";                     
                     int sucess = 0, error = 0, r;                    
                     foreach (DataGridViewRow row in dgvPunishments.SelectedRows)                     
                     {
                        r = DataBaseHelper.ExecNoneQuery(sql, row.Cells["处分编号"].Value);                         
                         if (r > 0)                             
                             sucess++;                         
                         else                             
                             error++;                     
                     }                     
                     string msg = string.Format("总共需要删除{0}个对象,已经成功 删除{1}个对象,共有{2}个对象操作失败！", sucess + error, sucess, error);                     
                     BinderPunishment();                     
                     MessageBox.Show(msg);                 
                 }                 
                 catch                
                 {                     
                     MessageBox.Show("添加数据遇到严重错误,请检测你的相关数据是否正确！");                 
                 }            
             }             
             else             
             {                 
                 MessageBox.Show("请选择要删除的记录！");            
             }         
         }       
        bool checkMessageinfo()         
        {             
            if (string.IsNullOrEmpty(txtBoxName.Text)) 
            {                 
                MessageBox.Show("必须填写学生姓名！");                
                return false;             
            }             
            if (cmbBoxClass.SelectedValue == null)             
            {                 
                MessageBox.Show("必须为学生选择班级！");                 
                return false;             
            }            
            if (string.IsNullOrEmpty(txtBoxNum.Text))             
            {                 
                MessageBox.Show("必须填写学号！");                 
                return false;            
            }             
            if (txtBoxNum.Text.Trim().Length != 15)             
            {                 
                MessageBox.Show("学号不能含有空格并且长度必须为15个字符！");                 
                return false;            
            }            
            if (string.IsNullOrEmpty(txtBoxNative.Text))             
            {                
                MessageBox.Show("学生籍贯不能为空！");                 
                return false;             
            }             
            if (dateTimePickerBirth.Value > dateTimePickerEnterDate.Value)            
            {                 
                MessageBox.Show("出生日期不能比入学日期小！");                 
                return false;           
            }
            //Regex reg = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");             
            //if (!reg.IsMatch(txtBoxQQ.Text))             
            //{                 
            //    MessageBox.Show("电子邮件地址不合法！");                 
            //    return false;             
            //}             
            return true;        
        }
        
        private void pBStudentImage_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;//图片路径
                FileStream fs = new FileStream(filePath, FileMode.Open);
                images = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                images = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
                string sql = "update StudentImage set Images=@0 where Image_Student=@1";
                int r = DataBaseHelper.ExecNoneQuery(sql,images,StudentID);
                if (r > 0)
                {
                    MessageBox.Show("更改照片成功！", "提示！");
                    MemoryStream ms = new MemoryStream(images);
                    Bitmap bmp = new Bitmap(ms);
                    pBStudentImage.Image = bmp;
                }
                else
                {
                    MessageBox.Show("更改照片失败！", "错误！");
                    pBStudentImage.Image = null;
                }
            }
            else
            {
                MessageBox.Show("未选择任何照片", "提示！");
                pBStudentImage.Image = null;
                images = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkMessageinfo())
                    return;
                string sql = "update Students set Student_Name=@0, Student_Sex=@1,StudentClass=@2,StudentNum=@3,StudentOrigin=@4, StudentEnterYear=@5,StudentBirthDay=@6,StudentCard=@7, StudentAddress=@8,FamilyTel=@9,Mobile=@10,QQ=@11 where Student_ID=@12";
                int r = DataBaseHelper.ExecNoneQuery(sql, txtBoxName.Text, rdoBtnMale.Checked ? "男" : "女", cmbBoxClass.SelectedValue.ToString(), txtBoxNum.Text, txtBoxNative.Text, dateTimePickerEnterDate.Value, dateTimePickerBirth.Value, txtBoxIDCardNum.Text, txtBoxHomeAdd.Text, txtBoxHomeTel.Text, txtBoxMobile.Text, txtBoxQQ.Text, StudentID);
                if (r > 0)
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch
            {
                MessageBox.Show("修改数据遇到严重的错误！该学生的学号可能与其他学生重复,请更换学号后再试！");
                //this.Close();             
            }
        } 
         private void btnCancel_Click(object sender, EventArgs e)
         {
             DialogResult result = MessageBox.Show("学生信息尚未保存修改,确定退出？", "警告！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
             if (result == DialogResult.OK)
             {
                 //Environment.Exit(Environment.ExitCode);
                 //Close();
                 this.Dispose();
             }
         }

 


    }
}
