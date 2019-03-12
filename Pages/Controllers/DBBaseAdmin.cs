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
using System.Reflection;
using her_care.Models;
 
namespace her_care.Controllers
{
    public class DBBaseAdmin : DBBase
    {
        /*
        This method returns the entire table
         */
        public static List<Test> ReturnEntireTable()
        {
            SqlCommand cmd = null;
            List<Test> opps = new List<Test>();

            try{
                 cmd = openConnection();

                cmd.CommandText = "SELECT [Test].Id, [Test].PName, [Test].Age, [Test].num FROM Test";
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while(rdr.Read() == true)
                {
                    Test opp = new Test();
                    
                    opp.Id = Convert.ToInt32(rdr["Id"].ToString());
                    opp.PName = rdr["PName"].ToString();
                    opp.Age = Convert.ToInt32(rdr["Age"].ToString());
                    opp.num = Int32.Parse(rdr["num"].ToString());

                    opps.Add(opp);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally{
                CloseConnection(cmd);
            }
            return opps;
        }

        /*
        this method is ready for the Client table. Just change from Test table to CLient
         */
        // public static List<Test> UserSearch(string searchTerm)
        // {
        //       SqlCommand cmd = null;
        //     List<Test> opps = new List<Test>();

        //     try{
        //          cmd = openConnection();

        //         cmd.CommandText = "SELECT * FROM Test WHERE [Test].Pname like '"+ searchTerm + "%'";
        //         cmd.CommandType = System.Data.CommandType.Text;

        //         SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

        //         while(rdr.Read() == true)
        //         {
        //             Test opp = new Test();

        //             opp.Id = Convert.ToInt32(rdr["Id"].ToString());
        //             opp.PName = rdr["PName"].ToString();
        //             opp.Age = Convert.ToInt32(rdr["Age"].ToString());
        //             opp.num = Int32.Parse(rdr["num"].ToString());

        //             opps.Add(opp);
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         throw;
        //     }
        //     finally{
        //         CloseConnection(cmd);
        //     }
        //     return opps;
        // }


        // Mahmood
        public static List<Volunteer> UserSearch(string searchTerm)
        {
              SqlCommand cmd = null;
            List<Volunteer> opps = new List<Volunteer>();

            try{
                 cmd = openConnection();

                cmd.CommandText = "SELECT * FROM Volunteer WHERE [Volunteer].FName like '"+ searchTerm + "%'";
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while(rdr.Read() == true)
                {
                    Volunteer opp = new Volunteer();
                    opp.VolunteerFirstName = rdr["FName"].ToString();
                    opp.VolunteerLastName = rdr["LName"].ToString();

                    opps.Add(opp);
                }
            }
            catch (Exception e)
            {
                throw;
            }
            finally{
                CloseConnection(cmd);
            }
            return opps;
        }
        
    }
}