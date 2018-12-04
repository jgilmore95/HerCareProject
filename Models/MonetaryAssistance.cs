using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace her_care.Models{

public class MonetaryAssistance
{
    [Required(ErrorMessage = "Please enter the client's first name")]
     public string FirstNameMA {get; set;}

    [Required(ErrorMessage = "Please enter client's last name")]
    public string LastNameMA {get; set;}
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime MonetaryDate { get; set; }

    [Required]
    [RegularExpression("[^0-9]*$", ErrorMessage = "Please enter valid street address")]
    public string streetNumberMA { get; set; }

    [Required(ErrorMessage = "Please enter street's name")]
     public string StreetNameMA {get; set;}

     [Required]
    [RegularExpression("[^0-9]*$", ErrorMessage = "Please enter valid street address")]
    public string ZipcodeMA { get; set; }

    [Required(ErrorMessage = "Please enter state's name")]
     public string StateMA {get; set;}

     [Required (ErrorMessage="Required")]
     [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter a phone number")]
    public string PhoneMA { get; set; }

    [Required(ErrorMessage = "Must provide an e-mail address")]   
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
    public string EmailMA { get; set; }

    [Required(ErrorMessage = "Please enter amount provided $000.00")]
    public decimal MoneyMA {get; set;}

    [Required(ErrorMessage = "Please enter the client's Full Name")]
    public string ClientSigMA {get; set;}

    [Required(ErrorMessage = "Please enter the client's Full Name")]
    public string StaffSigMA {get; set;}

}

}