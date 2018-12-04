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
    public class PhotoConsentController : DBBase
    {
        private void InsertConsent()
        {
        }
   
        [Route("PhotoConsent/Index")]
        [HttpPost]
        public ActionResult Submit(VolunteerModel model)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Connect();

                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = model.FName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = model.LName;
                cmd.Parameters.Add("@Testimonial", SqlDbType.Bit).Value = model.TestimonialConsent;
                cmd.Parameters.Add("@Engage", SqlDbType.Bit).Value = model.EngageConsent;
                cmd.Parameters.Add("@Media", SqlDbType.Bit).Value = model.MediaConsent;
                cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 50).Value = model.VolunteerSignature;

                cmd.CommandText = "VolunteerInsert";

                cmd.CommandType = CommandType.StoredProcedure;

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

           return null;
        }
     } 
}
