using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseObjectPackageInstaller.Constants;
using DatabaseObjectPackageInstaller.Models.Interfaces;

namespace DatabaseObjectPackageInstaller.Workers
{
    internal class SqlServerConnection
    {
        internal SqlConnection DatabaseConnection(IDatabaseSettings databaseSettings)
        {
            var sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = databaseSettings.Server;
            sqlConnectionString.InitialCatalog = databaseSettings.Database;
            sqlConnectionString.ApplicationName = ResourceStrings.ApplicationName;
            if (!string.IsNullOrWhiteSpace(databaseSettings.UserName) && !string.IsNullOrWhiteSpace(databaseSettings.Password))
            {

                sqlConnectionString.UserID = databaseSettings.UserName;
                sqlConnectionString.Password = databaseSettings.Password;
            }
            else
            {
                sqlConnectionString.IntegratedSecurity = true;
            }
            var sqlConn = new SqlConnection(sqlConnectionString.ConnectionString);
            return sqlConn;
        }

        internal bool ValidateDatabaseConnection(IDatabaseSettings databaseSettings, ref List<string> errorList)
        {
            var connection = DatabaseConnection(databaseSettings);
            try
            {
                connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                errorList.Add(string.Format(ErrorStrings.SqlUnableToConnect, connection.ConnectionString, ex.Message));
                return false;
            }
            finally
            {
                if(connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
