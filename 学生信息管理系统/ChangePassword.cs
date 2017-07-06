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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void bunOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtNewPwd.Text.Trim()))
            {
                MessageBox.Show("新密码不能为空！");
                return;
            }
            if (this.txtNewPwd.Text!=this.txtRePwd.Text)
            {
                MessageBox.Show("两次密码输入不一致！");
                return;
            }
            MainForm main=(MainForm)this.Owner;
            string sql = "update AdminInfo set Admin_Password=@0 where Admin_Password=@1 and Admin_ID=@2";
            int i = DataBaseHelper.ExecNoneQuery(sql, this.txtNewPwd.Text,this.txtOldPwd.Text, main.adminID);
            if (i == 1)
            {
                MessageBox.Show("修改密码成功！");
            }
            else
            {
                MessageBox.Show("密码输入错误");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
