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
    public class ReportController : Controller
    {
        private readonly HerCareContext context;
        public ReportController(HerCareContext context)
        {
            this.context = context;
        }

        // GET: Customer
        [HttpGet]
        [Route("Report")]
        public ActionResult Index()
        {
            //temp until session is working
            if (UserManagement.IsValidAdmin == false)
            {
                return RedirectToPage("/AdminLogin");
            }

            ViewBag.ReportListModel = new her_care.Models.ReportListModel();

            return View("/Pages/Report.cshtml");
        }

        [Route("Report/ReportResults")]
        [HttpPost]
        public ActionResult ReportResults(ReportModel model, ReportListModel models)
        {
            /*
            var mods = new List<ReportModel>();

            var rec1 = new ReportModel();
            rec1.LName = "Bolden";
            rec1.FName = "Robert";
            rec1.Amount = 100.0;

            mods.Add(rec1);
            */

            ViewBag.MyModel = ReportModel.getReport(model, models);

            return View();
        }
    }
}