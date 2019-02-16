using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseObjectPackageInstaller.Constants;

namespace DatabaseObjectPackageInstaller.Helpers
{
    class SqlHelper
    {
        public static object ExecSQLReturn(SqlConnection connection, string sqlCommand, List<SqlParameter> sqlParameters)
        {
            using (var cmd = new SqlCommand(sqlCommand, connection))
            {
                cmd.Parameters.AddRange(sqlParameters.ToArray());
                cmd.CommandTimeout = 60;
                try
                {
                    connection.Open();
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(ErrorStrings.ErrorSqlExecution, sqlCommand, ex.Message));
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public static object ExecSQLReturn(SqlConnection connection, string sqlCommand)
        {
            using (var cmd = new SqlCommand(sqlCommand, connection))
            {
                cmd.CommandTimeout = 60;
                try
                {
                    connection.Open();
                    return cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(ErrorStrings.ErrorSqlExecution, sqlCommand, ex.Message));
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
