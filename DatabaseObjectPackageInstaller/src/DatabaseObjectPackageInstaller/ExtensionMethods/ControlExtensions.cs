using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseObjectPackageInstaller.ExtensionMethods
{
    public static class ControlExtensions
    {
        public static Control FindControlInControl(this Control currentControl, string controlName)
        {
            var control = new Control();
            if (currentControl.Name == controlName)
            {
                return currentControl;
            }
            else
            {
                foreach (Control c in currentControl.Controls)
                {
                    control = c.FindControlInControl(controlName);
                    if (control != null)
                    {
                        return control;
                    }
                }
                return null;
            }
        }
        public static IEnumerable<Control> GetAllTextBoxes(this Control currentControl)
        {
            var controlList = new List<Control>();
            foreach (Control c in currentControl.Controls)
            {
                if (c is TextBox)
                {
                    controlList.Add(c);
                }
                if (c is GroupBox)
                {
                    controlList.AddRange(c.GetAllTextBoxes());
                }
            }
            return controlList;
        }

        public static void ClearAllTextBoxes(this Control currentControl)
        {
            var textBoxes = currentControl.GetAllTextBoxes();
            foreach (var textBox in textBoxes)
            {
                textBox.Text = string.Empty;
            }
        }

        public static IEnumerable<Control> GetAllComboBoxes(this Control currentControl)
        {
            var controlList = new List<Control>();
            foreach (Control c in currentControl.Controls)
            {
                if (c is ComboBox)
                {
                    controlList.Add(c);
                }
                if (c is GroupBox)
                {
                    controlList.AddRange(c.GetAllComboBoxes());
                }
            }
            return controlList;
        }

        public static IEnumerable<Control> GetAllButtons(this Control currentControl)
        {
            var controlList = new List<Control>();
            foreach (Control c in currentControl.Controls)
            {
                if (c is Button)
                {
                    controlList.Add(c);
                }
                if (c is GroupBox)
                {
                    controlList.AddRange(c.GetAllButtons());
                }
            }
            return controlList;
        }

        public static IEnumerable<Control> GetAllPanels(this Control currentControl)
        {
            var controlList = new List<Control>();
            foreach (Control c in currentControl.Controls)
            {
                if (c is Panel)
                {
                    controlList.Add(c);
                }
                if (c is GroupBox)
                {
                    controlList.AddRange(c.GetAllPanels());
                }
            }
            return controlList;
        }
    }
}
