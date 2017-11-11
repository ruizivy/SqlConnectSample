using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using SqlConnectSample;

namespace MyUtilities
{
    class MySQLDbUtilities
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter adptr;

        public MySQLDbUtilities()
        {
            conn = new MySqlConnection();
            cmd = new MySqlCommand();
            adptr = new MySqlDataAdapter();
        }
        public MySqlConnection OpenConnection()
        {
            conn.ConnectionString = ReadFromIniFile();
            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }
        public DataTable SelectQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                adptr = new MySqlDataAdapter(query, OpenConnection());
                adptr.Fill(dt);
                adptr.Dispose();
                CloseConnection();
                return dt;
            }
            catch
            {
                return null;
            }
        }
        private string ReadFromIniFile()
        {
            string text = string.Empty;
            if (!File.Exists(frmLogin.dir + "\\settings.ini"))
                File.WriteAllText(frmLogin.dir + "\\settings.ini", "");
            else
            {
                string[] datas = File.ReadAllLines(frmLogin.dir + "\\settings.ini");
                foreach (string s in datas)
                    text += s;
            }
            return text;
        }
        public void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public bool IsConnectionValid(string connStr)
        {
            conn.ConnectionString = connStr;
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
