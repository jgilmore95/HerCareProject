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
    public class AdminLoginController : Controller
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
            //HttpContext.Session.Remove("UserName");

            if (AdminLoginModel.AdminLogin(model) == true)
            {
                UserManagement.Username = model.Username;

                return RedirectToPage("/Index");
            }

        //model.ErrorMsg = "Invalid Login - Please Try Again";
        
        return View("/Pages/InvalidLogin.cshtml");

            //return View("/Pages/InvalidLogin.cshtml");
        }
     } 
}
