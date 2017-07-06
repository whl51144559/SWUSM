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
using StudentManager;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace 学生信息管理系统
{
    public partial class UserLoginForm : Form
    {
 
        public UserLoginForm()
        {
            InitializeComponent();
        }
        bool islogin = false;
        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            addUser(sender, e);
        }
        DataTable dt;
        private void addUser(object sender, EventArgs e)
        {
            string unsql = "select Admin_ID,Admin_Name,Admin_Password,Admin_Rember,Admin_AutoLogin from AdminInfo";
            dt = DataBaseHelper.ExecDataTable(unsql);

            cmbUserName.DataSource = dt;
            cmbUserName.DisplayMember = "Admin_Name";
            cmbUserName.ValueMember = "Admin_ID";

            string selectname = "select Admin_Name,Admin_ID from AdminInfo where Admin_AutoLogin=1";
            if (DataBaseHelper.ExecDataTable(selectname).Rows.Count>0)
            {
                DataTable dtname = DataBaseHelper.ExecDataTable(selectname);
                DataRow rowname = dtname.Rows[0];
                this.cmbUserName.SelectedValue = rowname["Admin_ID"];
            }



            DataRow row = dt.Rows[cmbUserName.SelectedIndex];
            //this.cmbUserName.SelectedValue = row["Admin_Name"].ToString();
            txtUserPwd.Text = row["Admin_Password"].ToString();
            checkBox1.Checked = true;
            string auto = row["Admin_AutoLogin"].ToString();
            if (auto == "True")
            {
                checkBox2.Checked = true;
                btnOK_Click(sender, e);
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (this.cmbUserName.Text.Trim() == "")
            {
                MessageBox.Show("请先输入用户名!");
                return;
            }
            else if (this.txtUserPwd.Text.Trim() == "")
            {
                MessageBox.Show("请先输入用户密码!");
                return;
            }
            else
            {

                MainForm mf = (MainForm)this.Owner;
                string sql = "select Admin_ID, Admin_Level from AdminInfo where Admin_Name=@0 and Admin_Password=@1";
                SqlDataReader sdr = DataBaseHelper.ExecReader(sql,this.cmbUserName.Text, this.txtUserPwd.Text);
                if (sdr.Read())
                {
                    string level = sdr["Admin_Level"].ToString();//获取用户权限
                    mf.adminID = (int)sdr["Admin_id"];//存储用户编号
                    sdr.Close();
                    if (level == "1")
                    {
                        this.DialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.No;
                    }

                    string updatesql = "update AdminInfo set Admin_Rember=@0,Admin_AutoLogin=@1 where Admin_ID=@2 ";
                    int r = DataBaseHelper.ExecNoneQuery(updatesql, checkBox1.Checked ? "1" : "0", checkBox2.Checked ? "1" : "0",cmbUserName.SelectedValue);

                    islogin = true;
                    this.Close();

                   
                }
                else
                {
                    sdr.Close();
                    MessageBox.Show("用户名或密码有误！", "错误");
                        return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //System.Environment.Exit(System.Environment.ExitCode);
            System.Environment.Exit(0);
        }

        private void UserLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!islogin)
                //System.Environment.Exit(System.Environment.ExitCode);
                System.Environment.Exit(0);
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = dt.Rows[cmbUserName.SelectedIndex];
            string rem = row["Admin_Rember"].ToString();
            if (rem == "True")
            {
                checkBox1.Checked = true;
                txtUserPwd.Text = row["Admin_Password"].ToString();
            }
            else
            {
                checkBox1.Checked = false;
                txtUserPwd.Text = "";
            }

            string auto = row["Admin_AutoLogin"].ToString();
            if (auto == "True")
                checkBox2.Checked = true;
            else
                checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                checkBox1.Checked = true;
            else if (!checkBox1.Checked)
                checkBox2.Checked = false;
        }




    }
}
