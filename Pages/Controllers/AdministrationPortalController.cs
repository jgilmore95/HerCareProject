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
using System.Dynamic;

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
        
        [Route("AdministrationPortal")]
        [HttpPost]
        public ActionResult SearchResults(SearchModel model)
        {

            if(model.WhichTable == "Client"){
            var searchList = her_care.Controllers.DBBaseAdmin.ClientSearch(model.SearchValue);
            ViewBag.MyModel = searchList;
            }

            if(model.WhichTable == "Volunteer"){
            var searchList = her_care.Controllers.DBBaseAdmin.VolunteerSearch(model.SearchValue);
            ViewBag.MyModel = searchList;
            }

            /*This will return entire table 
             var testList = her_care.Controllers.DBBaseAdmin.ReturnEntireTable();
           

                ViewBag.MyModel = testList;
    */
    return View();
       
        }
       

    }
}