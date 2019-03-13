using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace her_care.Models
{
    public class AdminLoginModel : DBBase
    {
        public int AdminId { get; set; }
        // [Display(Name="Name")]
        public string Username { get; set; }

        public string Password { get; set; }

        public string ErrorMsg { get; set; }

        public static bool AdminLogin(AdminLoginModel model)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Connect("AdminLogin");

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = model.Username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = model.Password;

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return rdr.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
            finally
            {
                CloseConnection(cmd);
            }
        }
    }
}