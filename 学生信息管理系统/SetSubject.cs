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
    public partial class SetSubject : Form
    {
        private string Spec_ID;
        private string Spec_Name;
        private string College_Name;
        public SetSubject(string spec_id,string spec_name,string college_name)
        {
            this.Spec_ID = spec_id;
            this.Spec_Name = spec_name;
            this.College_Name = college_name;
            InitializeComponent();
        }
        private void SetSubject_Load(object sender, EventArgs e)
        {
            string cocp = this.College_Name + this.Spec_Name;
            this.Text = "为"+cocp+"专业设置学科";
            btnSetSubject.Text = "添加到" + this.Spec_Name + "专业";
            Bind_gridSpecSubject();
            Bind_cbbSubjects();
        }
        private void Bind_gridSpecSubject()
        {
            string sql = "select Subjects.Subjects_ID as 学科编号,Subjects_Name as 学科名称 from Subjects join Sepc_Subjects on Subjects.Subjects_ID=Sepc_Subjects.Subjects_ID where Sepc_Subjects.Sepc_ID=@0";
            this.gridSpecSubject.DataSource =DataBaseHelper.ExecDataTable(sql,Spec_ID);
        }
        private void Bind_cbbSubjects()
        {
            string sql = "select * from Subjects";
            this.cbbSubject.DataSource = DataBaseHelper.ExecDataTable(sql);
            this.cbbSubject.DisplayMember = "Subjects_Name";
            this.cbbSubject.ValueMember = "Subjects_ID";
        }
        private void btnSetSubject_Click(object sender, EventArgs e)
        {
            string sql = "insert into Sepc_Subjects values(@0,@1)";
            try
            {
                int i = DataBaseHelper.ExecNoneQuery(sql,Spec_ID,this.cbbSubject.SelectedValue.ToString());
                if (i == 1)
                {
                    MessageBox.Show("添加成功!");
                    if (cbbSubject.SelectedIndex<cbbSubject.Items.Count)
                    cbbSubject.SelectedIndex  ++;
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
                Bind_gridSpecSubject();
            }
            catch
            {
                MessageBox.Show("此学科已存在！");
            }
        }
        private void btnDelSubject_Click(object sender, EventArgs e)
        {
            string sql = "Delete from Sepc_Subjects where Subjects_ID=@0";
            int i = DataBaseHelper.ExecNoneQuery(sql,this.gridSpecSubject.SelectedRows[0].Cells[0].Value.ToString());
            if (i == 1)
            {
                MessageBox.Show(" 删除成功！");
            }
            else
            {
                MessageBox.Show("删除失败！");
            }
            Bind_gridSpecSubject();
        }
    }
}
