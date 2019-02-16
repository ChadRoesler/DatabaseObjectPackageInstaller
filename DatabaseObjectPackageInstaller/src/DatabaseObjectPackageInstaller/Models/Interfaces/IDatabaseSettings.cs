namespace DatabaseObjectPackageInstaller.Models.Interfaces
{
    public interface IDatabaseSettings
    {
        string Database { get; set; }
        string Server { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
