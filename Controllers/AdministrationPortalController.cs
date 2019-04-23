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
        [HttpGet]
        [Route("AdministrationPortal")]
        public IActionResult Index(){
             if (UserManagement.IsValidAdmin == false)
            {
                return RedirectToPage("/AdminLogin");
            }

            return View("/Pages/AdministrationPortal.cshtml");
        }

        
        private readonly HerCareContext context;
        public AdministrationPortalController(HerCareContext context)
        {
            this.context = context;
        }
        
        [Route("AdministrationPortal/SearchResults")]
        [HttpPost]
        public ActionResult SearchResults(SearchModel model)
        {
            ViewBag.MyModel = her_care.Controllers.DBBaseAdmin.ClientSearch(model.SearchValue);

            /*
            if(model.isClient)
            {
               
            var searchList = her_care.Controllers.DBBaseAdmin.ClientSearch(model.SearchValue);
            ViewBag.MyModel = searchList;
            }

            if(!model.isClient)
            {
                
            var searchList = her_care.Controllers.DBBaseAdmin.VolunteerSearch(model.SearchValue);
            ViewBag.MyModel = searchList;
            }
*/
            /*This will return entire table 
             var testList = her_care.Controllers.DBBaseAdmin.ReturnEntireTable();
           

                ViewBag.MyModel = testList;
    */
    return View();
       
        }

        
       [Route("AdministrationPortal/ClientProfile")]
        public ActionResult ClientProfile(String id)
        {
           
          // var testvar = model.Id;
           /*
            if(isClient)
            {

            

            }
            if(!isClient)
            {
            var searchList = her_care.Controllers.DBBaseAdmin.VolunteerDetails(id);
            ViewBag.MyModel = searchList;
            }
           
           */
           var searchList = her_care.Controllers.DBBaseAdmin.ClientDetails(id);
            ViewBag.MyModel = searchList;
           
            return View();
        }

        [Route("AdministrationPortal/VolunteerProfile")]
        public ActionResult volunteerProfile(String id)
        {
           
          // var testvar = model.Id;
           /*
            if(isClient)
            {

            

            }
            if(!isClient)
            {
            var searchList = her_care.Controllers.DBBaseAdmin.VolunteerDetails(id);
            ViewBag.MyModel = searchList;
            }
           
           */
           var searchList = her_care.Controllers.DBBaseAdmin.VolunteerDetails(id);
            ViewBag.MyModel = searchList;
           
            return View();
        }

        [Route("EditClient")]      
        [HttpGet]
        public ActionResult EditClient(Demographics model, String id)
        {
            var searchList = her_care.Controllers.DBBaseAdmin.ClientDetails(id);
            ViewBag.MyModel = searchList;


    




            return View();
        }

        [Route("EditClient")]
        [HttpPost]
        public ActionResult Update(Demographics model, String id)
        {
            /*If anyone is looking at this and wondering why in the world. I'm asking that myself. 
            Just forgive me for I have sinned. plz */


            var searchList = her_care.Controllers.DBBaseAdmin.ClientDetails("12");
            SqlCommand cmd = null;

            try
            {
                cmd = Connect("ClientUpdate");
                if(@model.FirstName == null)
                {
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = searchList[0].FirstName;
                }
                else
                {
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = model.FirstName;
                }
                
                if(@model.LastName == null)
                {
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = searchList[0].LastName;
                }
                else
                {
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = model.LastName;
                }

              //  cmd.Parameters.Add("@TodaysDate", SqlDbType.Date).Value = model.TodaysDate;
              if(model.DateOfBirth == null){
                  cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = searchList[0].DateOfBirth;
              }
              else
              {
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = model.DateOfBirth;
              }

                if(model.Phone == null)
                {
                    cmd.Parameters.Add("@Phone", SqlDbType.Char, 12).Value = searchList[0].Phone;
                }
                else
                {
                    cmd.Parameters.Add("@Phone", SqlDbType.Char, 12).Value = model.Phone;
                }

                if(model.EmailAddress == null)
                {
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 250).Value = searchList[0].EmailAddress;
                }
                else
                {
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 250).Value = model.EmailAddress;
                }

                if(model.AddressOne == null)
                {
                    cmd.Parameters.Add("@AddressOne", SqlDbType.VarChar, 100).Value = searchList[0].AddressOne;
                }
                else
                {
                    cmd.Parameters.Add("@AddressOne", SqlDbType.VarChar, 100).Value = model.AddressOne;
                }

                if(model.City == null)
                {
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = searchList[0].City;
                }
                else
                {
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = model.City;
                }

                cmd.Parameters.Add("@State", SqlDbType.Int).Value = model.State;

                if(model.Zip == 0)
                {
                    cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = searchList[0].Zip;
                }
                else
                {
                    cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = model.Zip;
                }
                
                
                if(model.EmergencyContactFirst == null)
                {
                    cmd.Parameters.Add("@ECFName", SqlDbType.VarChar, 50).Value = searchList[0].EmergencyContactFirst;
                }
                else
                {
                    cmd.Parameters.Add("@ECFName", SqlDbType.VarChar, 50).Value = model.EmergencyContactFirst;
                }

                if(model.EmergencyContactLast == null)
                {
                    cmd.Parameters.Add("@ECLName", SqlDbType.VarChar, 50).Value = searchList[0].EmergencyContactLast;
                }
                else
                {
                    cmd.Parameters.Add("@ECLName", SqlDbType.VarChar, 50).Value = model.EmergencyContactLast;
                }

                if(model.EmergencyContactPhone == null)
                {
                    cmd.Parameters.Add("@ECPhone", SqlDbType.Char, 12).Value = searchList[0].EmergencyContactPhone;
                }
                else
                {
                    cmd.Parameters.Add("@ECPhone", SqlDbType.Char, 12).Value = model.EmergencyContactPhone;
                }

                if(model.BranchOfService == null)
                {
                    cmd.Parameters.Add("@BranchOfService", SqlDbType.VarChar, 30).Value = searchList[0].BranchOfService;
                }
                else
                {
                    cmd.Parameters.Add("@BranchOfService", SqlDbType.VarChar, 30).Value = model.BranchOfService;
                }
                

                
                
                
                
                
                
                
                
                cmd.Parameters.Add("@EntryDate", SqlDbType.Date).Value = model.EntryDate;               
                cmd.Parameters.Add("@DischargeDate", SqlDbType.Date).Value = model.DischargeDate;
                cmd.Parameters.Add("@DisabilityRating", SqlDbType.Int).Value = model.DisabilityRating;
                cmd.Parameters.Add("@ActiveDuty", SqlDbType.Bit).Value = model.ActiveDuty;
                cmd.Parameters.Add("@Reserves", SqlDbType.Bit).Value = model.Reserves;
                cmd.Parameters.Add("@NationalGuard", SqlDbType.Bit).Value = model.NationalGuard;
                cmd.Parameters.Add("@Employed", SqlDbType.Bit).Value = model.Employed;
                cmd.Parameters.Add("@Student", SqlDbType.Bit).Value = model.Student;
                cmd.Parameters.Add("@SelfEmployed", SqlDbType.Bit).Value = model.SelfEmployed;
                cmd.Parameters.Add("@Contractor", SqlDbType.Bit).Value = model.Contractor;
                cmd.Parameters.Add("@WorkStudy", SqlDbType.Bit).Value = model.WorkStudy;
                cmd.Parameters.Add("@Intern", SqlDbType.Bit).Value = model.Intern;
                cmd.Parameters.Add("@Unemployed", SqlDbType.Bit).Value = model.Unemployed;
                cmd.Parameters.Add("@OtherEmployed", SqlDbType.Bit).Value = model.OtherEmployed;
                cmd.Parameters.Add("@OnStreet", SqlDbType.Bit).Value = model.OnStreet;
                cmd.Parameters.Add("@SofaSurfing", SqlDbType.Bit).Value = model.SofaSurfing;
                cmd.Parameters.Add("@CombatVet", SqlDbType.Bit).Value = model.CombatVet;
                cmd.Parameters.Add("@Shelter", SqlDbType.Bit).Value = model.Shelter;
                cmd.Parameters.Add("@TransitHousing", SqlDbType.Bit).Value = model.TransitionalHousing;
                cmd.Parameters.Add("@GroupHome", SqlDbType.Bit).Value = model.GroupHome;
                cmd.Parameters.Add("@Rental", SqlDbType.Bit).Value = model.Rental;
                cmd.Parameters.Add("@OwnHome", SqlDbType.Bit).Value = model.OwnHome;
                cmd.Parameters.Add("@OtherLiving", SqlDbType.Bit).Value = model.OtherLiving;
                cmd.Parameters.Add("@FriendsOrRelatives", SqlDbType.Bit).Value = model.FriendsOrRelatives;
                cmd.Parameters.Add("@Alone", SqlDbType.Bit).Value = model.Alone;
                cmd.Parameters.Add("@Temporary", SqlDbType.Bit).Value = model.Temporary;
                cmd.Parameters.Add("@Permanent", SqlDbType.Bit).Value = model.Permanent;
                cmd.Parameters.Add("@BusinessResources", SqlDbType.Bit).Value = model.BusinessResources;
                cmd.Parameters.Add("@DayCare", SqlDbType.Bit).Value = model.DayCare;
                cmd.Parameters.Add("@Housing", SqlDbType.Bit).Value = model.Housing;
                cmd.Parameters.Add("@Clothing", SqlDbType.Bit).Value = model.Clothing;
                cmd.Parameters.Add("@DisabilityClaim", SqlDbType.Bit).Value = model.DisabilityClaim;
                cmd.Parameters.Add("@Legal", SqlDbType.Bit).Value = model.Legal;
                cmd.Parameters.Add("@Counseling", SqlDbType.Bit).Value = model.Counseling;
                cmd.Parameters.Add("@EducateOrVRehab", SqlDbType.Bit).Value = model.EducationalOrVocationalRehab;
                cmd.Parameters.Add("@Utilities", SqlDbType.Bit).Value = model.Utilities;
                cmd.Parameters.Add("@Food", SqlDbType.Bit).Value = model.Food;
                cmd.Parameters.Add("@Employment", SqlDbType.Bit).Value = model.Employment;
                cmd.Parameters.Add("@Transportation", SqlDbType.Bit).Value = model.Transportation;
                cmd.Parameters.Add("@OtherService", SqlDbType.Bit).Value = model.OtherService;
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = 12;

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


            return RedirectToAction("ClientProfile", "AdministrationPortal", new {id = 12});
        }

  //      [Route("MonetaryAssistance")]
        // public ActionResult viewMonetary()
        // {
        //     return RedirectToAction("MonetaryAssistance.cshtml", "Monetary");
        // }
       

    }
}