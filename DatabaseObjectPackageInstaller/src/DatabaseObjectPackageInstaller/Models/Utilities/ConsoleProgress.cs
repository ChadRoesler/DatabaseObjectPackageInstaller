using System;

namespace DatabaseObjectPackageInstaller.Models.Utilities
{
    public class ConsoleProgress<T> : IProgress<T>
    {
        private readonly Action<T> WriteAction;

        public ConsoleProgress(Action<T> consoleAction)
        {
            if (consoleAction == null)
            {
                throw new ArgumentNullException();
            }

            WriteAction = consoleAction;
        }

        public void Report(T value)
        {
            WriteAction(value);
        }
    }
}
