using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace her_care.Models
{

    public class ReportModel : DBBase
    {
        public int ClientID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public Double Amount { get; set; }

        public string HelpType { get; set; }

        public string DateSubmitted { get; set; }

        public ReportModel()
        {
        }

        public ReportModel(string lname, Double Price)
        {
            HelpType = lname;

            Amount = Price;
        }
        public static List<ReportModel> printReports()
        {
            return getReport(null, null);
        }
        
        public static List<ReportModel> getReport(ReportModel model, ReportListModel models)
        {
            SqlCommand cmd = null;

            List<ReportModel> opps = new List<ReportModel>();
            
            Double totalPrice = 0;

            try
            {
                cmd = Connect("printReport");
                
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = models.StartDate;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = models.EndDate;

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while (rdr.Read() == true)
                {
                    ReportModel opp = new ReportModel();

    
                    opp.FName = rdr["FName"].ToString();

                    opp.LName = rdr["LName"].ToString();
                    opp.DateSubmitted = rdr["DateSubmitted"].ToString();
                    

                    if (String.IsNullOrEmpty(rdr["ServiceAmount"].ToString()) == false)
                    {
                        opp.Amount = Convert.ToDouble(rdr["ServiceAmount"].ToString());
                    }

                    totalPrice = totalPrice + opp.Amount;

                    opp.HelpType = rdr["HelpType"].ToString();

                    opps.Add(opp);
                }

                opps.Add(new ReportModel("TOTAL", totalPrice));
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
