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
        public ActionResult Search(SearchModel model)
        {
            var sql = $" SELECT PName FROM Test WHERE PName LIKE '%{model.SearchValue}%'";

            using (SqlCommand cmd = Connect(sql))
            {
                try
                {

                    cmd.CommandText = sql;

                    //    cmd.Parameters.Add("@PName", SqlDbType.VarChar, 1).Value = model.SearchValue;

                    SqlDataReader reader = cmd.ExecuteReader();

                    // Call Read before accessing data.
                    while (reader.Read())
                    {
                        ReadSingleRow((IDataRecord)reader);
                    }

                    // Call Close when done reading.
                    reader.Close();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };
            Console.WriteLine($"Search Value {model.SearchValue}");


            // var model = GetSearchResults(q);

            /*
             var users = context.Tests.Where(x => x.Name == q).OrderBy(x => x.Id);
             var user = context.Tests.FirstOrDefault(x => x.Name == q);
             */
            var x = new Object();

           TempData.Add("test3", "cool");
            return RedirectToAction("Search", "SearchResults");

           //  return View("SearchResults");
        }
        private static void ReadSingleRow(IDataRecord record)
        {
            Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
        }

    }
}