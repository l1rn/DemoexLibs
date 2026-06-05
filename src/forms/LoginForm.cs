using System.Windows.Forms;

namespace UsefullLibs.src.forms
{
    public partial class BaseLoginForm : Form
    {
        public BaseLoginForm()
        {
            InitializeComponent();
        }

        private int GetWidthForElement(Control c)
        {
            return (int)(this.Width / 2) - (int) (c.Width /2);
        }
        public void LoginForm_Load(object sender, EventArgs e)
        {
            int pos = 100;
            int gap = 5;
            LoginLabel.Location = new Point(GetWidthForElement(LoginLabel), pos);
            pos += LoginLabel.Height + gap;
            
            LoginInput.Location = new Point(GetWidthForElement(LoginInput), pos);
            pos += LoginInput.Height + gap;

            PasswordLabel.Location = new Point(GetWidthForElement(PasswordLabel), pos);
            pos += PasswordLabel.Height + gap;

            PasswordInput.Location = new Point(GetWidthForElement(PasswordInput), pos);
            pos += PasswordInput.Height + gap;

            LoginButton.Location = new Point(GetWidthForElement(LoginButton), pos);
            pos += LoginButton.Height + gap;

            GuestButton.Location = new Point(GetWidthForElement(GuestButton), pos + 50);
        }
    }
}
