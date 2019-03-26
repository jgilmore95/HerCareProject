public class VolunteerModel
{
    public int VolunteerId { get; set; }
   // [Display(Name="Name")]
    public string FName { get; set; }

    public string LName { get; set; }

    public bool TestimonialConsent { get; set; }

    public bool EngageConsent { get; set; }

    public bool MediaConsent { get; set; }
    
    public string VolunteerSignature { get; set; }

    public string DateCreated { get; set; }


    //-------------------
    public bool isClient {get; set;}
}
