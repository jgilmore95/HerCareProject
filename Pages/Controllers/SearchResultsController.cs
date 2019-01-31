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
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace her_care.Controllers
{
   // [Route("/Shared/SearchResults")]


    public class SearchResultsController : Controller
    {
      //  private HerCareContext db = new HerCareContext();
   
      private readonly HerCareContext context;
        public SearchResultsController(HerCareContext context)
        {
            this.context = context;
        }

        [HttpGet]
         [Route("SearchResults")]
         public ActionResult Search()
         { 
             
             
             string queryString = "Select * from Test";
             string sqlString = Environment.GetEnvironmentVariable("connString");

            using (SqlConnection connection = new SqlConnection(sqlString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                        }
                    }
                    reader.Close();
                }
            }
             
             
             
             
             
             /*
             var model = new List<testing>;

             model.Add(context.Tests.ToList());
               //  var testing = context.Tests.ToList();
             */
             return View("SearchResults");

/*
             using(var contxt = new HerCareContext())
             {
              //   var firstname = context.Tests.Where(x => x.PName).OrderBy(x => x.Id);
               //  var test = contxt.Database.SqlQuery("SELECT * FROM dbo.Test").ToList();

               var query = contxt.Tests.where(s => s.PName == "Jack").FirstOrDefault<Test>();
             }
             return View(query);
*/
            // return View(context.Tests.ToList());

             /*
             String connectionString = Environment.GetEnvironmentVariable("connString");
            String sql = "SELECT * FROM Test";
            SqlCommand cmd = new SqlCommand(sql, conn);

            var model = new List<Test>();
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    var test = new Test();
                    test.PName = rdr["PName"].ToString();
                    test.Age = Convert.ToInt32(rdr["Age"]);
                    test.num = Convert.ToInt32(rdr["num"]);

                    model.Add(test);
                }
            }
            return View(model);

            */
         }
         /*
        public ActionResult Search()
        {
            String cnxStr = Environment.GetEnvironmentVariable("connString");
            SqlConnection connection = new SqlConnection(cnxStr);
            RetrieveMultipleResults(connection);
           // var results = TempData["SearchResults"];
           // return Json(new { cool = "This is where the database results will populate", model = results });
               return View("/Shared/SearchResults");

        }*/

        static void RetrieveMultipleResults(SqlConnection connection)
        {
            using (connection)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT ID, PName FROM dbo.Test;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.HasRows)
                {
                    Console.WriteLine("\t{0}\t{1}", reader.GetSqlValue(0),
                        reader.GetSqlValue(1));

/*
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader.GetSqlValue(0),
                            reader.GetSqlValue(1));
                    }
                    */
                    reader.NextResult();
                }
            }
        }

    }
}