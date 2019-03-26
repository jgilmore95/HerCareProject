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
    public class PhotoConsentController : Controller
    {
        private void InsertConsent()
        {
        }
   
        [HttpGet]
        [Route("PhotoConsent")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return RedirectToPage("/AdminLogin");
            }

            return View("/Pages/PhotoConsent.cshtml");
        }

        [Route("PhotoConsent/Index")]
        [HttpPost]
        public ActionResult Submit(VolunteerModel model)
        {
            VolunteerModel.AddVolunteer(model);
 
            return RedirectToPage("/Index");
        }
     } 
}
