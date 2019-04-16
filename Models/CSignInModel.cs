using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
public class CSignInModel
{
    public int SignInId { get; set; }
   // [Display(Name="Name")]
    public string FName { get; set; }

    public string LName { get; set; }
    
    public string Organization { get; set; }

    public string Email { get; set; }

    public int BranchofService { get; set; }

    public bool isVolunteer {get; set;}

    public string VolEvent {get; set;}
    public decimal VolHours {get; set;}
    public string VolDescription {get; set;}
    

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime VolDate {get; set;}
    
}
