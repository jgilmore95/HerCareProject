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
    public class IntakeController : DBBase
    {
        [Route("submit")]
        [HttpPost]
        public ActionResult Submit(Demographics model){
                SqlCommand cmd = null;

              try
            {
                cmd = Connect("ClientInsert");

                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = model.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = model.LastName;
                cmd.Parameters.Add("@TodaysDate", SqlDbType.Date).Value = model.TodaysDate;
                cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = model.DateOfBirth;
                cmd.Parameters.Add("@Phone", SqlDbType.Int).Value = model.Phone;
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 250).Value = model.EmailAddress;
                cmd.Parameters.Add("@AddressOne", SqlDbType.VarChar, 100).Value = model.AddressOne;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = model.City;
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = model.State;
                cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = model.Zip;
                cmd.Parameters.Add("@ECFName", SqlDbType.VarChar, 50).Value = model.EmergencyContactFirst;
                cmd.Parameters.Add("@ECLName", SqlDbType.VarChar, 50).Value = model.EmergencyContactLast;
                cmd.Parameters.Add("@ECPhone", SqlDbType.Int).Value = model.EmergencyContactPhone;
                cmd.Parameters.Add("@BranchOfService", SqlDbType.VarChar, 30).Value = model.EmergencyContactLast;
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
                cmd.Parameters.Add("@FirendsOrRelatives", SqlDbType.Bit).Value = model.FriendsOrRelatives;
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