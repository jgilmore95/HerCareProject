using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace her_care.Controllers
{
    public class ReportController : Controller
    {
        // GET: Customer
        [HttpGet]
        [Route("Report")]
        public ActionResult Index()
        {
            return View("/Pages/Report.cshtml", new List<her_care.Models.ReportModel>());
        }
    }
}