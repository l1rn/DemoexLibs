
using UsefulLibs.src.forms;

namespace UsefulLibs
{
    public partial class BaseEditForm : BaseForm
    {
        public BaseEditForm()
        {
            InitializeComponent();
        }

        public void CreateNewElementOnPanel(Control c)
        {
            flowLayoutPanel1.SuspendLayout();
            c.Padding = new Padding(0, 5, 0, 5);
            if (c.GetType() == typeof(Label))
            {
                c.Margin = new Padding(
                (int)(this.Width) / 2 - (int)(c.PreferredSize.Width / 2),
                    0,
                    0,
                    0
                );
            } else
            {
                c.Margin = new Padding(
                (int)(this.Width) / 2 - (int)(c.Width / 2),
                    0,
                    0,
                    0
                );
            }
                flowLayoutPanel1.Controls.Add(c);
            flowLayoutPanel1.ResumeLayout();
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
