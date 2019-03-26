using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using Microsoft.AspNetCore.Mvc;

namespace her_care.Models
{
    public class ReportModel : DBBase
    {
        public int ClientID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public Double Amount { get; set; }

        public int HelpType { get; set; }

        public static List<ReportModel> printReports()
        {
            return getReport(null);
        }

        public static List<ReportModel> getReport(ReportModel model)
        {
            SqlCommand cmd = null;

            List<ReportModel> opps = new List<ReportModel>();

            try
            {
                cmd = Connect("printReport");

                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


                while (rdr.Read() == true)
                {
                    ReportModel opp = new ReportModel();

                    opp.FName = rdr["FName"].ToString();
                    opp.LName = rdr["LName"].ToString();
                    opp.Amount = Convert.ToDouble(rdr["Amount"].ToString());
                    opp.HelpType = Convert.ToInt32(rdr["HelpType"].ToString());

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
