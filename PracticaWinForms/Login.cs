using PracticaWinForms.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaWinForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.CenterToScreen();
            //Initialize all main functions.
            Engine.Initialize();                
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var loginSuccessful = Engine.Login(txtUser.Text, txtPassword.Text);
            if (loginSuccessful)
            {
                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credentials are invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
