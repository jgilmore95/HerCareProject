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
    public class VolunteerController : DBBase
    {
         private void InsertVolunteerHours()
        {
        }

        [Route("VolunteerManage/Index")]
        [HttpPost]
        public ActionResult Submit(VolunteerModel model)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Connect("VolunteerHoursInsert");

                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = model.FName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = model.LName;
                cmd.Parameters.Add("@Testimonial", SqlDbType.Bit).Value = model.TestimonialConsent;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection(cmd);
            }
 
 
           return View();
        }

        // public ActionResult VolunteerManage()
        // {
        //     Volunteer c1 = 
        //                     new Volunteer {
        //                         VolunteerFisrtname = "M",
        //                         VolunteerLastname = "S"
        //                     };
        //     return View(c1);
        // }


    }
}