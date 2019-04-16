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
    public class VReportController : Controller
    {
        private readonly HerCareContext context;
        public VReportController(HerCareContext context)
        {
            this.context = context;
        }

        // GET: Customer
        [HttpGet]
        [Route("VReport")]
        public ActionResult Index()
        {
            //temp until session is working
            if (UserManagement.IsValidAdmin == false)
            {
                return RedirectToPage("/AdminLogin");
            }

            ViewBag.VReportListModel = new her_care.Models.VReportListModel();

            return View("/Pages/VReport.cshtml");
        }

        [Route("VReport/VReportResults")]
        [HttpPost]
        public ActionResult VReportResults(VReportModel model, VReportListModel models)
        {
            /*
            var mods = new List<ReportModel>();

            var rec1 = new ReportModel();
            rec1.LName = "Bolden";
            rec1.FName = "Robert";
            rec1.Amount = 100.0;

            mods.Add(rec1);
            */

            ViewBag.MyModel = VReportModel.getVReport(model, models);

            return View();
        }
    }
}