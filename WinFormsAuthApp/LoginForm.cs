using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace WinFormsAuthApp
{
    public partial class LoginForm : Form
    {
        private string generatedCaptcha;
        private bool passwordVisible = false;

        public LoginForm()
        {
            InitializeComponent();
            GenerateCaptcha();
            passwordTextBox.UseSystemPasswordChar = true;
        }
        private void GenerateCaptcha()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            generatedCaptcha = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());


            captchaLabel.Text = generatedCaptcha;
            captchaLabel.Font = new Font(captchaLabel.Font, FontStyle.Bold | FontStyle.Strikeout);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "user" && passwordTextBox.Text == "user")
            {

                MainForm mainForm = new MainForm(this);
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
                GenerateCaptcha();
            }
        }

        private void togglePasswordButton_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            passwordTextBox.UseSystemPasswordChar = !passwordVisible;


            togglePasswordButton.Text = passwordVisible ? "Hide" : "Show";
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
    }
