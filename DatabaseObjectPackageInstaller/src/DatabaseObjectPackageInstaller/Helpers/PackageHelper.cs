using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Enums;
using DatabaseObjectPackageInstaller.Models;
using DatabaseObjectPackageInstaller.Models.Interfaces;

namespace DatabaseObjectPackageInstaller.Helpers
{
    internal static class PackageHelper
    {
        private static readonly string temporaryPath = string.Format(ResourceStrings.TemporaryWorkingDirectory, Path.GetTempPath());

        public static bool ValidateCompressedPackage(IPackageSettings packageSettings, out string packageTypeError)
        {
            var valid = false;
            packageTypeError = string.Empty;
            if (!Directory.Exists(temporaryPath))
            {
                Directory.CreateDirectory(temporaryPath);
            }
            var extractedPath = CompressedFileHelper.ExtractFiles(packageSettings.PackagePath, temporaryPath);
            var fileList = new DirectoryInfo(extractedPath).GetFiles(ResourceStrings.SequenceManifestName, SearchOption.AllDirectories);
            if (fileList.Count() == 1)
            {
                valid = true;
            }
            else
            {
                if(fileList.Count() > 1)
                {
                    packageTypeError = ErrorStrings.PackageMultipleError;
                }
                else
                {
                    packageTypeError = ErrorStrings.PackageNoneError;
                }
            }
            if (!valid)
            {
                var folderList = new DirectoryInfo(extractedPath).GetDirectories(ResourceStrings.SqlDirectory, SearchOption.AllDirectories);
                if (folderList.Count() == 1)
                {
                    valid = true;
                }
                else
                {
                    if (folderList.Count() > 1)
                    {
                        packageTypeError = ErrorStrings.PackageMultipleError;
                    }
                    else
                    {
                        packageTypeError = ErrorStrings.PackageNoneError;
                    }
                }
            }
            Directory.Delete(extractedPath, true);
            return valid;
        }

        internal static bool ValidateUncompressedPackage(IPackageSettings packageSettings, out string packageTypeError)
        {
            var valid = false;
            packageTypeError = string.Empty;
            valid = Path.GetFileName(packageSettings.PackagePath).Equals(ResourceStrings.SequenceManifestName, StringComparison.InvariantCultureIgnoreCase);
            if (!valid)
            {
                var fileList = new DirectoryInfo(packageSettings.PackagePath).GetFiles(ResourceStrings.SequenceManifestName, SearchOption.AllDirectories);
                if(fileList.Count() == 1)
                {
                    valid = true;
                }
                else
                {
                    if (fileList.Count() > 1)
                    {
                        packageTypeError = ErrorStrings.PackageMultipleError;
                    }
                    else
                    {
                        packageTypeError = ErrorStrings.PackageNoneError;
                    }
                }

            }
            if (!valid)
            {
                var folderList = new DirectoryInfo(packageSettings.PackagePath).GetDirectories(ResourceStrings.SqlDirectory, SearchOption.AllDirectories);
                if (folderList.Count() == 1)
                {
                    valid = true;
                }
                else
                {
                    if (folderList.Count() > 1)
                    {
                        packageTypeError = ErrorStrings.PackageMultipleError;
                    }
                    else
                    {
                        packageTypeError = ErrorStrings.PackageNoneError;
                    }
                }
            }
            if(!valid)
            {
                var dirName = new DirectoryInfo(packageSettings.PackagePath).Name;
                valid = dirName.Equals(ResourceStrings.SqlDirectory, StringComparison.InvariantCultureIgnoreCase);
            }
            return valid;
        }

        internal static List<DatabaseObjectModel> GetDatabaseObjectsFromPackage(string pathToPackage)
        {
            var package = pathToPackage;
            var databaseObjectList = new List<DatabaseObjectModel>();
            if (File.GetAttributes(package).HasFlag(FileAttributes.Directory))
            {
                var fileList = new DirectoryInfo(package).GetFiles(ResourceStrings.SequenceManifestName, SearchOption.AllDirectories);
                if (fileList.Any())
                {
                    package = fileList[0].FullName;
                }
                else
                {
                    var folderList = new DirectoryInfo(package).GetDirectories(ResourceStrings.SqlDirectory, SearchOption.AllDirectories);
                    if(folderList.Any())
                    {
                        package = folderList[0].FullName;
                    }
                }
            }

            if (Path.GetFileName(package).Equals(ResourceStrings.SequenceManifestName, StringComparison.InvariantCultureIgnoreCase))
            {
                using (var reader = new StreamReader(package))
                {
                    var line = string.Empty;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.TrimEnd();
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }
                        var databaseObjectTypeString = line.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar })[0];
                        DatabaseObjectType databaseObjectType;
                        if (!Enum.TryParse(databaseObjectTypeString, true, out databaseObjectType))
                        {
                            databaseObjectType = DatabaseObjectType.Unknown;
                        }
                        databaseObjectList.Add(new DatabaseObjectModel(databaseObjectType, Path.Combine(package.ToLower().Replace(ResourceStrings.SequenceManifestName,string.Empty), line)));
                    }
                }
            }
            else
            {
                var databaseObjectTypeOrderList = new List<string>() { "functions", "views", "triggers", "procedures", "data modification" };
                foreach (var databaseObjectTypeString in databaseObjectTypeOrderList)
                {
                    var databaseObjectTypeDir = Path.Combine(package, databaseObjectTypeString);
                    DatabaseObjectType databaseObjectType;
                    if (!Enum.TryParse(databaseObjectTypeString, true, out databaseObjectType))
                    {
                        databaseObjectType = DatabaseObjectType.Unknown;
                    }
                    if(Directory.Exists(databaseObjectTypeDir))
                    {
                        var databaseObjectFileList = Directory.GetFiles(databaseObjectTypeDir, ResourceStrings.SqlFileTypeSearchPattern, SearchOption.AllDirectories).OrderBy(x => x);
                        foreach(var databaseObjectFile in databaseObjectFileList)
                        {
                            databaseObjectList.Add(new DatabaseObjectModel(databaseObjectType, databaseObjectFile));
                        }
                    }
                }
            }
            return databaseObjectList;
        }
    }
}
