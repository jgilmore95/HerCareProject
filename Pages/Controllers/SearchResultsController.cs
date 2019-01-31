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
   // [Route("/Shared/SearchResults")]


    public class SearchResultsController : DBBase
    {
        [HttpGet]
         [Route("SearchResults")]
        public ActionResult Search()
        {
            String cnxStr = Environment.GetEnvironmentVariable("connString");
            SqlConnection connection = new SqlConnection(cnxStr);
            RetrieveMultipleResults(connection);
           // var results = TempData["SearchResults"];
           // return Json(new { cool = "This is where the database results will populate", model = results });
               return View("/Shared/SearchResults");

        }

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