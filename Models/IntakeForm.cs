using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


    public class Demographics
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TodaysDate {get; set;}
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth {get; set;}
        public int Phone {get; set;}
        public string EmailAddress {get; set;}
        public string AddressOne { get; set; }
         public string AddressTwo { get; set; }
         public string City { get; set; }
         public int State { get; set; }
         public int Zip { get; set; }
         public string EmergencyContactFirst {get; set;}
         public string EmergencyContactLast {get; set;}
         public int EmergencyContactPhone {get; set;}
         public string BranchOfService {get; set;}
         [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateTime EntryDate {get; set;}
         [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateTime DischargeDate {get; set;}
         public string DischargeType {get; set;}
         public Boolean CombatVet {get; set;}
         public int DisabilityRating {get; set;}
         public Boolean ActiveDuty {get; set;} //were you or are you on active duty, reserves, or national guard
        public Boolean Reserves {get; set;} 
        public Boolean NationalGuard {get; set;} 
          public Boolean Employed {get; set;}
        public Boolean Student {get; set;}
        public Boolean SelfEmployed {get; set;}
        public Boolean Contractor {get; set;}
        public Boolean WorkStudy {get; set;}
        public Boolean Intern {get; set;}
        public Boolean Unemployed {get; set;}
        public Boolean OtherEmployed {get; set;}
         public Boolean OnStreet {get; set;}
        public Boolean SofaSurfing {get; set;}
        public Boolean Shelter {get; set;}
        public Boolean TransitionalHousing {get; set;}
        public Boolean GroupHome {get; set;}
        public Boolean Rental {get; set;}
        public Boolean OwnHome {get; set;}
        public Boolean OtherLiving {get; set;}
         public Boolean FriendsOrRelatives {get; set;}
        public Boolean Alone {get; set;}
        public Boolean Temporary {get; set;}
        public Boolean Permanent {get; set;}
        public Boolean BusinessResources {get; set;}
        public Boolean DayCare {get; set;}
        public Boolean Housing {get; set;}
        public Boolean Clothing {get; set;}
        public Boolean DisabilityClaim {get; set;}
        public Boolean Legal {get; set;}
        public Boolean Counseling {get; set;}
        public Boolean EducationalOrVocationalRehab {get; set;}
        public Boolean Utilities {get; set;}
        public Boolean Food {get; set;}
        public Boolean Employment {get; set;}
        public Boolean Transportation {get; set;}
        public Boolean OtherService {get; set;}



//-------------------------------------
        public int Id {get; set;}
        public bool isClient {get; set;}

        
        public int ID {get; set;}
    
    }

    public class CurrentEmploymentStatus
    {
        public Boolean Employed {get; set;}
        public Boolean Student {get; set;}
        public Boolean SelfEmployed {get; set;}
        public Boolean Contractor {get; set;}
        public Boolean WorkStudy {get; set;}
        public Boolean Intern {get; set;}
        public Boolean Unemployed {get; set;}
        public string Other {get; set;}
    }

    public class LivingSituation
    {
        public Boolean OnStreet {get; set;}
        public Boolean SofaSurfing {get; set;}
        public Boolean Shelter {get; set;}
        public Boolean TransitionalHousing {get; set;}
        public Boolean GroupHome {get; set;}
        public Boolean Rental {get; set;}
        public Boolean OwnHome {get; set;}
        public string Other {get; set;}
    }
    
    public class LivingArrangments
    {
        public Boolean FriendsOrRelatives {get; set;}
        public Boolean Alone {get; set;}
        public Boolean Temporary {get; set;}
        public Boolean Permanent {get; set;}
    }

    public class ServiceNeeds
    {
        public Boolean BusinessResources {get; set;}
        public Boolean DayCare {get; set;}
        public Boolean Housing {get; set;}
        public Boolean Clothing {get; set;}
        public Boolean DisablilityClaim {get; set;}
        public Boolean Legal {get; set;}
        public Boolean Counseling {get; set;}
        public Boolean EducationalOrVocationalRehab {get; set;}
        public Boolean Utilities {get; set;}
        public Boolean Food {get; set;}
        public Boolean Employment {get; set;}
        public Boolean Tranportation {get; set;}
        public string Other {get; set;}
    }

    public class OfficeUseOnly
    {
        public Boolean Email {get; set;}
        public Boolean InPerson {get; set;}
        public Boolean Phone {get; set;}
        public string ActionNotes {get; set;}
        public string CompletedBy {get; set;}
        public DateTime DateCompleted {get; set;}
        public string FollowUpNotes {get; set;}
    }
    
