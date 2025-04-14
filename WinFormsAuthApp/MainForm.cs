using System;
using System.Windows.Forms;

namespace WinFormsAuthApp
{
    public partial class MainForm : Form
    {
        private LoginForm loginForm;
        public MainForm(LoginForm login)
        {
            InitializeComponent();
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Close(); 
        }
    }
}
