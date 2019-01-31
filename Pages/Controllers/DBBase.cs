using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Data;
using System.Reflection;
 
namespace her_care.Controllers
{
    public class DBBase : Controller
    {
    protected static SqlCommand Connect(string storedProcName)
    {
        String cnxStr = Environment.GetEnvironmentVariable("connString");

        SqlConnection cnx = new SqlConnection(cnxStr);

        cnx.Open();

        SqlCommand cmd = new SqlCommand(storedProcName, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    
         
    //      * This function allows for the user to close the connection to the database 
    //      */
    protected static void CloseConnection(SqlCommand cmd)
    {
        if (cmd != null)
        {
            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.Connection.Close();
                cmd = null;
            }
        }
    }
}
}
