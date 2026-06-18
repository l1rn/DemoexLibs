namespace UsefulLibs.src.forms
{
    public partial class UserControlMain : UserControl
    {
        public UserControlMain()
        {
            InitializeComponent();
        }

        public void AddControlComponentOnAdditionalPanel(Control c)
        {
            AdditionalPanel.Controls.Add(c);
        }
        public void ComponentMain_OnLoad(object sender, EventArgs e)
        {
        }
    }
}
