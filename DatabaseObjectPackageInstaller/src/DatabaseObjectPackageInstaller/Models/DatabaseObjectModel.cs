using System.IO;
using DatabaseObjectPackageInstaller.Enums;
using DatabaseObjectPackageInstaller.Constants;

namespace DatabaseObjectPackageInstaller.Models
{
    internal class DatabaseObjectModel
    {
        internal DatabaseObjectModel(DatabaseObjectType databaseObjectType, string databaseObjectPath)
        {
            ObjectType = databaseObjectType;
            DatabaseObjectPath = databaseObjectPath;
            DatabaseObjectName = Path.GetFileNameWithoutExtension(databaseObjectPath);
            DatabaseObjectFolderAndName = string.Format(ResourceStrings.DatabaseObjectFolderAndName, Path.GetDirectoryName(databaseObjectPath), Path.GetFileName(databaseObjectPath));
            switch (databaseObjectType)
            {
                case DatabaseObjectType.Functions:
                    CreateStatement = string.Format(ResourceStrings.ExistenceCheckFormat, DatabaseObjectName, string.Format(ResourceStrings.FunctionStubQueryFormat, DatabaseObjectName));
                    break;
                case DatabaseObjectType.Procedures:
                    CreateStatement = string.Format(ResourceStrings.ExistenceCheckFormat, DatabaseObjectName, string.Format(ResourceStrings.ProcedureStubQueryFormat, DatabaseObjectName));
                    break;
                case DatabaseObjectType.Views:
                    CreateStatement = string.Format(ResourceStrings.ExistenceCheckFormat, DatabaseObjectName, string.Format(ResourceStrings.ViewStubQueryFormat, DatabaseObjectName));
                    break;
                default:
                    CreateStatement = string.Format(ResourceStrings.DefaultStubQuery, DatabaseObjectName);
                    break;
            }
        }

        internal DatabaseObjectType ObjectType { get; set; }
        internal string DatabaseObjectPath { get; set; }
        internal string DatabaseObjectName { get; set; }
        internal string CreateStatement { get; private set; }
        internal string DatabaseObjectFolderAndName { get; set; }

    }
}
