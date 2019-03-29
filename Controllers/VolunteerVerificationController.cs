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

 namespace her_care.Controllers {

     public class VolunteerVerificationController : DBBase

     {
public void OnGet()
        {
            //   
        }

    [HttpGet]
    public IActionResult Index()
        {            
            return View();
        }

        [Route("VolunteerVerification/Index")]
        [HttpPost]
        public ActionResult SubmitHours(VolunteerVerification model){
                SqlCommand cmd = null;

              try
            {
                cmd = Connect("VolunteerHoursInsert");

                cmd.Parameters.Add("@FNameVV", SqlDbType.VarChar, 50).Value = model.FirstNameVV;
                cmd.Parameters.Add("@LNameVV", SqlDbType.VarChar, 50).Value = model.LastNameVV;
                cmd.Parameters.Add("@VolunteerEvent", SqlDbType.VarChar, 100).Value = model.VolunteerAgency;
                cmd.Parameters.Add("@Hours", SqlDbType.Decimal).Value = model.HoursCompleted;
                cmd.Parameters.Add("@VolDate", SqlDbType.Date).Value = model.VolunteerDate;
                cmd.Parameters.Add("@Description", SqlDbType.VarChar, 200).Value = model.DescriptionService;
                cmd.Parameters.Add("@VolunteerSig", SqlDbType.VarChar, 50).Value = model.VolunteerSignature;
               


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
 
 
           return View("/Pages/Index.cshtml");  
        }
     }
 }