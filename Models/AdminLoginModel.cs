using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

public class AdminLoginModel : PageModel
{
    public int AdminId { get; set; }
   // [Display(Name="Name")]
    public string Username { get; set; }

    public string Password { get; set; }

    public string ErrorMsg { get; set; }

    public string GetErrorMessage() {

        var msg = "";

        if (HttpContext != null) {
            
            msg = HttpContext.Session.GetString("LoginErrorMessage");
        }

        return msg;
    }
}
