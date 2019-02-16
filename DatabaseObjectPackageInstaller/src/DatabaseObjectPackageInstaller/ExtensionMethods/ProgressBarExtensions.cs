using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DatabaseObjectPackageInstaller.Enums;
namespace DatabaseObjectPackageInstaller.ExtensionMethods
{
    public static class ProgressBarExtensions
    {
        private static ProgressBarStatusType currentProgressType = ProgressBarStatusType.Normal;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar progressBar, ProgressBarStatusType state)
        {
            currentProgressType = state;
            SendMessage(progressBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        public static ProgressBarStatusType GetState(this ProgressBar progressBar)
        {
            return currentProgressType;
        }
    }
}
