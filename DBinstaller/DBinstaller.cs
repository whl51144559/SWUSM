using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace DBinstaller
{
    [RunInstaller(true)]
    public partial class DBinstaller : System.Configuration.Install.Installer
    {
        public DBinstaller()
        {
            InitializeComponent();
        }
        private string strServer = "";
        private string strUser = "";
        private string strPass = "";
        private string strPath = "";
        public override void Install(IDictionary stateSaver)
        {
            strServer = this.Context.Parameters["server"];
            strUser = this.Context.Parameters["user"];
            strPass = this.Context.Parameters["pass"];
            strPath = this.Context.Parameters["targetdir"];

            string strConn = String.Format("server={0};uid={1};pwd={2};",strServer, strUser, strPass);
            if (!IsDataBaseExist("StudentManagement"))
            {
                //执行SQL语句 附加数据库
                this.ExecuteSQL(strConn, "master", "EXEC sp_attach_db @dbname ='StudentManagement' , @filename1='" + strPath + "StudentManagement.mdf',@filename2='" + strPath + "StudentManagement_log.ldf'");
            }
            //改写Appconfig
            WriteAppConfig();
            base.Install(stateSaver);
        }
        private void ExecuteSQL(string strConn,string DatabaseName, string Sql)
        {
            SqlConnection sqlConnection1 = new SqlConnection(strConn);
            SqlCommand Command = new SqlCommand(Sql, sqlConnection1);
            Command.Connection.Open();
            Command.Connection.ChangeDatabase(DatabaseName);
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Command.Connection.Close();
            }
        }
        private bool IsDataBaseExist(string strDataBase)
        {
            SQLDMO.SQLServer srv = new SQLDMO.SQLServerClass();
            srv.Connect(strServer, strUser, strPass);
            bool ret = false;

            for (int i = 0; i < srv.Databases.Count; i++)
            {
                if (srv.Databases.Item(i + 1, "dbo").Name == strDataBase)
                {
                    ret = true;
                    break;
                }
            }
            srv.DisConnect();
            return ret;
        }
        protected void WriteAppConfig()
        {
            try
            {
                FileInfo file = new FileInfo(this.Context.Parameters["targetdir"] + @"\StudentManager.exe.config");
                XmlDocument doc = new XmlDocument();
                doc.Load(file.FullName);
                XmlElement root = doc.DocumentElement;
                XmlNodeList list = root.SelectNodes("/configuration/connectionStrings/add");
                foreach (XmlNode node in list)
                {
                    switch (node.Attributes["name"].Value)
                    {
                        case
                        "StudentManager.Properties.Settings.StudentManagementConnectionString":
                            node.Attributes["connectionString"].Value = "server=" + strServer + ";user id=" + strUser + ";pwd=" + strPass + ";database=StudentManagement";
                            break;
                        default:
                            break;
                    }
                }
                doc.Save(file.FullName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
