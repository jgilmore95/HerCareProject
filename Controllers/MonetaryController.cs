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

     public class MonetaryAssistanceController : DBBase

     {
public void OnGet()
        {
            //   
        }

   [HttpGet]
  // [Route("MonetaryAssistance")]
    public IActionResult Index()
        {         
            return View("MonetaryAssistance.cshtml");
        }
/* */
        [Route("MonetaryAssistance")]
        [HttpPost]
        public ActionResult SubmitMonetary(MonetaryModel model, String id){
               
               
                SqlCommand cmd = null;

              try
            {
                cmd = Connect("MonetaryInsert");

                cmd.Parameters.Add("@Services", SqlDbType.Int).Value = model.Services;
                cmd.Parameters.Add("@StaffSigMA", SqlDbType.VarChar, 50).Value = model.StaffSigMA;
                cmd.Parameters.Add("@MoneyMA", SqlDbType.Decimal).Value = model.MoneyMA;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = id;


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
 
 
           return RedirectToAction("ClientProfile", "AdministrationPortal", new {id =id});
        }

      
        
/* public class MonetaryController : Controller
    {
       public ActionResult Index()
        {            
            return View();
        }
 
        [HttpGet] 
        public ActionResult Create() 
        { 
            return View(); 
        } 

        [HttpPost] 
        public ActionResult Create(int[] departments) 
        { 
            return View(); 
        } */

     }     
 }
 