using System.Collections.Generic;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Helpers;
using DatabaseObjectPackageInstaller.Models.Interfaces;

namespace DatabaseObjectPackageInstaller.Workers
{
    internal static class ConsoleValidation
    {
        internal static List<string> DatabaseObjectConnectionValidation(IDatabaseSettings databaseSettings)
        {
            var errorList = new List<string>();
            new SqlServerConnection().ValidateDatabaseConnection(databaseSettings, ref errorList);
            return errorList;
        }

        internal static List<string> DatabaseObjectPackageValidation(IPackageSettings packageSettings)
        {
            var errorList = new List<string>();
            if (!FileHelper.ValidatePackagePath(packageSettings))
            {
                errorList.Add(string.Format(ErrorStrings.UnableToLocatePath, packageSettings.PackagePath));
            }
            else
            {
                var packageTypeError = string.Empty;
                if (CompressedFileHelper.IsFileCompressed(packageSettings.PackagePath))
                {

                    if (!PackageHelper.ValidateCompressedPackage(packageSettings, out packageTypeError))
                    {
                        errorList.Add(packageTypeError);
                    }
                }
                else
                {
                    if (!PackageHelper.ValidateUncompressedPackage(packageSettings, out packageTypeError))
                    {
                        errorList.Add(packageTypeError);
                    }
                }
            }
            return errorList;
        }
    }
}
