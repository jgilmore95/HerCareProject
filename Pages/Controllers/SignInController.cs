using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Data;
using her_care.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace her_care.Controllers
{
    public class SignInController : DBBase
    {
        private void InsertConsent()
        {
        }
   
        [Route("SignIn/Index")]
        [HttpPost]
        public ActionResult Submit(CSignInModel model)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Connect("CSignInINSERT");

                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = model.FName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = model.LName;
                cmd.Parameters.Add("@Organization", SqlDbType.VarChar, 150).Value = model.Organization;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 75).Value = model.Email;
                cmd.Parameters.Add("@BranchID", SqlDbType.Int).Value = model.BranchofService;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection(cmd);
            }
            
            return RedirectToPage("/ThankYou");
        }
     } 
}
