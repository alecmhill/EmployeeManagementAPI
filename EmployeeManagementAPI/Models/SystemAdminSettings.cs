using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeManagementAPI.Models
{
    public class SystemAdminSettings
    {
        // Connection string method (no actions needed here)
        public static void SetAndOpenConnection(SqlCommand cmdSQLQuery)
        {
            String strConnString = ConfigurationManager.ConnectionStrings["cnEmployeeManagement"].ConnectionString;
            SqlConnection SQLDatabaseConnection = new SqlConnection(strConnString);
            cmdSQLQuery.Connection = SQLDatabaseConnection;
            cmdSQLQuery.CommandTimeout = 60;
            cmdSQLQuery.Connection.Open();
        }
    }
}