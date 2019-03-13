using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{
    public class Demographics : DBBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TodaysDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string EmailAddress { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public string EmergencyContactFirst { get; set; }
        public string EmergencyContactLast { get; set; }
        public int EmergencyContactPhone { get; set; }
        public string BranchOfService { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EntryDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DischargeDate { get; set; }
        public string DischargeType { get; set; }
        public Boolean CombatVet { get; set; }
        public int DisabilityRating { get; set; }
        public Boolean ActiveDuty { get; set; } //were you or are you on active duty, reserves, or national guard
        public Boolean Reserves { get; set; }
        public Boolean NationalGuard { get; set; }
        public Boolean Employed { get; set; }
        public Boolean Student { get; set; }
        public Boolean SelfEmployed { get; set; }
        public Boolean Contractor { get; set; }
        public Boolean WorkStudy { get; set; }
        public Boolean Intern { get; set; }
        public Boolean Unemployed { get; set; }
        public string OtherEmployed { get; set; }
        public Boolean OnStreet { get; set; }
        public Boolean SofaSurfing { get; set; }
        public Boolean Shelter { get; set; }
        public Boolean TransitionalHousing { get; set; }
        public Boolean GroupHome { get; set; }
        public Boolean Rental { get; set; }
        public Boolean OwnHome { get; set; }
        public string OtherLiving { get; set; }
        public Boolean FriendsOrRelatives { get; set; }
        public Boolean Alone { get; set; }
        public Boolean Temporary { get; set; }
        public Boolean Permanent { get; set; }
        public Boolean BusinessResources { get; set; }
        public Boolean DayCare { get; set; }
        public Boolean Housing { get; set; }
        public Boolean Clothing { get; set; }
        public Boolean DisabilityClaim { get; set; }
        public Boolean Legal { get; set; }
        public Boolean Counseling { get; set; }
        public Boolean EducationalOrVocationalRehab { get; set; }
        public Boolean Utilities { get; set; }
        public Boolean Food { get; set; }
        public Boolean Employment { get; set; }
        public Boolean Transportation { get; set; }
        public string OtherService { get; set; }

        public static void InsertIntake(Demographics model)
        {
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
        }
    }

    public class CurrentEmploymentStatus
    {
        public Boolean Employed { get; set; }
        public Boolean Student { get; set; }
        public Boolean SelfEmployed { get; set; }
        public Boolean Contractor { get; set; }
        public Boolean WorkStudy { get; set; }
        public Boolean Intern { get; set; }
        public Boolean Unemployed { get; set; }
        public string Other { get; set; }
    }

    public class LivingSituation
    {
        public Boolean OnStreet { get; set; }
        public Boolean SofaSurfing { get; set; }
        public Boolean Shelter { get; set; }
        public Boolean TransitionalHousing { get; set; }
        public Boolean GroupHome { get; set; }
        public Boolean Rental { get; set; }
        public Boolean OwnHome { get; set; }
        public string Other { get; set; }
    }

    public class LivingArrangments
    {
        public Boolean FriendsOrRelatives { get; set; }
        public Boolean Alone { get; set; }
        public Boolean Temporary { get; set; }
        public Boolean Permanent { get; set; }
    }

    public class ServiceNeeds
    {
        public Boolean BusinessResources { get; set; }
        public Boolean DayCare { get; set; }
        public Boolean Housing { get; set; }
        public Boolean Clothing { get; set; }
        public Boolean DisablilityClaim { get; set; }
        public Boolean Legal { get; set; }
        public Boolean Counseling { get; set; }
        public Boolean EducationalOrVocationalRehab { get; set; }
        public Boolean Utilities { get; set; }
        public Boolean Food { get; set; }
        public Boolean Employment { get; set; }
        public Boolean Tranportation { get; set; }
        public string Other { get; set; }
    }

    public class OfficeUseOnly
    {
        public Boolean Email { get; set; }
        public Boolean InPerson { get; set; }
        public Boolean Phone { get; set; }
        public string ActionNotes { get; set; }
        public string CompletedBy { get; set; }
        public DateTime DateCompleted { get; set; }
        public string FollowUpNotes { get; set; }
    }
}