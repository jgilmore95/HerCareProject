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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using her_care.Models;

namespace her_care.Controllers
{
    public class AdminLoginController : DBBase
    {
        [HttpGet]
        [Route("AdminLogin")]
        public ActionResult Index() {
            System.Diagnostics.Debug.WriteLine("Error");

            return View("/Pages/AdminLogin.cshtml");
        }

        [Route("AdminLogin/Submit")]
        [HttpPost]
        public ActionResult AdminLogin(AdminLoginModel model)
        { 
            HttpContext.Session.Remove("UserName");

            SqlCommand cmd = null;

            try
            {
                cmd = Connect("AdminLogin");

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = model.Username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = model.Password;

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows == true) {
                    HttpContext.Session.SetString("UserName", model.Username);

                    UserManagement.Username = model.Username;

                         return RedirectToPage("/AdministrationPortal");
                    

                    System.Diagnostics.Debug.WriteLine("Found Record");
                }
                else if (rdr.HasRows == false) {
                    HttpContext.Session.SetString("LoginErrorMessage", "Login / Password Is Incorrect");
                    return View("/Pages/InvalidLogin.cshtml");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection(cmd);
            }

           return View("/Pages/AdminLogin.cshtml", model);
        }
     } 
}
