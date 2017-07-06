namespace 学生信息管理系统
{
    partial class TypesSetForm
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
            this.components = new System.ComponentModel.Container();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbSearchTypeCol = new System.Windows.Forms.ComboBox();
            this.txtSearchValueCol = new System.Windows.Forms.TextBox();
            this.btnSearchCollege = new System.Windows.Forms.Button();
            this.btnInsertCollege = new System.Windows.Forms.Button();
            this.txtCollegeID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCollegeName = new System.Windows.Forms.TextBox();
            this.btnUpdateCollege = new System.Windows.Forms.Button();
            this.linkAddCollege = new System.Windows.Forms.LinkLabel();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridPunishmentAwards = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbPunishmentAwards = new System.Windows.Forms.ComboBox();
            this.txtPunishmentAwards = new System.Windows.Forms.TextBox();
            this.btnAddPA = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridXueJi = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtXueJiName = new System.Windows.Forms.TextBox();
            this.btnIAdd = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPunishmentAwards)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridXueJi)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            // 
            // cbbSearchTypeCol
            // 
            this.cbbSearchTypeCol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSearchTypeCol.FormattingEnabled = true;
            this.cbbSearchTypeCol.Items.AddRange(new object[] {
            "按照编号",
            "按照名称"});
            this.cbbSearchTypeCol.Location = new System.Drawing.Point(74, 24);
            this.cbbSearchTypeCol.Name = "cbbSearchTypeCol";
            this.cbbSearchTypeCol.Size = new System.Drawing.Size(121, 20);
            this.cbbSearchTypeCol.TabIndex = 10;
            // 
            // txtSearchValueCol
            // 
            this.txtSearchValueCol.Location = new System.Drawing.Point(201, 24);
            this.txtSearchValueCol.Name = "txtSearchValueCol";
            this.txtSearchValueCol.Size = new System.Drawing.Size(100, 21);
            this.txtSearchValueCol.TabIndex = 11;
            // 
            // btnSearchCollege
            // 
            this.btnSearchCollege.Location = new System.Drawing.Point(335, 24);
            this.btnSearchCollege.Name = "btnSearchCollege";
            this.btnSearchCollege.Size = new System.Drawing.Size(75, 23);
            this.btnSearchCollege.TabIndex = 12;
            this.btnSearchCollege.Text = "查找";
            this.btnSearchCollege.UseVisualStyleBackColor = true;
            // 
            // btnInsertCollege
            // 
            this.btnInsertCollege.Location = new System.Drawing.Point(335, 53);
            this.btnInsertCollege.Name = "btnInsertCollege";
            this.btnInsertCollege.Size = new System.Drawing.Size(75, 23);
            this.btnInsertCollege.TabIndex = 2;
            this.btnInsertCollege.Text = "添加";
            this.btnInsertCollege.UseVisualStyleBackColor = true;
            this.btnInsertCollege.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCollegeID
            // 
            this.txtCollegeID.Location = new System.Drawing.Point(74, 26);
            this.txtCollegeID.Name = "txtCollegeID";
            this.txtCollegeID.Size = new System.Drawing.Size(227, 21);
            this.txtCollegeID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            // 
            // txtCollegeName
            // 
            this.txtCollegeName.Location = new System.Drawing.Point(74, 53);
            this.txtCollegeName.Name = "txtCollegeName";
            this.txtCollegeName.Size = new System.Drawing.Size(227, 21);
            this.txtCollegeName.TabIndex = 6;
            // 
            // btnUpdateCollege
            // 
            this.btnUpdateCollege.Location = new System.Drawing.Point(335, 24);
            this.btnUpdateCollege.Name = "btnUpdateCollege";
            this.btnUpdateCollege.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateCollege.TabIndex = 7;
            this.btnUpdateCollege.Text = "修改";
            this.btnUpdateCollege.UseVisualStyleBackColor = true;
            // 
            // linkAddCollege
            // 
            this.linkAddCollege.AutoSize = true;
            this.linkAddCollege.Location = new System.Drawing.Point(414, 58);
            this.linkAddCollege.Name = "linkAddCollege";
            this.linkAddCollege.Size = new System.Drawing.Size(53, 12);
            this.linkAddCollege.TabIndex = 8;
            this.linkAddCollege.TabStop = true;
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.gridPunishmentAwards);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 335);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "奖惩类型设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridPunishmentAwards
            // 
            this.gridPunishmentAwards.AllowUserToAddRows = false;
            this.gridPunishmentAwards.AllowUserToDeleteRows = false;
            this.gridPunishmentAwards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPunishmentAwards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPunishmentAwards.ContextMenuStrip = this.contextMenuStrip1;
            this.gridPunishmentAwards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPunishmentAwards.Location = new System.Drawing.Point(3, 3);
            this.gridPunishmentAwards.Name = "gridPunishmentAwards";
            this.gridPunishmentAwards.ReadOnly = true;
            this.gridPunishmentAwards.RowTemplate.Height = 23;
            this.gridPunishmentAwards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPunishmentAwards.Size = new System.Drawing.Size(470, 329);
            this.gridPunishmentAwards.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btnAddPA);
            this.groupBox4.Controls.Add(this.txtPunishmentAwards);
            this.groupBox4.Controls.Add(this.cbbPunishmentAwards);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 278);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(470, 54);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "添加";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "奖惩类型";
            // 
            // cbbPunishmentAwards
            // 
            this.cbbPunishmentAwards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPunishmentAwards.FormattingEnabled = true;
            this.cbbPunishmentAwards.Items.AddRange(new object[] {
            "奖励",
            "惩罚"});
            this.cbbPunishmentAwards.Location = new System.Drawing.Point(65, 24);
            this.cbbPunishmentAwards.Name = "cbbPunishmentAwards";
            this.cbbPunishmentAwards.Size = new System.Drawing.Size(82, 20);
            this.cbbPunishmentAwards.TabIndex = 10;
            // 
            // txtPunishmentAwards
            // 
            this.txtPunishmentAwards.Location = new System.Drawing.Point(212, 24);
            this.txtPunishmentAwards.Name = "txtPunishmentAwards";
            this.txtPunishmentAwards.Size = new System.Drawing.Size(174, 21);
            this.txtPunishmentAwards.TabIndex = 11;
            // 
            // btnAddPA
            // 
            this.btnAddPA.Location = new System.Drawing.Point(392, 22);
            this.btnAddPA.Name = "btnAddPA";
            this.btnAddPA.Size = new System.Drawing.Size(75, 23);
            this.btnAddPA.TabIndex = 12;
            this.btnAddPA.Text = "添加";
            this.btnAddPA.UseVisualStyleBackColor = true;
            this.btnAddPA.Click += new System.EventHandler(this.btnAddPA_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "奖惩名称";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.gridXueJi);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 335);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "学籍变动类型设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridXueJi
            // 
            this.gridXueJi.AllowUserToAddRows = false;
            this.gridXueJi.AllowUserToDeleteRows = false;
            this.gridXueJi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridXueJi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridXueJi.ContextMenuStrip = this.contextMenuStrip1;
            this.gridXueJi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridXueJi.Location = new System.Drawing.Point(3, 3);
            this.gridXueJi.Name = "gridXueJi";
            this.gridXueJi.ReadOnly = true;
            this.gridXueJi.RowTemplate.Height = 23;
            this.gridXueJi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridXueJi.Size = new System.Drawing.Size(470, 329);
            this.gridXueJi.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIAdd);
            this.groupBox2.Controls.Add(this.txtXueJiName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "添加";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "学籍变动类型名称";
            // 
            // txtXueJiName
            // 
            this.txtXueJiName.Location = new System.Drawing.Point(113, 24);
            this.txtXueJiName.Name = "txtXueJiName";
            this.txtXueJiName.Size = new System.Drawing.Size(270, 21);
            this.txtXueJiName.TabIndex = 14;
            // 
            // btnIAdd
            // 
            this.btnIAdd.Location = new System.Drawing.Point(392, 22);
            this.btnIAdd.Name = "btnIAdd";
            this.btnIAdd.Size = new System.Drawing.Size(75, 23);
            this.btnIAdd.TabIndex = 15;
            this.btnIAdd.Text = "添加";
            this.btnIAdd.UseVisualStyleBackColor = true;
            this.btnIAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 361);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // TypesSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypesSetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "类型参数设置";
            this.Load += new System.EventHandler(this.TypesSetForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPunishmentAwards)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridXueJi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbSearchTypeCol;
        private System.Windows.Forms.TextBox txtSearchValueCol;
        private System.Windows.Forms.Button btnSearchCollege;
        private System.Windows.Forms.Button btnInsertCollege;
        private System.Windows.Forms.TextBox txtCollegeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCollegeName;
        private System.Windows.Forms.Button btnUpdateCollege;
        private System.Windows.Forms.LinkLabel linkAddCollege;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPA;
        private System.Windows.Forms.TextBox txtPunishmentAwards;
        private System.Windows.Forms.ComboBox cbbPunishmentAwards;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridPunishmentAwards;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIAdd;
        private System.Windows.Forms.TextBox txtXueJiName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridXueJi;
        private System.Windows.Forms.TabControl tabControl1;
    }
}