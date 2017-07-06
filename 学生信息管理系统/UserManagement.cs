using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生信息管理系统
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
            tPEdit.Parent = null;
        }

        #region 添加管理员
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPwd.Text.Trim()))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            //判断此管理员名是否已存在
            string sql = "select Admin_Name from AdminInfo where Admin_Name=@0";
            SqlDataReader sdr = DataBaseHelper.ExecReader(sql, this.txtUserName.Text.Trim());
            if (sdr.Read())
            {
                MessageBox.Show("此用户名已存在！");
                return;
            }
            sdr.Close();

            //添加管理员
            if (this.txtPwd.Text.Trim()!=this.txtRePwd.Text.Trim())
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            string sql1 = "insert into AdminInfo (Admin_Name,Admin_Password,Admin_Level, Admin_Rember , Admin_AutoLogin) values(@0,@1,@2,@3,@4)";
            int i = DataBaseHelper.ExecNoneQuery(sql1, this.txtUserName.Text.Trim(), this.txtPwd.Text.Trim(), this.cbbLevel.SelectedIndex, checkBox1.Checked ? "1" : "0", checkBox2.Checked ? "1" : "0");
            if (i == 1)
            {
                MessageBox.Show("添加用户成功！");
            }
            else
            {
                MessageBox.Show("添加用户失败！");
            }
            this.txtUserName.Text = "";
            this.txtPwd.Text = "";
            this.txtRePwd.Text = "";
            this.cbbLevel.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                this.txtUserName.Text = "";
                this.txtPwd.Text = "";
                this.txtRePwd.Text = "";
                this.cbbLevel.SelectedIndex = 0;
                checkBox1.Checked = false;
            }
            else
            {
                this.txtName.Text = "";
                this.txtPassword.Text = "";
                this.txtPassword2.Text = "";
                this.cmbLevel.SelectedIndex = 0;
                cBremeber.Checked = false;
            }    
        }
        #endregion
        #region 编辑管理员
        DataTable dt;
        int adminID;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }

            //判断此管理员名是否已存在
            if (txtName.Enabled)
            {
                string sql = "select Admin_Name from AdminInfo where Admin_Name=@0";
                SqlDataReader sdr = DataBaseHelper.ExecReader(sql, this.txtName.Text.Trim());
                if (sdr.Read())
                {
                    MessageBox.Show("此用户名已存在！");
                    return;
                }
                sdr.Close();
            }

            //保存更改
            if (this.txtPassword.Text.Trim() != this.txtPassword2.Text.Trim())
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            string sql1 = "update AdminInfo set Admin_Name=@0,Admin_Password=@1,Admin_Level=@2, Admin_Rember=@3 , Admin_AutoLogin=@4 where Admin_ID=@5";
            int i = DataBaseHelper.ExecNoneQuery(sql1, this.txtName.Text.Trim(), this.txtPassword.Text.Trim(), this.cmbLevel.SelectedIndex, cBremeber.Checked ? "1" : "0", cBauto.Checked ? "1" : "0",adminID);
            if (i == 1)
            {
                MessageBox.Show("更新用户成功！");
            }
            else
            {
                MessageBox.Show("更新用户失败！");
            }
        }
        private void Edit_Admin()
        {
            adminID = (int)this.gridAdmin.SelectedRows[0].Cells["管理员编号"].Value;
            string sql = "select * from AdminInfo where Admin_ID=@0 ";
            dt = DataBaseHelper.ExecDataTable(sql, adminID);
            DataRow row = dt.Rows[0];

            txtName.Text = row["Admin_Name"].ToString();
            txtPassword.Text = row["Admin_Password"].ToString();
            txtPassword2.Text = row["Admin_Password"].ToString();

            this.cmbLevel.SelectedIndex = Convert.ToInt32(row["Admin_Level"].ToString());
            if (row["Admin_Rember"].ToString() == "True")
                cBremeber.Checked = true;
            if (row["Admin_AutoLogin"].ToString() == "True")
                cBauto.Checked = true;
        }
        #endregion
        #region 查看管理员
        private void Bind_gridAdmin()
        {
            string sql = "select Admin_ID as 管理员编号,Admin_Name as 管理员姓名,Admin_Level as 权限等级, Admin_Rember as 记住密码 , Admin_AutoLogin as 自动登录  from AdminInfo";
            this.gridAdmin.DataSource = DataBaseHelper.ExecDataTable(sql);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mf = (MainForm)this.Owner;
            if ((int)this.gridAdmin.SelectedRows[0].Cells["管理员编号"].Value == mf.adminID)
            {
                MessageBox.Show("您无权删除此管理员！");
                return;
            }
            string sql = "delete from AdminInfo where Admin_ID=@0";
            int i = DataBaseHelper.ExecNoneQuery(sql,(int)this.gridAdmin.CurrentRow.Cells[0].Value);
            if (i == 1)
            {
                MessageBox.Show("删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            Bind_gridAdmin();
        }
        //
        #endregion
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "查看管理员")
                Bind_gridAdmin();
            else if (e.TabPage.Text == "编辑管理员")
                Edit_Admin();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.tPEdit.Parent = this.tabControl1;
            this.tabControl1.SelectedIndex = 2;
            
        }

        private void cBauto_CheckedChanged(object sender, EventArgs e)
        {
            if (cBauto.Checked)
                cBremeber.Checked = true;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = true;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtName.Enabled = true;
        }

        private void cBremeber_CheckedChanged(object sender, EventArgs e)
        {
            if (!cBremeber.Checked)
                cBauto.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                checkBox2.Checked = false;
        }


    }
}
