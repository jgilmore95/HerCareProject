using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace her_care.Pages
{
    public class PhotoConsentModel : PageModel
    {
         protected static OleDbCommand Connect()
        {
            String path = ConfigurationManager.ConnectionStrings["BeerBar"].ToString().Replace("[PATH]", HttpContext.Current.Request.PhysicalApplicationPath);

            OleDbConnection cnx = new OleDbConnection(path);

            cnx.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnx;
            return cmd;
        }
        /*
         * This function allows for the user to close the connection to the database 
         */
        protected static void CloseConnection(OleDbCommand cmd)
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