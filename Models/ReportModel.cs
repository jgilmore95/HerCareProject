using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Web.Mvc;
public class ReportModel
{
    public int ClientID { get; set; }

    public string FName { get; set; }

    public string LName { get; set; }

    [Display(Name="Select Help Type")]
    public IEnumerable<SelectListItem> HelpType { get; set; }

    public string SelectedHelpItem { get; set; }
}