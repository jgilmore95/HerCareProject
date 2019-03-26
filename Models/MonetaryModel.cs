using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace her_care.Models{

public class MonetaryModel
{
    
    [Required(ErrorMessage = "Please Select A Service")]
    public int Services {get; set;}
    
    [Required(ErrorMessage = "Please enter the client's Full Name")]
    public string StaffSigMA {get; set;}

    [Required(ErrorMessage = "Please enter the amount provided")]
    public decimal MoneyMA {get; set;}

}

}