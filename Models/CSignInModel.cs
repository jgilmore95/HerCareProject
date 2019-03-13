using System;
using System.Data;
using System.Data.SqlClient;

namespace  her_care.Models{
    public class CSignInModel : DBBase
    {
        public int SignInId { get; set; }
    // [Display(Name="Name")]
        public string FName { get; set; }

        public string LName { get; set; }
        
        public string Organization { get; set; }

        public string Email { get; set; }

        public int BranchofService { get; set; }

        public static void UserSignin(CSignInModel model)
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
        }
    }
}