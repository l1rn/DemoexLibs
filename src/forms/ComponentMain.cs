using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoexLibs.src.forms
{
    public partial class ComponentMain : UserControl
    {
        public ComponentMain()
        {
            InitializeComponent();
        }

        public void AddControlComponentOnAdditionalPanel(Control c, int cPos)
        {
            c.Location = new Point(0, cPos);
            AdditionalPanel.Controls.Add(c);
        }
        public void ComponentMain_OnLoad(object sender, EventArgs e)
        {
            Label SeparatorLabel = new Label
            {
                Text = "|",
                AutoSize = true
            };
            DescriptivePanel.Controls.Add(SeparatorLabel);

            int pos = 5;
            int gap = 0;

            FirstTitle.Location = new Point(pos, 5);

            pos += FirstTitle.Width + gap;
            SeparatorLabel.Location = new Point(pos, 5);

            pos += SeparatorLabel.Width + gap;
            SecondTitle.Location = new Point(pos, 5);
        }
    }
}
