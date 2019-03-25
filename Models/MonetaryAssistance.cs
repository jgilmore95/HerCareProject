using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace her_care.Models{

public class MonetaryAssistance
{
    
    [Required(ErrorMessage = "Please Select A Service")]
    public int Services {get; set;}
    
    [Required(ErrorMessage = "Please enter the client's Full Name")]
    public string StaffSigMA {get; set;}

    [Required(ErrorMessage = "Please enter the amount provided")]
    public decimal MoneyMA {get; set;}

}

}