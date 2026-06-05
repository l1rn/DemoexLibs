using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsefullLibs.src.forms
{
    public partial class UserControlMain : UserControl
    {
        public UserControlMain()
        {
            InitializeComponent();
        }

        public void AddControlComponentOnAdditionalPanel(Control c, int cPos)
        {
            AdditionalPanel.Controls.Add(c);
        }
        public void ComponentMain_OnLoad(object sender, EventArgs e)
        {
        }
    }
}
