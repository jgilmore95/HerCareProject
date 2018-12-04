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

namespace her_care.Controllers
{
    public class AdministrationPortalController : DBBase
    {
        public void OnGet()
        {
         //   
        }
        private readonly HerCareContext context;
        public AdministrationPortalController(HerCareContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Search(Test model, string q)
        {
           // var model = GetSearchResults(q);
            var users = context.Tests.Where(x => x.Name == q).OrderBy(x => x.Id);
            var user = context.Tests.FirstOrDefault(x => x.Name == q);
            return View("Shared/Client");
        }

    }
}     