namespace DatabaseObjectPackageInstaller.Models.Interfaces
{
    interface IPackageSettings
    {
        string PackagePath { get; }
        bool Custom { get; set; }
    }
}
