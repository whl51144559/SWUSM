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
    public partial class TypesSetForm : Form
    {
        public TypesSetForm()
        {
            InitializeComponent();
        }

        private void TypesSetForm_Load(object sender, EventArgs e)
        {
            Bind_girdXueJi();
        }
        #region 学籍异动类型设置
        private void Bind_girdXueJi()
        {
            string sql = "select ChangeTypes_ID as 编号,ChangeTypes_Name as 变动类型名称 from ChangeTypes";
            this.gridXueJi.DataSource = DataBaseHelper.ExecDataTable(sql);
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtXueJiName.Text.Trim()))
            {
                MessageBox.Show("请输入学籍变动类型名称！");
                return;
            }
            string sql = "insert into ChangeTypes values(@0)";
            int i = DataBaseHelper.ExecNoneQuery(sql, this.txtXueJiName.Text.Trim());
            if (i == 1)
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            Bind_girdXueJi();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                string sql = "delete from ChangeTypes where ChangeTypes_ID=@0";
                int i = DataBaseHelper.ExecNoneQuery(sql,(int)this.gridXueJi.SelectedRows[0].Cells[0].Value);
                if (i == 1)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                Bind_girdXueJi();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                string sql = "delete from PunishmentAwardTypes where PunishmentAwardTypes_ID=@0";
                int i = DataBaseHelper.ExecNoneQuery(sql,(int)this.gridPunishmentAwards.SelectedRows[0].Cells[0].Value);
                if (i == 1)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                Bind_gridPunishmentAwards();

            }
        }
        #endregion

        #region 处分类型设置
        private void Bind_gridPunishmentAwards()
        {
            string sql = "select PunishmentAwardTypes_ID as 奖惩类型编号,PunishmentAwardTypes_Name as 奖惩类型名称 from PunishmentAwardTypes order by PunishmentAwardTypes_ID desc";
            this.gridPunishmentAwards.DataSource = DataBaseHelper.ExecDataTable(sql);
        }
        private void btnAddPA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPunishmentAwards.Text.Trim()))
            {
                MessageBox.Show("请输入奖惩类型名称！");
                return;
            }

            int id = 0;
            if (cbbPunishmentAwards.Text == "奖励")
            {
                string sql = "select max(PunishmentAwardTypes_ID) from PunishmentAwardTypes ";
                object obj = DataBaseHelper.ExecScalar(sql);
                if (!string.IsNullOrEmpty(obj.ToString()))
                {
                    id = int.Parse(obj.ToString());
                    if (id < 1)
                        id = 1;
                    else
                        id++;
                }
                else
                {
                    id = 1;
                }
            }
            else
            {
                string sql = "select min(PunishmentAwardTypes_ID) from PunishmentAwardTypes";
                object obj = DataBaseHelper.ExecScalar(sql);
                if (!string.IsNullOrEmpty(obj.ToString()))
                {
                    id = (int)obj;
                    if (id > 0)
                        id = -1;
                    else
                        id--;
                }
                else
                {
                    id = -1;
                }
            }
            string sql1 = "insert into PunishmentAwardTypes values(@0,@1)";
            int i = DataBaseHelper.ExecNoneQuery(sql1, id,this.txtPunishmentAwards.Text.Trim());
            if (i == 1)
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            Bind_gridPunishmentAwards();
        }
        #endregion

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Text == "学籍异动类型设置")
            {
                Bind_girdXueJi();
            }
            else
            {
                Bind_gridPunishmentAwards();
                cbbPunishmentAwards.SelectedIndex = 0;
            }
        }

       

    }
}
