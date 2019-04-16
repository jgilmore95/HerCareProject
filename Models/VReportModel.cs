using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace her_care.Models
{

    public class VReportModel : DBBase
    {
        public int ClientID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public Double VolunteerHours { get; set; }

        public string DateCreated { get; set; }

        public static List<VReportModel> printVReports()
        {
            return getVReport(null, null);
        }
        
        public static List<VReportModel> getVReport(VReportModel model, VReportListModel models)
        {
            SqlCommand cmd = null;

            List<VReportModel> opps = new List<VReportModel>();

            try
            {
                cmd = Connect("printVReport");
                
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = models.StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = models.EndDate;

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read() == true)
                {
                    VReportModel opp = new VReportModel();

    
                    opp.FName = rdr["FName"].ToString();
                   // var DateSub =  rdr["DateSubmitted"];

                    opp.LName = rdr["LName"].ToString();
                    opp.DateCreated = rdr["DateCreated"].ToString();
                    

                    if (String.IsNullOrEmpty(rdr["VolunteerHours"].ToString()) == false)
                    {
                        opp.VolunteerHours = Convert.ToDouble(rdr["VolunteerHours"].ToString());
                    }


                    opps.Add(opp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection(cmd);
            }
            return opps;
        }
    }
}
