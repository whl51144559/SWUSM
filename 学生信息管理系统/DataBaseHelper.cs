using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace 学生信息管理系统
{
    public static class DataBaseHelper
    {
        //从app.config配置文件中获取连接数据库信息
        static readonly string STR_CONN = ConfigurationManager.ConnectionStrings["StudentManager"].ConnectionString;
        static SqlConnection conn;
        //静态构造函数
        static DataBaseHelper()
        {
            conn = new SqlConnection(STR_CONN);
        }
        public static int ExecNoneQuery(string sqltext,params object[] param)
        {
            int result = 0;
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqltext;
                if(param != null && param.Length > 0)
                {
                    // cmd.Parameters.AddRange(param);
                    for (int i = 0; i < param.Length; i++)
                    {
                        SqlParameter p = new SqlParameter("@" + i, param[i]);
                        cmd.Parameters.Add(p);
                    }
                }
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                result = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return result;
        }
        static SqlCommand _cmd;
        public static void BeginTranExecNoneQuery(string sqltext, params object[] param)
        {
            _cmd=conn.CreateCommand();
            _cmd.CommandText = sqltext;
            if (param != null && param.Length > 0)
            {
                // cmd.Parameters.AddRange(param);
                for (int i = 0; i < param.Length; i++)
                {
                    SqlParameter p = new SqlParameter("@" + i, param[i]);
                    _cmd.Parameters.Add(p);
                }
            }
            if(conn.State != ConnectionState.Open)
                conn.Open();
            _cmd.Transaction = conn.BeginTransaction("addscore");
        }
        public static int EndTranExecNoneQuery(int r)
        {
            int result = 0;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            try
            {
                result = _cmd.ExecuteNonQuery();
                if (r != result)
                    _cmd.Transaction.Rollback("addscore");
                else
                    _cmd.Transaction.Commit();
            }
            catch
            {
                _cmd.Transaction.Rollback("addscore");
            }
            finally
            {   
                conn.Close();
                _cmd.Dispose();
            }
            return result;
        }
        public static object ExecScalar(string sqltext, params object[] param)
        {
            object result = null;
            using(SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqltext;
                if (param != null && param.Length > 0)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        SqlParameter p = new SqlParameter("@" + i, param[i]);
                        cmd.Parameters.Add(p);
                    }
                }
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                result = cmd.ExecuteScalar();
                conn.Close();
            }
            return result;
        }
        public static SqlDataReader ExecReader(string sqltext, params object[] param)
        {
            SqlDataReader result = null;
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqltext;
                if (param != null && param.Length > 0)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        SqlParameter p = new SqlParameter("@" + i, param[i]);
                        cmd.Parameters.Add(p);
                    }
                }
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return result;
        }
        public static DataTable ExecDataTable(string sqltext,params object[] param)
        {
            DataTable result =new DataTable();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sqltext;
                if (param != null && param.Length > 0)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        SqlParameter p = new SqlParameter("@" + i, param[i]);
                        cmd.Parameters.Add(p);
                    }
                }
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(result);
                }
            }
            return result;
        }
    }
}
