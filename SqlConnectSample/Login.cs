using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyUtilities;

namespace SqlConnectSample
{
    public partial class frmLogin : Form
    {
        public static string dir = @"C:\Users\" + Environment.UserName + @"\configuration";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!File.Exists(dir + "\\settings.ini"))
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                frmConnect conn = new frmConnect();
                conn.ShowDialog();
            }
        }
    }
}
