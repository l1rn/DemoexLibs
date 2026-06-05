namespace UsefullLibs.src.forms
{
    partial class UserControlMain
    {
        protected Panel MainPanel;
        protected Panel PicturePanel;
        protected Panel DescriptivePanel;
        protected Panel DiscountPanel;
        protected FlowLayoutPanel AdditionalPanel;

        protected PictureBox PictureBox;
        protected Label DiscountLabel;

        protected Label FirstTitle;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            MainPanel = new Panel();
            DescriptivePanel = new Panel();
            FirstTitle = new Label();
            AdditionalPanel = new FlowLayoutPanel();
            PicturePanel = new Panel();
            PictureBox = new PictureBox();
            DiscountPanel = new Panel();
            DiscountLabel = new Label();
            MainPanel.SuspendLayout();
            DescriptivePanel.SuspendLayout();
            PicturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            DiscountPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(DescriptivePanel);
            MainPanel.Controls.Add(PicturePanel);
            MainPanel.Controls.Add(DiscountPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(700, 200);
            MainPanel.TabIndex = 0;
            // 
            // DescriptivePanel
            // 
            DescriptivePanel.Controls.Add(FirstTitle);
            DescriptivePanel.Controls.Add(AdditionalPanel);
            DescriptivePanel.Dock = DockStyle.Fill;
            DescriptivePanel.Location = new Point(167, 0);
            DescriptivePanel.Name = "DescriptivePanel";
            DescriptivePanel.Size = new Size(365, 200);
            DescriptivePanel.TabIndex = 1;
            // 
            // FirstTitle
            // 
            FirstTitle.AutoEllipsis = true;
            FirstTitle.AutoSize = true;
            FirstTitle.Location = new Point(0, 0);
            FirstTitle.Name = "FirstTitle";
            FirstTitle.Size = new Size(95, 20);
            FirstTitle.TabIndex = 0;
            FirstTitle.Text = "FirstTitle.Text";
            // 
            // AdditionalPanel
            // 
            AdditionalPanel.Dock = DockStyle.Bottom;
            AdditionalPanel.FlowDirection = FlowDirection.TopDown;
            AdditionalPanel.Location = new Point(0, 23);
            AdditionalPanel.Name = "AdditionalPanel";
            AdditionalPanel.Size = new Size(365, 177);
            AdditionalPanel.TabIndex = 2;
            // 
            // PicturePanel
            // 
            PicturePanel.Controls.Add(PictureBox);
            PicturePanel.Dock = DockStyle.Left;
            PicturePanel.Location = new Point(0, 0);
            PicturePanel.Name = "PicturePanel";
            PicturePanel.Size = new Size(167, 200);
            PicturePanel.TabIndex = 0;
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(3, 3);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(161, 194);
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            // 
            // DiscountPanel
            // 
            DiscountPanel.Controls.Add(DiscountLabel);
            DiscountPanel.Dock = DockStyle.Right;
            DiscountPanel.Location = new Point(532, 0);
            DiscountPanel.Name = "DiscountPanel";
            DiscountPanel.Size = new Size(168, 200);
            DiscountPanel.TabIndex = 2;
            // 
            // DiscountLabel
            // 
            DiscountLabel.AutoSize = true;
            DiscountLabel.Location = new Point(6, 83);
            DiscountLabel.Name = "DiscountLabel";
            DiscountLabel.Size = new Size(133, 20);
            DiscountLabel.TabIndex = 0;
            DiscountLabel.Text = "DiscountLabel.Text";
            // 
            // UserControlMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(MainPanel);
            Name = "UserControlMain";
            Size = new Size(700, 200);
            Load += ComponentMain_OnLoad;
            MainPanel.ResumeLayout(false);
            DescriptivePanel.ResumeLayout(false);
            DescriptivePanel.PerformLayout();
            PicturePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            DiscountPanel.ResumeLayout(false);
            DiscountPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
