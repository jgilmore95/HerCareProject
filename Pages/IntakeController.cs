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
    public class IntakeController : Controller
    {
        [Route("submit")]
        [HttpPost]
        public ActionResult Submit(Demographics model)
        {
            Demographics.InsertIntake(model);

            return View("/Pages/Index.cshtml");
        }
    }
}