using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsefulLibs.src.common
{
    public class CommonValidation
    {
        public void OpenFileDialog_OnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (sender.GetType() == typeof(PictureBox))
                    {
                        PictureBox pictureBox = (PictureBox)sender;
                        pictureBox.Image = Image.FromFile(ofd.FileName);
                        pictureBox.Tag = ofd.FileName;
                    }
                }
            }
        }
        public bool ValidateTextBoxesAreInteger(params TextBox[] textBoxes)
        {
            foreach (TextBox tb in textBoxes)
            {
                if (!int.TryParse(tb.Text.Trim(), out int result))
                {
                    MessageBox.Show(
                        "Пожалуйста введите корректные данные!",
                        "Ошибка ввода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    tb.Focus();
                    tb.SelectAll();
                    return false;
                }
            }
            return true;
        }
        public bool ValidateTextBoxesAreNotNull(params TextBox[] textBoxes)
        {
            foreach (TextBox tb in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(tb.Text.Trim()))
                {
                    MessageBox.Show(
                        "Пожалуйста введите корректные данные!",
                        "Ошибка ввода",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    tb.Focus();
                    tb.SelectAll();
                    return false;
                }
            }
            return true;
        }
    }
}
