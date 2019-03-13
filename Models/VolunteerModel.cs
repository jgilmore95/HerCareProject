using System;
using System.Data;
using System.Data.SqlClient;

namespace her_care.Models
{
    public class VolunteerModel : DBBase
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

        public static void AddVolunteer(VolunteerModel model)
        {
            SqlCommand cmd = null;

            try
            {
                cmd = Connect("VolunteerInsert");

                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = model.FName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = model.LName;
                cmd.Parameters.Add("@Testimonial", SqlDbType.Bit).Value = model.TestimonialConsent;
                cmd.Parameters.Add("@Engage", SqlDbType.Bit).Value = model.EngageConsent;
                cmd.Parameters.Add("@Media", SqlDbType.Bit).Value = model.MediaConsent;
                cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 50).Value = model.VolunteerSignature;

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

        public static void AddVolunteerHours(VolunteerModel model)
        {
                        SqlCommand cmd = null;

            try
            {
                cmd = Connect("VolunteerHoursInsert");

                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = model.FName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = model.LName;
                cmd.Parameters.Add("@Testimonial", SqlDbType.Bit).Value = model.TestimonialConsent;

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