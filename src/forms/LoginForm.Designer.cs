using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulLibs.src.forms
{
    partial class BaseLoginForm
    {
        protected Panel MainPanel;
        protected Label LoginLabel;
        protected Label PasswordLabel;
        protected TextBox LoginInput;
        protected TextBox PasswordInput;
        protected Button LoginButton;
        protected Button GuestButton;

        private void InitializeComponent()
        {
            MainPanel = new Panel();
            
            LoginLabel = new Label();
            PasswordLabel = new Label();

            LoginInput = new TextBox();
            PasswordInput = new TextBox();

            LoginButton = new Button();
            GuestButton = new Button();

            MainPanel.SuspendLayout();
            SuspendLayout();

            ClientSize = new Size(1000, 550);
            Text = "Авторизация";
            MainPanel.Dock = DockStyle.Fill;

            LoginLabel.Text = "Логин";
            PasswordLabel.Text = "Пароль";
            LoginButton.Text = "Войти";
            GuestButton.Text = "Режим Гостя";

            LoginInput.Width = 200;
            PasswordInput.Width = 200;
            
            LoginButton.Width = 200;
            LoginButton.Height = 40;

            GuestButton.Width = 200;
            GuestButton.Height = 40;

            LoginLabel.AutoSize = true;
            PasswordLabel.AutoSize = true;
            
            MainPanel.Controls.Add(LoginLabel);
            MainPanel.Controls.Add(PasswordLabel);
            MainPanel.Controls.Add(LoginInput);
            MainPanel.Controls.Add(PasswordInput);
            MainPanel.Controls.Add(LoginButton);
            MainPanel.Controls.Add(GuestButton);

            Load += LoginForm_Load;
            Controls.Add(MainPanel);

            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
