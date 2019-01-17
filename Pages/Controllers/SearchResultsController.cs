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
    [Route("SearchResult")]
    public class SearchResultsController : DBBase
    {
        [HttpGet]
        [Route("Search")]
        public ActionResult Search()
        {
            var results = TempData["SearchResults"];
            return Json(new { cool = true, model = results });


        }

    }
}