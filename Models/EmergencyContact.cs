using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace  her_care.Models{
    public class EmergencyContact{
        [Required(ErrorMessage = "Please enter Emergency Contacts first name")]
         public string FirstNameEC{get; set;}

        [Required(ErrorMessage = "Please enter Emergency contact last Name")]
        public string LastNameEC{get; set;}

        [Required(ErrorMessage = "Please enter primary contacts relationship to you")]
        public string RelationshipEC {get; set;}

        [Required(ErrorMessage = "Please enter the Emergency Contacts living Address")]
        public string AddressEC {get; set;}

        [Required(ErrorMessage = "Please enter a city")]
        public string CityEC {get; set;}

        [Required(ErrorMessage = "Please enter a state")]
        public string StateEC {get; set;}

        [RegularExpression("[^0-9]*$", ErrorMessage = "Please enter valid zipcode")]
        public string ZipcodeEC { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter emergency's Primary phone number")]
        public string MainPhoneEC { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter emergency contact's alternate phone number")]
        public string SecondaryPhoneEC { get; set; }


        //second emergency contact 

        [Required(ErrorMessage = "Please enter Emergency Contacts first name")]
         public string FirstNameEC2 {get; set;}

        [Required(ErrorMessage = "Please enter Emergency contact last Name")]
        public string LastNameEC2{get; set;}

        [Required(ErrorMessage = "Please enter primary contacts relationship to you")]
        public string RelationshipEC2 {get; set;}

        [Required(ErrorMessage = "Please enter the Emergency Contacts living Address")]
        public string AddressEC2 {get; set;}

        [Required(ErrorMessage = "Please enter a city")]
        public string CityEC2 {get; set;}

        [Required(ErrorMessage = "Please enter a state")]
        public string StateEC2{get; set;}

        [RegularExpression("[^0-9]*$", ErrorMessage = "Please enter valid zipcode")]
        public string ZipcodeEC2 { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter emergency's Primary phone number")]
        public string MainPhoneEC2 { get; set; }

        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter emergency contact's alternate phone number")]
        public string SecondaryPhoneEC2 { get; set; }


        }
    }
