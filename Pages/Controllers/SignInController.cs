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
    public class SignInController : Controller
    {
        private void InsertConsent()
        {
        }
   
        [Route("SignIn/Index")]
        [HttpPost]
        public ActionResult Submit(CSignInModel model)
        {
            CSignInModel.UserSignin(model);

            return RedirectToPage("/ThankYou");
        }
     } 
}
