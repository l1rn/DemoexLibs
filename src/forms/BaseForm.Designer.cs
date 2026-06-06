using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulLibs.src.forms
{
    partial class BaseForm
    {
        protected Panel MainPanel;
        protected Panel TopPanel;
        protected FlowLayoutPanel CurrentUserPanel;
        protected PictureBox LogoPicture;
        protected Label TopLabel;

        protected Label UsernameTitle;
        protected Label RoleTitle;

        protected Label UsernameValue;
        protected Label RoleValue;

        private void InitializeComponent()
        {
            MainPanel = new Panel();
            TopPanel = new Panel();
            LogoPicture = new PictureBox();
            TopLabel = new Label();
            CurrentUserPanel = new FlowLayoutPanel();
            UsernameTitle = new Label();
            UsernameValue = new Label();
            RoleTitle = new Label();
            RoleValue = new Label();
            MainPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPicture).BeginInit();
            CurrentUserPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(TopPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1000, 550);
            MainPanel.TabIndex = 0;
            // 
            // TopPanel
            // 
            TopPanel.Controls.Add(LogoPicture);
            TopPanel.Controls.Add(TopLabel);
            TopPanel.Controls.Add(CurrentUserPanel);
            TopPanel.Dock = DockStyle.Top;
            TopPanel.Location = new Point(0, 0);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1000, 125);
            TopPanel.TabIndex = 0;
            // 
            // LogoPicture
            // 
            LogoPicture.Location = new Point(12, 12);
            LogoPicture.Name = "LogoPicture";
            LogoPicture.Size = new Size(100, 100);
            LogoPicture.SizeMode = PictureBoxSizeMode.Zoom;
            LogoPicture.TabIndex = 0;
            LogoPicture.TabStop = false;
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Location = new Point(118, 20);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(195, 20);
            TopLabel.TabIndex = 1;
            TopLabel.Text = "TopLabel.Text";
            // 
            // CurrentUserPanel
            // 
            CurrentUserPanel.Controls.Add(UsernameTitle);
            CurrentUserPanel.Controls.Add(UsernameValue);
            CurrentUserPanel.Controls.Add(RoleTitle);
            CurrentUserPanel.Controls.Add(RoleValue);
            CurrentUserPanel.Dock = DockStyle.Right;
            CurrentUserPanel.FlowDirection = FlowDirection.TopDown;
            CurrentUserPanel.Location = new Point(600, 0);
            CurrentUserPanel.Name = "CurrentUserPanel";
            CurrentUserPanel.Size = new Size(400, 125);
            CurrentUserPanel.TabIndex = 2;
            CurrentUserPanel.WrapContents = false;
            // 
            // UsernameTitle
            // 
            UsernameTitle.AutoSize = true;
            UsernameTitle.Location = new Point(3, 0);
            UsernameTitle.Name = "UsernameTitle";
            UsernameTitle.Size = new Size(107, 20);
            UsernameTitle.TabIndex = 0;
            UsernameTitle.Text = "Пользователь";
            // 
            // UsernameValue
            // 
            UsernameValue.AutoSize = true;
            UsernameValue.Location = new Point(3, 20);
            UsernameValue.Name = "UsernameValue";
            UsernameValue.Size = new Size(236, 20);
            UsernameValue.TabIndex = 1;
            UsernameValue.Text = "UsernameValue.Text";
            // 
            // RoleTitle
            // 
            RoleTitle.AutoSize = true;
            RoleTitle.Location = new Point(3, 40);
            RoleTitle.Name = "RoleTitle";
            RoleTitle.Size = new Size(142, 20);
            RoleTitle.TabIndex = 2;
            RoleTitle.Text = "Роль пользователя";
            // 
            // RoleValue
            // 
            RoleValue.AutoSize = true;
            RoleValue.Location = new Point(3, 60);
            RoleValue.Name = "RoleValue";
            RoleValue.Size = new Size(200, 20);
            RoleValue.TabIndex = 3;
            RoleValue.Text = "RoleValue.Text";
            // 
            // BaseForm
            // 
            ClientSize = new Size(1000, 550);
            Controls.Add(MainPanel);
            Name = "BaseForm";
            Text = "this.Text";
            Load += BaseForm_Load;
            MainPanel.ResumeLayout(false);
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPicture).EndInit();
            CurrentUserPanel.ResumeLayout(false);
            CurrentUserPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
