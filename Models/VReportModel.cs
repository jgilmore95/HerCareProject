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

        public decimal VolunteerHours { get; set; }

        public string DateCreated { get; set; }
        public string VolEvent {get; set;}
        public string VolDescription {get; set;}
        public bool isDetail {get; set;}

        public VReportModel()
        {
        }

        public VReportModel(string volDescription, decimal volnHours)
        {
            VolDescription = volDescription;

            VolunteerHours = volnHours;
        }

        public static List<VReportModel> printVReports()
        {
            return getVReport(null, null);
        }
        
        public static List<VReportModel> getVReport(VReportModel model, VReportListModel models)
        {
            SqlCommand cmd = null;

            List<VReportModel> opps = new List<VReportModel>();

            decimal tvolhours = 0;

            if(!models.isDetail){

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

                    opp.LName = rdr["LName"].ToString();
                    opp.DateCreated = rdr["VolDate"].ToString();

                    if (String.IsNullOrEmpty(rdr["VolHours"].ToString()) == false)
                    {
                         opp.VolunteerHours = Convert.ToDecimal(rdr["VolHours"].ToString());
                    }

                    tvolhours = tvolhours + opp.VolunteerHours;

                    opps.Add(opp);
                }

                opps.Add(new VReportModel("TOTAL", tvolhours));
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
            else{
                try
            {
                cmd = Connect("printVReportDetail");
                
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = models.StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = models.EndDate;
                
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read() == true)
                {
                    VReportModel opp = new VReportModel();
                    opp.isDetail = true;
    
                    opp.FName = rdr["FName"].ToString();

                    opp.LName = rdr["LName"].ToString();
                    opp.VolEvent = rdr["VolEvent"].ToString();
                    opp.DateCreated = rdr["VolDate"].ToString();
                    opp.VolDescription = rdr["VolDescription"].ToString();

                    if (String.IsNullOrEmpty(rdr["VolHours"].ToString()) == false)
                    {
                         opp.VolunteerHours = Convert.ToDecimal(rdr["VolHours"].ToString());
                    }

                    tvolhours = tvolhours + opp.VolunteerHours;

                    opps.Add(opp);
                }

                opps.Add(new VReportModel("TOTAL", tvolhours));
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
}
