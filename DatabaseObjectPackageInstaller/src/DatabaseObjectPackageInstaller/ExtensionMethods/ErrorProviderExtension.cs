using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DatabaseObjectPackageInstaller.ExtensionMethods
{
    public static class ErrorProviderExtension
    {
        public static void ClearAll(this ErrorProvider currentErrorProvider, Control controlToProcess)
        {
            currentErrorProvider.Clear();
            foreach (var control in controlToProcess.GetAllComboBoxes())
            {
                currentErrorProvider.SetError(control, string.Empty);
            }
            foreach (var control in controlToProcess.GetAllPanels())
            {
                currentErrorProvider.SetError(control, string.Empty);
            }
            foreach (var control in controlToProcess.GetAllTextBoxes())
            {
                currentErrorProvider.SetError(control, string.Empty);
            }
        }

        public static void SetErrors(this ErrorProvider currentErrorProvider, Control.ControlCollection controlToProcess, Dictionary<string, string> errorDictionary)
        {
            foreach (var error in errorDictionary)
            {
                var control = controlToProcess.Find(error.Key, true).FirstOrDefault();
                currentErrorProvider.SetError(control, error.Value);
                if (control.GetType() == typeof(Panel))
                {
                    currentErrorProvider.SetIconPadding(control, -10);
                }
                if (control.GetType() == typeof(ComboBox))
                {
                    currentErrorProvider.SetIconPadding(control, 3);
                }
                if (control.GetType() == typeof(TextBox))
                {
                    currentErrorProvider.SetIconPadding(control, -20);
                }
            }
        }
    }
}
