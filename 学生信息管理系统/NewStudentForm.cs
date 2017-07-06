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
    public partial class NewStudentForm : Form
    {
        public NewStudentForm()
        {
            InitializeComponent();
        }
        private void NewStudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                BinderColleges();
                if (cmbBoxCollege.Items.Count > 0)
                {                          
                    BinderSpeciality(cmbBoxCollege.SelectedValue.ToString());
                    if (cmbBoxSpeciality.Items.Count > 0)
                    {
                        string SpecialityID = cmbBoxSpeciality.SelectedValue.ToString();
                        BinderSpeYears(SpecialityID);
                        BinderClasses(SpecialityID);
                    }
                }
                dtpEnterYear.Value = DateTime.Now;
            }
            catch
            {
                MessageBox.Show("加载数据是出现错误！可能是因为缺乏相关的数据,请到数据字典添加基本的数据！");
                this.Close();
            }
        }
        bool locked = false;
        byte[] images;
        private void BinderColleges()
        {
            locked = true; 
            string collegesql ="select College_ID,College_Name from Colleges "; 
            DataTable dt = DataBaseHelper.ExecDataTable(collegesql); 
            cmbBoxCollege.DataSource = dt; 
            cmbBoxCollege.DisplayMember = "College_Name"; 
            cmbBoxCollege.ValueMember = "College_ID";    
            locked = false;
        }
        private void BinderSpeYears(string SpecialityID)
        {
            string yearssql = "select sy.SpeYears_Name from SpeYears as sy join Speciality as sp on sp.Speciality_Years=sy.SpeYears_ID where sp.Speciality_ID=@0 " ;
            LableBoxStuType.Text = DataBaseHelper.ExecScalar(yearssql,SpecialityID).ToString();
        }
        private void BinderSpeciality(string collegeID)
        {
            locked = true;
            string specsql = "select * from Speciality where Speciality_College=@0";
            DataTable spectable = DataBaseHelper.ExecDataTable(specsql, collegeID);
            cmbBoxSpeciality.DataSource = spectable;
            cmbBoxSpeciality.DisplayMember = "Speciality_Name";
            cmbBoxSpeciality.ValueMember = "Speciality_ID";    
            locked = false;
        }
        private void BinderClasses(string SpecialityID)
        {
            locked = true;             
            string classsql = "select * from Classes where Classes_Speciality=@0";             
            DataTable classdt = DataBaseHelper.ExecDataTable(classsql, SpecialityID);             
            cmbBoxClass.DataSource = classdt;             
            cmbBoxClass.DisplayMember = "Classes_Name";             
            cmbBoxClass.ValueMember = "Classes_ID";             
            locked = false;
        }

        

        private void txtBoxStuID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void cmbBoxCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked) 
                return;
            if (cmbBoxCollege.SelectedValue == null)
            {
                cmbBoxSpeciality.DataSource = null; 
                cmbBoxClass.DataSource = null; 
                return; 
            }
            try
            {
                BinderSpeciality(cmbBoxCollege.SelectedValue.ToString());
                if(cmbBoxSpeciality.Items.Count > 0)
                {
                    cmbBoxSpeciality.SelectedIndex=0;
                    string SpecialityID = cmbBoxSpeciality.SelectedValue.ToString();
                    BinderSpeYears(SpecialityID);                    
                    BinderClasses(SpecialityID);
                }
                else
                {
                    cmbBoxClass.DataSource = null;                    
                    LableBoxStuType.Text = "请选择专业";
                }
            }
            catch
            {
                MessageBox.Show("加载数据时出现重大错误！请确保数据字典中的数据无误！","警告！");                 
                this.Close(); 
            }
        }

        private void cmbBoxSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked)     
                return;
            if (cmbBoxSpeciality.SelectedValue == null)
            {
                cmbBoxClass.DataSource = null;
                return; 
            }
            try
            {
                string SpecialityID = cmbBoxSpeciality.SelectedValue.ToString();
                BinderSpeYears(SpecialityID);
                BinderClasses(SpecialityID);
            }
            catch
            {
                MessageBox.Show("加载数据时出现重大错误！请确保数据字典中的数据无误！","警告"); 
                this.Close(); 
            }
        }

        private void pBStudentImage_DoubleClick(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //try
                //{
                //    string filePath = ofd.FileName;//图片路径
                //    FileStream fs = new FileStream(filePath, FileMode.Open);
                //    images = new byte[fs.Length];
                //    BinaryReader br = new BinaryReader(fs);
                //    images = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
                //    MemoryStream ms = new MemoryStream(images);
                //    Bitmap bmp = new Bitmap(ms);
                //    pBStudentImage.Image = bmp;
                //}
                //catch
                //{
                //    MessageBox.Show("更改照片失败！", "错误！");
                //    images = null;
                //}
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    images = new byte[fs.Length];
                    BinaryReader br = new BinaryReader(fs);
                    images = br.ReadBytes(Convert.ToInt32(fs.Length));//图片转换成二进制流
                    MemoryStream ms = new MemoryStream(images);
                    Bitmap bmp = new Bitmap(ms);
                    pBStudentImage.Image = bmp;
                }
            }
            else
            {
                MessageBox.Show("未选择任何照片", "提示！");
                pBStudentImage.Image = null;
                images = null;
            }

        }
        bool checkMessageinfo()
        {
            if (string.IsNullOrEmpty(txtBoxName.Text))
            {
                MessageBox.Show("请填写学生姓名！", "填写要求提示");
                return false;
            }
            if (cmbBoxClass.SelectedValue == null)
            {
                MessageBox.Show("请选择班级！", "填写要求提示");
                return false;
            }
            if (string.IsNullOrEmpty(txtBoxStuID.Text))
            {
                MessageBox.Show("请填写学号！", "填写要求提示");
                return false;
            }
            if (txtBoxStuID.Text.Trim().Length != 15)
            {
                MessageBox.Show("学号不能含有空格并且长度必须为15！", "填写要求提示");
                return false;
            }
            if (string.IsNullOrEmpty(txtBoxNative.Text))
            {
                MessageBox.Show("学生籍贯不能为空！", "填写要求提示");
                return false;
            }
            if (dateTimePickerBirth.Value > dtpEnterYear.Value) 
            {
                MessageBox.Show("出生日期不能比入学日期小！", "填写要求提示"); 
                return false; 
            }
            //Regex reg = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"); 
            //if(!reg.IsMatch(txtBoxEmail.Text)) 
            //{                 
            //    MessageBox.Show("电子邮件地址不合法！");                 
            //    return false;             
            //}             
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                tabControl1.SelectedIndex = 1;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 2;
            }
            else
            {
                try
                {
                    if (!checkMessageinfo())
                        return;
                    string sql = "insert into Students(Student_Name,Student_Sex,StudentClass,StudentNum,StudentOrigin,StudentEnterYear,StudentBirthDay,StudentCard,StudentAddress,FamilyTel,Mobile,QQ) values (@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11) ";
                    int r = DataBaseHelper.ExecNoneQuery(sql, txtBoxName.Text, rdoBtnMale.Checked ? "男 " : "女", cmbBoxClass.SelectedValue.ToString(), txtBoxStuID.Text, txtBoxNative.Text, dtpEnterYear.Value, dateTimePickerBirth.Value, txtBoxIDCardNum.Text, txtBoxHomeAdd.Text, txtBoxHomeTel.Text, txtBoxMobile.Text, txtBoxQQ.Text);
                    if (r > 0)
                    {
                        if (images != null)
                        {                           
                            MessageBox.Show("添加成功,即将插入图片");
                            
                            string sql1 = "select Student_ID from Students where Student_Name=@0";
                            int studentID = (int)DataBaseHelper.ExecScalar(sql1, txtBoxName.Text);
                            string sql2 = "update StudentImage set Images=@0 where Image_Student=@1";
                            int r2 = DataBaseHelper.ExecNoneQuery(sql2, images, studentID);
                            if (r2 > 0)
                                MessageBox.Show("插入图片成功");
                            else
                                MessageBox.Show("插入图片失败");
                        }
                        else
                            MessageBox.Show("添加成功!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }
                catch
                {
                    MessageBox.Show("添加数据时出现重大错误！请确保你添加的数据合法！");
                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("学生信息未保存,确定退出？", "警告！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (result == DialogResult.OK)
            //{
            //    this.Dispose();
            //}

            if (MessageBox.Show("学生信息未保存,确定退出？", "警告！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void txtBoxIDCardNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBoxHomeTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBoxMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtBoxQQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 2)
                btnOK.Text = "下一步";
            else
                btnOK.Text = "确定";
        }
    }
}
