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
using her_care.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace her_care.Controllers
{
    public class ThankYouController : Controller
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }

        //[Route("ThankYou")]
        public ActionResult Index(CSignInModel model)
        {
            return View();
        }
    }
}