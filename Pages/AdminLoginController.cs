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
        public ActionResult Index() {

            System.Diagnostics.Debug.WriteLine("Error");

            return View();
        }

        [Route("AdminLogin/Submit")]
        [HttpPost]
        public ActionResult Submit(AdminLoginModel model)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Connect("AdminLogin");

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = model.Username;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = model.Password;

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows == true) {
                         return RedirectToPage("/Index");
                    
                    //System.Diagnostics.Debug.WriteLine("Found Record");
                }
                else {
                   
                    ViewBag.Message = "UserName or password is wrong";
                    ModelState.AddModelError("Error", "Wrong");
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
 
           return View();
        }
     } 
}
