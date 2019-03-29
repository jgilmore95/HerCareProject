using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{

public class VolunteerVerification
{
public string FirstNameVV { get; set;}
public string LastNameVV { get; set; }
public string VolunteerAgency { get; set;}
public decimal HoursCompleted {get; set;}
public DateTime VolunteerDate {get; set;}
public  string DescriptionService {get; set;}
public  string VolunteerSignature {get; set;}

}

}//end namespace