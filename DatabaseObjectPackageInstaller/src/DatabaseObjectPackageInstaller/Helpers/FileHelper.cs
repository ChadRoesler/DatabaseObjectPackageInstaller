using System.IO;
using DatabaseObjectPackageInstaller.Models.Interfaces;

namespace DatabaseObjectPackageInstaller.Helpers
{
    internal static class FileHelper
    {
        internal static bool ValidatePackagePath(IPackageSettings packageSettings)
        {
            var valid = false;
            valid = !string.IsNullOrWhiteSpace(packageSettings.PackagePath);
            if(valid)
            {
                try
                {
                    var pathAttributes = File.GetAttributes(packageSettings.PackagePath);
                    if (pathAttributes.HasFlag(FileAttributes.Directory))
                    {
                        valid = Directory.Exists(packageSettings.PackagePath);
                    }
                    else
                    {
                        valid = File.Exists(packageSettings.PackagePath);
                    }
                }
                catch
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
