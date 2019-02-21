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
    [Route("/Shared/SearchResultsVolunteer")]
    public class SearchResultsVolunteerController : DBBase
    {
        [HttpGet]
        public ActionResult Search()
        {
           var results = TempData["SearchResultsVolunteer"];
          return Json(new { cool = "This is Search Results Volunteer", model = results });
        }         //    return View("/Shared/SearchResultsVolunteer");


    }
}