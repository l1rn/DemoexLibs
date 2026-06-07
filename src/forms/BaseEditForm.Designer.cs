namespace UsefulLibs
{
    partial class BaseEditForm
    {

        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            MainPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPicture).BeginInit();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(flowLayoutPanel1);
            MainPanel.Controls.SetChildIndex(TopPanel, 0);
            MainPanel.Controls.SetChildIndex(flowLayoutPanel1, 0);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 125);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1000, 425);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.WrapContents = false;
            // 
            // BaseEditForm
            // 
            ClientSize = new Size(1000, 550);
            Name = "BaseEditForm";
            Load += BaseEditForm_Load;
            MainPanel.ResumeLayout(false);
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogoPicture).EndInit();
            ResumeLayout(false);

        }
        private FlowLayoutPanel flowLayoutPanel1;
    }
}