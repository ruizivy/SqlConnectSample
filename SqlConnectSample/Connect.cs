using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyUtilities;
using System.IO;

namespace SqlConnectSample
{
    public partial class frmConnect : Form
    {
        MySQLDbUtilities db = new MySQLDbUtilities();
        string connStr;
        bool isNotDone = true;

        public frmConnect()
        {
            InitializeComponent();
        }

        private void Connect_Load(object sender, EventArgs e)
        {

        }

        private void btntest_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            TestConnection();
            Apply();
        }
        public void TestConnection()
        {
            connStr = "SERVER=" + txtserver.Text + ";" +
                "PORT=" + txtport.Text + ";" +
                "UID=" + txtuid.Text + ";" +
                "DATABASE=" + txtdatabase.Text + ";" +
                "PASSWORD=" + txtpassword.Text + ";";
            if (db.IsConnectionValid(connStr))
                MessageBox.Show("Connection Valid!");
            else
                MessageBox.Show("Invalid Connection!");
        }
        public void Apply()
        {
            if (db.IsConnectionValid(connStr))
            {
                string[] arr = new string[5];
                arr[0] = "SERVER=" + txtserver.Text + ";";
                arr[1] = "PORT=" + txtport.Text + ";";
                arr[2] = "UID=" + txtuid.Text + ";";
                arr[3] = "DATABASE=" + txtdatabase.Text + ";";
                arr[4] = "PASSWORD=" + txtpassword.Text + ";";
                File.WriteAllLines(frmLogin.dir + "\\settings.ini", arr);
                isNotDone = false;
                this.Close();
            }
        }

        private void frmConnect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && isNotDone)
                Environment.Exit(1);
        }
    }
}
