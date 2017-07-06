namespace 学生信息管理系统
{
    partial class NewStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewStudentForm));
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pBStudentImage = new System.Windows.Forms.PictureBox();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxIDCardNum = new System.Windows.Forms.TextBox();
            this.rdoBtnFemale = new System.Windows.Forms.RadioButton();
            this.rdoBtnMale = new System.Windows.Forms.RadioButton();
            this.dateTimePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.txtBoxNative = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtpEnterYear = new System.Windows.Forms.DateTimePicker();
            this.LableBoxStuType = new System.Windows.Forms.Label();
            this.txtBoxStuID = new System.Windows.Forms.TextBox();
            this.cmbBoxClass = new System.Windows.Forms.ComboBox();
            this.cmbBoxSpeciality = new System.Windows.Forms.ComboBox();
            this.cmbBoxCollege = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtBoxQQ = new System.Windows.Forms.TextBox();
            this.txtBoxMobile = new System.Windows.Forms.TextBox();
            this.txtBoxHomeTel = new System.Windows.Forms.TextBox();
            this.txtBoxHomeAdd = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBStudentImage)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pBStudentImage);
            this.tabPage1.Controls.Add(this.txtBoxName);
            this.tabPage1.Controls.Add(this.txtBoxIDCardNum);
            this.tabPage1.Controls.Add(this.rdoBtnFemale);
            this.tabPage1.Controls.Add(this.rdoBtnMale);
            this.tabPage1.Controls.Add(this.dateTimePickerBirth);
            this.tabPage1.Controls.Add(this.txtBoxNative);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pBStudentImage
            // 
            this.pBStudentImage.Image = ((System.Drawing.Image)(resources.GetObject("pBStudentImage.Image")));
            this.pBStudentImage.Location = new System.Drawing.Point(259, 6);
            this.pBStudentImage.Name = "pBStudentImage";
            this.pBStudentImage.Size = new System.Drawing.Size(197, 262);
            this.pBStudentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBStudentImage.TabIndex = 6;
            this.pBStudentImage.TabStop = false;
            this.pBStudentImage.DoubleClick += new System.EventHandler(this.pBStudentImage_DoubleClick);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(85, 60);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(100, 21);
            this.txtBoxName.TabIndex = 0;
            // 
            // txtBoxIDCardNum
            // 
            this.txtBoxIDCardNum.Location = new System.Drawing.Point(85, 100);
            this.txtBoxIDCardNum.MaxLength = 18;
            this.txtBoxIDCardNum.Name = "txtBoxIDCardNum";
            this.txtBoxIDCardNum.Size = new System.Drawing.Size(152, 21);
            this.txtBoxIDCardNum.TabIndex = 1;
            this.txtBoxIDCardNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxIDCardNum_KeyPress);
            // 
            // rdoBtnFemale
            // 
            this.rdoBtnFemale.AutoSize = true;
            this.rdoBtnFemale.Location = new System.Drawing.Point(150, 140);
            this.rdoBtnFemale.Name = "rdoBtnFemale";
            this.rdoBtnFemale.Size = new System.Drawing.Size(35, 16);
            this.rdoBtnFemale.TabIndex = 3;
            this.rdoBtnFemale.Text = "女";
            this.rdoBtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdoBtnMale
            // 
            this.rdoBtnMale.Checked = true;
            this.rdoBtnMale.Location = new System.Drawing.Point(85, 140);
            this.rdoBtnMale.Name = "rdoBtnMale";
            this.rdoBtnMale.Size = new System.Drawing.Size(35, 16);
            this.rdoBtnMale.TabIndex = 2;
            this.rdoBtnMale.TabStop = true;
            this.rdoBtnMale.Text = "男";
            this.rdoBtnMale.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBirth
            // 
            this.dateTimePickerBirth.Location = new System.Drawing.Point(85, 220);
            this.dateTimePickerBirth.Name = "dateTimePickerBirth";
            this.dateTimePickerBirth.Size = new System.Drawing.Size(152, 21);
            this.dateTimePickerBirth.TabIndex = 5;
            // 
            // txtBoxNative
            // 
            this.txtBoxNative.Location = new System.Drawing.Point(85, 180);
            this.txtBoxNative.Name = "txtBoxNative";
            this.txtBoxNative.Size = new System.Drawing.Size(100, 21);
            this.txtBoxNative.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "出生日期";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "籍贯";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "性别";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "身份证号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtpEnterYear);
            this.tabPage2.Controls.Add(this.LableBoxStuType);
            this.tabPage2.Controls.Add(this.txtBoxStuID);
            this.tabPage2.Controls.Add(this.cmbBoxClass);
            this.tabPage2.Controls.Add(this.cmbBoxSpeciality);
            this.tabPage2.Controls.Add(this.cmbBoxCollege);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "学籍信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtpEnterYear
            // 
            this.dtpEnterYear.Location = new System.Drawing.Point(85, 217);
            this.dtpEnterYear.Name = "dtpEnterYear";
            this.dtpEnterYear.Size = new System.Drawing.Size(152, 21);
            this.dtpEnterYear.TabIndex = 12;
            // 
            // LableBoxStuType
            // 
            this.LableBoxStuType.AutoSize = true;
            this.LableBoxStuType.Location = new System.Drawing.Point(229, 63);
            this.LableBoxStuType.Name = "LableBoxStuType";
            this.LableBoxStuType.Size = new System.Drawing.Size(29, 12);
            this.LableBoxStuType.TabIndex = 27;
            this.LableBoxStuType.Text = "学制";
            this.LableBoxStuType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBoxStuID
            // 
            this.txtBoxStuID.Location = new System.Drawing.Point(85, 180);
            this.txtBoxStuID.MaxLength = 15;
            this.txtBoxStuID.Name = "txtBoxStuID";
            this.txtBoxStuID.Size = new System.Drawing.Size(121, 21);
            this.txtBoxStuID.TabIndex = 11;
            this.txtBoxStuID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxStuID_KeyPress);
            // 
            // cmbBoxClass
            // 
            this.cmbBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxClass.FormattingEnabled = true;
            this.cmbBoxClass.Location = new System.Drawing.Point(85, 140);
            this.cmbBoxClass.Name = "cmbBoxClass";
            this.cmbBoxClass.Size = new System.Drawing.Size(121, 20);
            this.cmbBoxClass.TabIndex = 10;
            // 
            // cmbBoxSpeciality
            // 
            this.cmbBoxSpeciality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxSpeciality.FormattingEnabled = true;
            this.cmbBoxSpeciality.Location = new System.Drawing.Point(85, 100);
            this.cmbBoxSpeciality.Name = "cmbBoxSpeciality";
            this.cmbBoxSpeciality.Size = new System.Drawing.Size(121, 20);
            this.cmbBoxSpeciality.TabIndex = 9;
            this.cmbBoxSpeciality.SelectedIndexChanged += new System.EventHandler(this.cmbBoxSpeciality_SelectedIndexChanged);
            // 
            // cmbBoxCollege
            // 
            this.cmbBoxCollege.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxCollege.FormattingEnabled = true;
            this.cmbBoxCollege.Location = new System.Drawing.Point(85, 60);
            this.cmbBoxCollege.Name = "cmbBoxCollege";
            this.cmbBoxCollege.Size = new System.Drawing.Size(121, 20);
            this.cmbBoxCollege.TabIndex = 8;
            this.cmbBoxCollege.SelectedIndexChanged += new System.EventHandler(this.cmbBoxCollege_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "入学日期";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "学号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "班级";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "专业";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "学院";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtBoxQQ);
            this.tabPage3.Controls.Add(this.txtBoxMobile);
            this.tabPage3.Controls.Add(this.txtBoxHomeTel);
            this.tabPage3.Controls.Add(this.txtBoxHomeAdd);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(456, 270);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "联系方式";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtBoxQQ
            // 
            this.txtBoxQQ.Location = new System.Drawing.Point(85, 180);
            this.txtBoxQQ.Name = "txtBoxQQ";
            this.txtBoxQQ.Size = new System.Drawing.Size(100, 21);
            this.txtBoxQQ.TabIndex = 18;
            this.txtBoxQQ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxQQ_KeyPress);
            // 
            // txtBoxMobile
            // 
            this.txtBoxMobile.Location = new System.Drawing.Point(85, 140);
            this.txtBoxMobile.MaxLength = 11;
            this.txtBoxMobile.Name = "txtBoxMobile";
            this.txtBoxMobile.Size = new System.Drawing.Size(100, 21);
            this.txtBoxMobile.TabIndex = 17;
            this.txtBoxMobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxMobile_KeyPress);
            // 
            // txtBoxHomeTel
            // 
            this.txtBoxHomeTel.Location = new System.Drawing.Point(85, 100);
            this.txtBoxHomeTel.MaxLength = 8;
            this.txtBoxHomeTel.Name = "txtBoxHomeTel";
            this.txtBoxHomeTel.Size = new System.Drawing.Size(100, 21);
            this.txtBoxHomeTel.TabIndex = 16;
            this.txtBoxHomeTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxHomeTel_KeyPress);
            // 
            // txtBoxHomeAdd
            // 
            this.txtBoxHomeAdd.Location = new System.Drawing.Point(85, 60);
            this.txtBoxHomeAdd.Name = "txtBoxHomeAdd";
            this.txtBoxHomeAdd.Size = new System.Drawing.Size(100, 21);
            this.txtBoxHomeAdd.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 24;
            this.label15.Text = "QQ号码";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "手机号码";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "家庭电话";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "家庭住址";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 296);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 296);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 29);
            this.tableLayoutPanel1.TabIndex = 28;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Location = new System.Drawing.Point(378, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Location = new System.Drawing.Point(284, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 34;
            this.btnOK.Text = "下一步";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // NewStudentForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 325);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加学生信息";
            this.Load += new System.EventHandler(this.NewStudentForm_Load);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBStudentImage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtBoxQQ;
        private System.Windows.Forms.TextBox txtBoxMobile;
        private System.Windows.Forms.TextBox txtBoxHomeTel;
        private System.Windows.Forms.TextBox txtBoxHomeAdd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DateTimePicker dtpEnterYear;
        private System.Windows.Forms.Label LableBoxStuType;
        private System.Windows.Forms.TextBox txtBoxStuID;
        private System.Windows.Forms.ComboBox cmbBoxClass;
        private System.Windows.Forms.ComboBox cmbBoxSpeciality;
        private System.Windows.Forms.ComboBox cmbBoxCollege;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirth;
        private System.Windows.Forms.RadioButton rdoBtnFemale;
        private System.Windows.Forms.RadioButton rdoBtnMale;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxNative;
        private System.Windows.Forms.TextBox txtBoxIDCardNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.PictureBox pBStudentImage;

    }
}