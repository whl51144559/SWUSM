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
    public partial class OrgSetForm : Form
    {
        public OrgSetForm()
        {
            InitializeComponent();
        }

        private void OrgSetForm_Load(object sender, EventArgs e)
        {
            Bind_gridCollege();
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Bind_gridCollege();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                Bind_gridSpeciality();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                Bind_gridSpeYears();
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                Bind_gridSubjects();
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                Bind_gridTeachers();
            }
            else if (tabControl1.SelectedIndex == 5)
            {
                Bind_gridClasses();
            }
        }
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //删除学院
            if (tabControl1.SelectedIndex == 0)
            {
                try
                {
                    string sql = "delete from Colleges where College_ID=@0";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.gridCollege.SelectedRows[0].Cells["学院编号"].Value.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    Bind_gridCollege();
                }
                catch
                {
                    MessageBox.Show("该学院中有学生，删除失败");
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                try
                {
                    string sql = "Delete from Speciality where Speciality_ID=@0";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.gridSpeciatity.SelectedRows[0].Cells[0].Value);
                    if (i == 1)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    Bind_gridSpeciality();
                }
                catch
                {
                    MessageBox.Show("该专业中有学生，删除失败");
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                try
                {
                    string sql = "delete from SpeYears where SpeYears_id=@0";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.gridSpeYears.SelectedRows[0].Cells[0].Value.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    Bind_gridSpeYears();
                }
                catch
                {
                    MessageBox.Show("该学制中有学科，删除失败");
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                try
                {
                    string sql = "Delete from Subjects where Subjects_ID=@0";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.gridSubjects.SelectedRows[0].Cells[0].Value.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("删除成功!");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    Bind_gridSubjects();
                }
                catch
                {
                    MessageBox.Show("该学科中有学生，删除失败");
                }
            }
            else if (tabControl1.SelectedIndex == 4)
            {
                try
                {
                    string sql = "Delete from Teachers where Teacher_ID=@0";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.gridTeachers.SelectedRows[0].Cells[0].Value.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("删除成功！");
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                    Bind_gridTeachers();
                }
                catch
                {
                    MessageBox.Show("该班主任带有班级，删除失败");
                }

            }
            else if (tabControl1.SelectedIndex == 5)
            {
                try
                {
                    string sql = "Delete from Classes where Classes_ID=@0";
                    int i = DataBaseHelper.ExecNoneQuery(sql,this.gridClasses.SelectedRows[0].Cells[0].Value.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                    Bind_gridClasses();
                }
                catch
                {
                    MessageBox.Show("该班级下有学生，删除失败");
                }
            }
        }
        #region 学院页面
        void Bind_gridCollege()
        {
            
            string sql = "select College_ID as 学院编号,College_Name as 学院名称 from Colleges";
            DataTable dt = DataBaseHelper.ExecDataTable(sql);
            DataView view = dt.DefaultView;
            this.gridCollege.DataSource = dt;
            view.Sort = "学院编号";
        }
        private void BindCollegeInfo()
        {
            if (this.gridCollege.SelectedRows.Count == 0)
                return;
            this.txtCollegeID.Text = this.gridCollege.SelectedRows[0].Cells["学院编号"].Value.ToString();
            this.txtCollegeName.Text = this.gridCollege.SelectedRows[0].Cells["学院名称"].Value.ToString();

        }

        private void gridCollege_SelectionChanged(object sender, EventArgs e)
        {
            BindCollegeInfo();
            btnUpdateCollege.Visible = true;
            btnInsertCollege.Visible = true;
            btnUpdateCollege.Text = "点击修改";
            btnInsertCollege.Text = "点击添加";
            txtCollegeID.Enabled = false;
            txtCollegeName.Enabled = false;
        }

        private void btnInsertCollege_Click(object sender, EventArgs e)
        {
            if (btnInsertCollege.Text == "点击添加")
            {
                btnInsertCollege.Text = "添加学院";
                btnUpdateCollege.Text = "";
                btnUpdateCollege.Visible = false;
                txtCollegeID.Enabled = true;
                txtCollegeName.Enabled = true;
                txtCollegeID.Text = "";
                txtCollegeName.Text = "";
            }
            else
            {
                if (!CheckIDLenght(this.txtCollegeID, 2))
                    return;
                if (!CheckTextBoxValue(this.txtCollegeName, "学院名称"))
                    return;
                try
                {
                    string sql = "insert into Colleges values(@0,@1)";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.txtCollegeID.Text.Trim(), this.txtCollegeName.Text.Trim());
                    if (i == 1)
                    {
                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                    Bind_gridCollege();
                }
                catch
                {
                    MessageBox.Show("ID为" + this.txtCollegeID.Text.Trim() + "的编号已存在,请另选编号");
                }
            }
        }
        private void btnUpdateCollege_Click(object sender, EventArgs e)
        {
            if (btnUpdateCollege.Text == "点击修改")
            {
                btnUpdateCollege.Text = "修改学院";
                btnInsertCollege.Text = "";
                btnInsertCollege.Visible = false;
                txtCollegeID.Enabled = true;
                txtCollegeName.Enabled = true;
            }
            else
            {
                if (!CheckIDLenght(this.txtCollegeID, 2))
                    return;
                if (!CheckTextBoxValue(this.txtCollegeName, "学院名称"))
                    return;
                try
                {
                    string sql = "update Colleges set College_ID=@0,College_Name=@1 where College_ID=@2";
                    int i = DataBaseHelper.ExecNoneQuery(sql, this.txtCollegeID.Text.Trim(), this.txtCollegeName.Text.Trim(), this.gridCollege.SelectedRows[0].Cells["学院编号"].Value);
                    if (i == 1)
                        MessageBox.Show("修改成功！");
                    else
                        MessageBox.Show("修改失败！");
                    Bind_gridCollege();

                }
                catch
                {
                    MessageBox.Show("ID为" + this.txtCollegeID.Text.Trim() + "的编号已存在,请另选编号");
                }
            }
        }

        private void btnSearchCollege_Click(object sender, EventArgs e)
        {
            if (txtSearchValueCollege.Text.Trim() == "")
            {
                MessageBox.Show("请先输入要查找的值!");
                txtSearchValueCollege.Focus();
                return;
            }
            else if (this.cbbSearchTypeCollege.Text == "按照编号")
            {
                this.dataGridView_SearchKey(this.gridCollege, "学院编号",this.txtSearchValueCollege.Text.Trim());
            }
            else if (this.cbbSearchTypeCollege.Text == "按照名称")
            {
                this.dataGridView_SearchKey(this.gridCollege, "学院名称",this.txtSearchValueCollege.Text.Trim());
            }
            BindCollegeInfo();
        }

        

        #endregion
        #region 专业页面
        private void Bind_gridSpeciality()
        {
            string sql = "select Speciality_ID as 专业编号,Speciality_Name as 专业名称,Colleges.College_Name as 所属学院,SpeYears.SpeYears_Name as 学制 from Speciality join Colleges on Speciality.Speciality_College=Colleges.College_ID join SpeYears on Speciality.Speciality_Years=SpeYears.SpeYears_ID";
            this.gridSpeciatity.DataSource =DataBaseHelper.ExecDataTable(sql);
            DataView view = DataBaseHelper.ExecDataTable(sql).DefaultView;
            view.Sort = "专业编号";

            //给显示学院的下拉列表框控件绑定值
            string sql1 = "select College_ID,College_Name from Colleges";
            DataTable dt = DataBaseHelper.ExecDataTable(sql1);
            this.cbbCollege.DataSource = dt;
            this.cbbCollege.DisplayMember = "College_Name";
            this.cbbCollege.ValueMember = "College_ID";

            cbbCollege_SelectedIndexChanged(null, null);
            //给显示学制的下拉列表框控件绑定值
            string sql2 = "select SpeYears_ID,SpeYears_Name from SpeYears";
            DataTable dt1 = DataBaseHelper.ExecDataTable(sql2);
            this.cbbSpecYears.DataSource = dt1;
            this.cbbSpecYears.DisplayMember = "SpeYears_Name";
            this.cbbSpecYears.ValueMember = "SpeYears_ID";


        }
        private void BindSpecialityInfo()
        {
            if (this.gridSpeciatity.SelectedRows.Count == 0)
                return;
            this.cbbCollege.Text= this.gridSpeciatity.SelectedRows[0].Cells["所属学院"].Value.ToString();
            this.txtSpecialityID.Text =this.gridSpeciatity.SelectedRows[0].Cells["专业编号"].Value.ToString().Substring(2,2);
            this.txtSpecialityName.Text =this.gridSpeciatity.SelectedRows[0].Cells["专业名称"].Value.ToString();
            this.cbbSpecYears.Text =this.gridSpeciatity.SelectedRows[0].Cells["学制"].Value.ToString();
        }
        private void cbbCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSpecCollegeID.Text = this.cbbCollege.SelectedValue.ToString();
        }
        private void gridSpeciatity_SelectionChanged(object sender, EventArgs e)
        {
            BindSpecialityInfo();
            btnInsertSpec.Text = "点击添加";
            btnUpdateSpec.Text = "点击修改";
            btnInsertSpec.Visible = true;
            btnUpdateSpec.Visible = true;

            control_Enabled(false);
        }


        private void btnInsertSpec_Click(object sender, EventArgs e)
        {
            if (btnInsertSpec.Text == "点击添加")
            {
                control_Enabled(true);
                btnInsertSpec.Text = "添加专业";
                btnUpdateSpec.Visible = false;

                this.cbbCollege.Text= "";
                this.txtSpecialityID.Text ="";
                this.txtSpecialityName.Text ="";
                this.cbbSpecYears.Text = "";
            }
            else
            {
                if (!CheckIDLenght(this.txtSpecialityID,2))
                    return;
                if (!CheckTextBoxValue(this.txtSpecialityName, "专业名称"))
                    return;
                if (!CheckCbbValue(this.cbbCollege,"没有学院信息，请到'学院设置'添加学院！"))
                    return;
                if (!CheckCbbValue(this. cbbSpecYears, "没有学制信息，请到'学制设置'添加学制！"))
                    return;
                string SpecialityID = this.cbbCollege.SelectedValue.ToString() + this.txtSpecialityID.Text.Trim();
                try
                {
                    string sql = "insert into Speciality values(@0,@1,@2,@3)";

                    int i = DataBaseHelper.ExecNoneQuery(sql, SpecialityID, this.txtSpecialityName.Text.Trim(), this.cbbCollege.SelectedValue.ToString(), this.cbbSpecYears.SelectedValue.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                    Bind_gridSpeciality();
                }
                catch
                {
                    MessageBox.Show("ID为" + SpecialityID + "的编号已存在，请另选编号");
                }
            }

        }
        private void btnUpdateSpec_Click(object sender, EventArgs e)
        {
            if (btnUpdateSpec.Text == "点击修改")
            {
                btnInsertSpec.Visible = false;
                btnUpdateSpec.Text = "修改专业";
                control_Enabled(true);
            }
            else
            {
                if (!CheckIDLenght(this.txtSpecialityID, 2))
                return;
                if (!CheckTextBoxValue(this.txtSpecialityName, "专业名称"))
                    return;
                if (!CheckCbbValue(this.cbbCollege,"没有学院信息，请到'学院设置'添加学院！"))
                    return;
                if (!CheckCbbValue(this.cbbSpecYears, "没有学制信息，请到'学制设置'添加学制！"))
                    return;
                string SpecialityID = this.lbSpecCollegeID.Text +this.txtSpecialityID.Text.Trim();
                try
                {
                    string sql = "update Speciality set Speciality_ID=@0,Speciality_Name=@1,Speciality_College=@2,Speciality_Years=@3 where Speciality_ID=@4";
                    int i = DataBaseHelper.ExecNoneQuery(sql, SpecialityID,this.txtSpecialityName.Text.Trim(), this.cbbCollege.SelectedValue.ToString(),this.cbbSpecYears.SelectedValue.ToString(),this.gridSpeciatity.SelectedRows[0].Cells["专业编号"].Value);
                    if (i == 1)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                    Bind_gridSpeciality();
                }
                catch
                {
                    MessageBox.Show("ID为" + SpecialityID + "的编号已存在，请另选编号");
                }
            }
        }
        private void btnSearchSpec_Click(object sender, EventArgs e)
        {
            if (txtSearchValueSpec.Text.Trim() == "")
            {
                MessageBox.Show("请先输入要查找的值!");
                txtSearchValueSpec.Focus();
                return;
            }
            else if (this.cbbSearchTypeSpec.Text == "按照编号")
            {
                this.dataGridView_SearchKey(this.gridSpeciatity, "专业编号",this.txtSearchValueSpec.Text.Trim());
            }
            else if (this.cbbSearchTypeSpec.Text == "按照名称")
            {
                this.dataGridView_SearchKey(this.gridSpeciatity, "专业名称",this.txtSearchValueSpec.Text.Trim());
            }
            BindCollegeInfo();
        }
        private void linkSetSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SetSubject ssb = new SetSubject();
            SetSubject ssb = new SetSubject(this.gridSpeciatity.SelectedRows[0].Cells["专业编号"].Value.ToString(), this.gridSpeciatity.SelectedRows[0].Cells["专业名称"].Value.ToString(),this.cbbCollege.Text);
            ssb.Owner = this;
            ssb.ShowDialog();
        }
        #endregion
        #region 学制页面
        private void Bind_gridSpeYears()
        {
            string sql = "select SpeYears_ID as 学制编号,SpeYears_Name as 学制名称,SpeYears_Years as 学制时间 from SpeYears";
            this.gridSpeYears.DataSource =DataBaseHelper.ExecDataTable(sql);
            DataView view = DataBaseHelper.ExecDataTable(sql).DefaultView;
            view.Sort = "学制编号";
        }
        private void gridSpeYears_SelectionChanged(object sender, EventArgs e)
        {
            if (gridSpeYears.SelectedRows.Count == 0)
                return;
            txtSpecName.Text = gridSpeYears.SelectedRows[0].Cells["学制名称"].Value.ToString();
            txtSpecYear.Text = gridSpeYears.SelectedRows[0].Cells["学制时间"].Value.ToString();
            txtSpecName.Enabled = false;
            txtSpecYear.Enabled = false;
            btnSpeYears.Text = "点击添加";
        }
        private void btnSpeYears_Click(object sender,EventArgs e)
        {
            if (btnSpeYears.Text == "点击添加")
            {
                txtSpecName.Enabled = true;
                txtSpecYear.Enabled = true;
                btnSpeYears.Text = "添加学制";
                txtSpecName.Text="";
                txtSpecYear.Text = "";
            }
            else
            {
                if (!CheckTextBoxValue(this.txtSpecName, "学制名称"))
                    return;
                if (!CheckTextBoxValue(this.txtSpecYear, "学制时间"))
                    return;
                string sql = "insert into SpeYears values(@0,@1)";
                int i = DataBaseHelper.ExecNoneQuery(sql, this.txtSpecName.Text.Trim(), this.txtSpecYear.Text.Trim());
                if (i == 1)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
                Bind_gridSpeYears();
            }
        }
        #endregion
        #region 学科页面
        private void Bind_gridSubjects()
        {
            string sql = "select Subjects_ID as 学科编号,Subjects_Name as 学科名称 from Subjects";
            this.gridSubjects.DataSource =DataBaseHelper.ExecDataTable(sql);
            DataView view = DataBaseHelper.ExecDataTable(sql).DefaultView;
            view.Sort = "学科编号";
        }
        private void btnInsertSubject_Click(object sender, EventArgs e)
        {
            if (btnInsertSubject.Text == "点击添加")
            {
                btnInsertSubject.Text = "添加学科";
                txtSubjectName.Enabled = true;
                txtSubjectName.Text = "";
            }
            else
            {
                if (!CheckTextBoxValue(this.txtSubjectName, "学科名称"))
                    return;
                string sql = "insert into Subjects values(@0)";
                int i = DataBaseHelper.ExecNoneQuery(sql, this.txtSubjectName.Text.Trim());
                if (i == 1)
                {
                    MessageBox.Show("添加成功!");
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
                Bind_gridSubjects();
            }
        }
        private void gridSubjects_SelectionChanged(object sender, EventArgs e)
        {

            if (gridSubjects.SelectedRows.Count == 0)
                return;
            txtSubjectName.Text = gridSubjects.SelectedRows[0].Cells["学科名称"].Value.ToString();
            txtSubjectName.Enabled = false;
            btnInsertSubject.Text = "点击添加";
        }

        #endregion
        #region 班主任页面
        private void Bind_gridTeachers()
        {
            string sql="select Teacher_ID as 编号,Teacher_Name as 姓名,Teacher_Tel as 电话,Teacher_Sex as 性别,Teacher_Indate 入职日期,Teacher_Birthday as 出生日期,Teacher_Origin as 籍贯 from Teachers";
            this.gridTeachers.DataSource =DataBaseHelper.ExecDataTable(sql);
            DataView view = DataBaseHelper.ExecDataTable(sql).DefaultView;
            view.Sort = "编号";
        }
        private void BindTeachersInfo()
        {
            if (this.gridTeachers.SelectedRows.Count == 0)
                return;
            this.txtTeaName.Text = this.gridTeachers.SelectedRows[0].Cells["姓名"].Value.ToString();
            this.txtTel.Text = this.gridTeachers.SelectedRows[0].Cells["电话"].Value.ToString();
            this.cbbSex.Text = this.gridTeachers.SelectedRows[0].Cells["性别"].Value.ToString();
            this.dtpInTime.Value = (DateTime)this.gridTeachers.SelectedRows[0].Cells["入职日期"].Value;
            this.dtpBirthday.Value =(DateTime)this.gridTeachers.SelectedRows[0].Cells["出生日期"].Value;
            this.txtOrgin.Text = this.gridTeachers.SelectedRows[0].Cells["籍贯"].Value.ToString();
        }
        private void gridTeachers_SelectionChanged(object sender,EventArgs e)
        {
            BindTeachersInfo();
            this.txtTeaName.Enabled=false;
            this.txtTel.Enabled=false;
            this.cbbSex.Enabled=false;
            this.dtpInTime.Enabled=false;
            this.dtpBirthday.Enabled=false;
            this.txtOrgin.Enabled = false;
            btnUpdateTeacher.Text="点击修改";
            btnInsertTeacher.Text = "点击添加";
        }
        //添加
        private void btnInsertTeacher_Click(object sender, EventArgs e)
        {
            if (btnInsertTeacher.Text == "点击添加")
            {
                btnUpdateTeacher.Visible = false;
                btnInsertTeacher.Text = "添加班主任";

                this.txtTeaName.Enabled = true;
                this.txtTel.Enabled = true;
                this.cbbSex.Enabled = true;
                this.dtpInTime.Enabled = true;
                this.dtpBirthday.Enabled = true;
                this.txtOrgin.Enabled = true;

                this.txtTeaName.Text = "";
                this.txtTel.Text = "";
                this.cbbSex.Text = "";
                this.dtpInTime.Value = DateTime.Now;
                this.dtpBirthday.Value = DateTime.Now;
                this.txtOrgin.Text = "";
            }
            else
            {
                if (!CheckTextBoxValue(this.txtTeaName, "班主任名称"))
                    return;
                if (!CheckTextBoxValue(this.txtTel, "电话"))
                return;
                if (!CheckTextBoxValue(this.txtOrgin, "籍贯"))
                    return;
                string sql = "insert into Teachers values(@0,@1,@2,@3,@4,@5)";
                string dtb = dtpBirthday.Value.ToString("yyyy-MM-dd");
                string dti = dtpInTime.Value.ToString("yyyy-MM-dd");
                //int i = DataBaseHelper.ExecNoneQuery(sql,this.txtTeaName.Text.Trim(), this.txtTel.Text, this.cbbSex.Text.Trim(),this.dtpInTime.Value, this.dtpBirthday.Value, this.txtOrgin.Text.Trim());
                int i = DataBaseHelper.ExecNoneQuery(sql, this.txtTeaName.Text.Trim(), this.txtTel.Text, this.cbbSex.Text.Trim(), dti, dtb, this.txtOrgin.Text.Trim());
                if (i == 1)
                {
                    MessageBox.Show("添加成功！");
                }
                else
                {
                    MessageBox.Show("添加失败!");
                }
                Bind_gridTeachers();
            }
        }
        private void btnUpdateTeacher_Click(object sender, EventArgs e)
        {
            if (btnUpdateTeacher.Text == "点击修改")
            {
                btnInsertTeacher.Visible= false;
                btnUpdateTeacher.Text = "修改班主任";

                this.txtTeaName.Enabled = true;
                this.txtTel.Enabled = true;
                this.cbbSex.Enabled = true;
                this.dtpInTime.Enabled = true;
                this.dtpBirthday.Enabled = true;
                this.txtOrgin.Enabled = true;
            }
            else
            {
                if (!CheckTextBoxValue(this.txtTeaName, "班主任名称"))
                    return;
                if (!CheckTextBoxValue(this.txtTel, "电话"))
                    return;
                if (!CheckTextBoxValue(this.txtOrgin, "籍贯"))
                    return;
                string sql = "update Teachers set Teacher_Name=@0,Teacher_Tel=@1,Teacher_Sex=@2,Teacher_InDate=@3,Teacher_Birthday=@4,Teacher_Origin=@5 where Teacher_ID=@6";
                string dtb = dtpBirthday.Value.ToString("yyyy-MM-dd");
                string dti = dtpInTime.Value.ToString("yyyy-MM-dd");
                int i = DataBaseHelper.ExecNoneQuery(sql,this.txtTeaName.Text.Trim(), this.txtTel.Text, this.cbbSex.Text,dti,dtb, this.txtOrgin.Text.Trim(),(int)this.gridTeachers.SelectedRows[0].Cells[0].Value);
                if (i == 1)
                {
                    MessageBox.Show("修改成功！");
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
                Bind_gridTeachers();
            }
        }


        #endregion
        #region 班级页面
        private void Bind_gridClasses()
        {
            string sql = "select Classes_ID as 班级编号,Classes_Name as 班级名称,Classes_Speciality as 所属专业编号,Speciality_Name as 专业名称,Teacher_Name as 班主任 from Classes join Speciality on Classes.Classes_Speciality=Speciality.Speciality_ID join Teachers on Classes.ClassHeadTeacher=Teachers.Teacher_ID";
            DataTable dt= DataBaseHelper.ExecDataTable(sql);
            this.gridClasses.DataSource = dt;
            //this.gridClasses.Columns[2].Visible = false;
            Bind_cbbClassCollege();
            Bind_cbbTeachers();
        }
        private void Bind_cbbClassCollege()
        {
            string sql1 = "select College_ID,College_Name from Colleges";
            this.cbbClassCollege.DataSource =DataBaseHelper.ExecDataTable(sql1);
            this.cbbClassCollege.DisplayMember = "College_Name";
            this.cbbClassCollege.ValueMember = "College_ID";
            Bind_cbbClassSpeciality(this.cbbClassCollege.SelectedValue.ToString());
        }
        private void Bind_cbbTeachers()
        {
            string sql2 = "select Teacher_ID,Teacher_Name from Teachers";
            this.cbbTeachers.DataSource =DataBaseHelper.ExecDataTable(sql2);
            this.cbbTeachers.DisplayMember = "Teacher_Name";
            this.cbbTeachers.ValueMember = "Teacher_ID";
        }
        private void Bind_cbbClassSpeciality(string param)
        {
            string sql2 = "select Speciality_ID,Speciality_Name from Speciality where Speciality_College=@0";
            this.cbbClassSpeciality.DataSource =DataBaseHelper.ExecDataTable(sql2, param);
            this.cbbClassSpeciality.DisplayMember = "Speciality_Name";
            this.cbbClassSpeciality.ValueMember = "Speciality_ID";
        }
        private void cbbClassCollege_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_cbbClassSpeciality(this.cbbClassCollege.SelectedValue.ToString());
            if (this.cbbClassSpeciality.Items.Count == 0)
                this.lbClassIDCollegeSpec.Text = "";
        }
        private void cbbClassSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbClassIDCollegeSpec.Text = cbbClassCollege.SelectedValue.ToString()+cbbClassSpeciality.SelectedValue.ToString().Substring(2, 2);
        }
        private void gridClasses_SelectionChanged(object sender, EventArgs e)
        {
            BindClassesInfo();
        }
        private void BindClassesInfo()
        {
            if (this.gridClasses.SelectedRows.Count == 0)
            {
                return;
            }
            if (this.gridClasses.SelectedRows.Count==0)
            {
                return;
            }
            this.cbbClassCollege.SelectedValue =this.gridClasses.SelectedRows[0].Cells["所属专业编号"].Value.ToString().Substring(0, 2);
            this.cbbClassSpeciality.SelectedValue =this.gridClasses.SelectedRows[0].Cells["所属专业编号"].Value;
            this.txtClassID.Text = this.gridClasses.SelectedRows[0].Cells["班级编号"].Value.ToString().Substring(4,4);
            this.txtClassName.Text = this.gridClasses.SelectedRows[0].Cells["班级名称"].Value.ToString();
            this.cbbTeachers.Text = this.gridClasses.SelectedRows[0].Cells["班主任"].Value.ToString();
                

            this.cbbClassCollege.Enabled=false;
            this.cbbClassSpeciality.Enabled=false;
            this.txtClassID.Enabled=false;
            this.txtClassName.Enabled=false;
            this.cbbTeachers.Enabled = false;
            btnInsertClass.Text = "点击添加";
            btnUpdateClass.Text = "点击修改";
            btnInsertClass.Visible = true;
            btnUpdateClass.Visible = true;
        }
        private void btnInsertClass_Click(object sender, EventArgs e)
        {
            if (btnInsertClass.Text == "点击添加")
            {
                if (this.cbbClassCollege.Items.Count != 0)
                {
                    this.cbbClassCollege.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("警告！数据库中还没有学院的记录，请到’学院设置’添加学院");
                }
                if (this.cbbClassSpeciality.Items.Count != 0)
                {
                    this.cbbClassSpeciality.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("警告！数据库中" + this.cbbClassCollege.Text + "还没有添加专业的记录，请到专业设置添加");
                }
                if (this.cbbTeachers.Items.Count != 0)
                {
                    this.cbbTeachers.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("警告！数据库中还没有班主任的记录，请到学院设置添加班主任");
                }

                btnInsertClass.Text = "添加班级";
                btnUpdateClass.Visible = false;
                this.cbbClassCollege.Enabled = true;
                this.cbbClassSpeciality.Enabled = true;
                this.txtClassID.Enabled = true;
                this.txtClassName.Enabled = true;
                this.cbbTeachers.Enabled = true;

                this.cbbClassCollege.SelectedIndex = 0;
                this.cbbClassSpeciality.SelectedIndex = 0;
                this.txtClassID.Text = "";
                this.txtClassName.Text = "";
                this.cbbTeachers.SelectedIndex = 0;
            }
            else
            {
                if (!CheckIDLenght(this.txtClassID, 4))
                    return;
                if (!CheckTextBoxValue(this.txtClassName, "班级名称"))
                    return;
                if (!CheckCbbValue(this.cbbClassCollege, "没有学院信息，请到'学院设置'添加学院！"))
                    return;
                if (!CheckCbbValue(this.cbbClassSpeciality, "没有专业信息，请到'专业设置'添加专业！"))
                    return;
                if (!CheckCbbValue(this.cbbTeachers, "没有班主任信息，请到'班主任设置'添加班主任！"))
                    return;
                string ClassID = lbClassIDCollegeSpec.Text +this.txtClassID.Text.Trim();
                try
                {
                    string sql = "insert into Classes(Classes_ID,Classes_Name,Classes_Speciality,ClassHeadTeacher) values(@0,@1,@2,@3)";
                    int i = DataBaseHelper.ExecNoneQuery(sql, ClassID, this.txtClassName.Text.Trim(), lbClassIDCollegeSpec.Text, this.cbbTeachers.SelectedValue.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                    Bind_gridClasses();
                }
                catch
                {
                    MessageBox.Show("ID为" + ClassID + "的编号已存在，请另选编号");
                }
            }
        }
        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            if (btnUpdateClass.Text == "点击修改")
            {
                btnUpdateClass.Text = "修改班级";
                btnInsertClass.Visible = false;
                this.cbbClassCollege.Enabled = true;
                this.cbbClassSpeciality.Enabled = true;
                this.txtClassID.Enabled = true;
                this.txtClassName.Enabled = true;
                this.cbbTeachers.Enabled = true;
            }
            else
            {
                if (!CheckIDLenght(this.txtClassID, 4))
                    return;
                if (!CheckTextBoxValue(this.txtClassName, "班级名称"))
                    return;
                string ClassID = this.lbClassIDCollegeSpec.Text + this.txtClassID.Text.Trim();
                try
                {
                    string sql = "update Classes set Classes_ID=@0,Classes_Name=@1,Classes_Speciality=@2,ClassHeadTeacher=@3 where Classes_ID=@4";
                    int i = DataBaseHelper.ExecNoneQuery(sql, ClassID, this.txtClassName.Text.Trim(), lbClassIDCollegeSpec.Text, this.cbbTeachers.SelectedValue.ToString(), this.gridClasses.SelectedRows[0].Cells[0].Value.ToString());
                    if (i == 1)
                    {
                        MessageBox.Show("修改成功！");
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                    Bind_gridClasses();
                }
                catch
                {
                    MessageBox.Show("ID为" + ClassID + "的编号已存在，请另选编号");
                }
            }

        }
        #endregion
        #region 查询通用方法
        private void dataGridView_SearchKey(DataGridView dgv, string ColumnName, string Value)
        {
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                if (dgvr.Cells[ColumnName].Value.ToString() == Value)
                {
                    dataGridView_UnSelectAll(dgv);
                    dgvr.Selected = true;
                    dgv.CurrentCell = dgvr.Cells[0];
                    return;
                }
            }
            MessageBox.Show("没有查找到符合要求的内容。");
        }
        private void dataGridView_UnSelectAll(DataGridView dgv)
        {
            foreach (DataGridViewRow dgvr in dgv.SelectedRows)
            {
                dgvr.Selected = false;
            }
        }
        #region 检测用户输入ID是否合法的通用方法
        private bool CheckIDLenght(TextBox tb, int length)
        {
            if (tb.Text.Trim().Length != length)
            {
                string msg = String.Format("您输入ID长度必须等于{0}位", length);
                MessageBox.Show(msg);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region 检测TextBox中值是否为空的通用方法
        private bool CheckTextBoxValue(TextBox tb, string valuename)
        {
            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                string msg = String.Format("请输入{0}!", valuename);
                MessageBox.Show(msg);
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region 检测用户在ComboBox中选中的值是否为空
        private bool CheckCbbValue(ComboBox cbb, string message)
        {
            if (string.IsNullOrEmpty(cbb.Text))
            {
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }
        #region 控件可用性
        void control_Enabled(bool bl)
        {
            if (bl == true)
            {
                this.cbbCollege.Enabled = true;
                this.txtSpecialityID.Enabled = true;
                this.txtSpecialityName.Enabled = true;
                this.cbbSpecYears.Enabled = true;
            }
            else
            {
                this.cbbCollege.Enabled = false;
                this.txtSpecialityID.Enabled = false;
                this.txtSpecialityName.Enabled = false;
                this.cbbSpecYears.Enabled = false;
            }

        }        

        #endregion

        #endregion
        #endregion

        














    }
}
