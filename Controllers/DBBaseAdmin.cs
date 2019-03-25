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
        public static List<Test> UserSearch(string searchTerm)
        {
              SqlCommand cmd = null;
            List<Test> opps = new List<Test>();

            try{
                 cmd = openConnection();

                cmd.CommandText = "SELECT * FROM Test WHERE [Test].Pname like '"+ searchTerm + "%'";
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

        /* Actual working client search */
        public static List<SearchBox> ClientSearch(string searchTerm)
        {
            SqlCommand cmd = null; //initialize command
            List<SearchBox> Terms = new List<SearchBox>(); //Create List based on SearchBox Model

            try{
                 cmd = openConnection(); //Opens SQL connection

                cmd.CommandText = "SELECT * FROM Client WHERE [Client].Fname like '"+ searchTerm + "%'"; //SQL statement
                cmd.CommandType = System.Data.CommandType.Text; //Execute statement

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //Create reader based on statement

                while(rdr.Read() == true) //While there are things left in the reader
                {
                    SearchBox Term = new SearchBox(); //Create Term object

                    Term.Id = Convert.ToInt32(rdr["ClientId"].ToString()); //add clientID
                    Term.FName = rdr["FName"].ToString(); //Add first name
                    Term.LName = rdr["LName"].ToString(); //Add Last Name
                    

                    Terms.Add(Term); //Add object to list
                }
            }
            catch (Exception e) //catch any exceptions
            {
                throw;
            }
            finally{
                CloseConnection(cmd); // close DB connection
            }
            return Terms; //return list
        }


        public static List<SearchBox> VolunteerSearch(string searchTerm)
        {
            SqlCommand cmd = null; //initialize command
            List<SearchBox> Terms = new List<SearchBox>(); //Create List based on SearchBox Model

            try{
                 cmd = openConnection(); //Opens SQL connection

                cmd.CommandText = "SELECT * FROM Volunteer WHERE [Volunteer].Fname like '"+ searchTerm + "%'"; //SQL statement
                cmd.CommandType = System.Data.CommandType.Text; //Execute statement

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //Create reader based on statement

                while(rdr.Read() == true) //While there are things left in the reader
                {
                    SearchBox Term = new SearchBox(); //Create Term object

                    Term.Id = Convert.ToInt32(rdr["VolunteerId"].ToString()); //add clientID
                    Term.FName = rdr["FName"].ToString(); //Add first name
                    Term.LName = rdr["LName"].ToString(); //Add Last Name
                    

                    Terms.Add(Term); //Add object to list
                }
            }
            catch (Exception e) //catch any exceptions
            {
                throw;
            }
            finally{
                CloseConnection(cmd); // close DB connection
            }
            return Terms; //return list
        }

        
        public static List<SearchBox> ClientDetails(string id)
        {
            SqlCommand cmd = null; //initialize command
            List<SearchBox> Terms = new List<SearchBox>(); //Create List based on SearchBox Model

            try{
                 cmd = openConnection(); //Opens SQL connection

                cmd.CommandText = "SELECT * FROM Client WHERE [Client].ClientID = '"+ id + "'"; //SQL statement
                cmd.CommandType = System.Data.CommandType.Text; //Execute statement

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //Create reader based on statement

                while(rdr.Read() == true) //While there are things left in the reader
                {
                    SearchBox Term = new SearchBox(); //Create Term object

                    Term.Id = Convert.ToInt32(rdr["ClientId"].ToString()); //add clientID
                    Term.FName = rdr["FName"].ToString(); //Add first name
                    Term.LName = rdr["LName"].ToString(); //Add Last Name
                    

                    Terms.Add(Term); //Add object to list
                }
            }
            catch (Exception e) //catch any exceptions
            {
                throw;
            }
            finally{
                CloseConnection(cmd); // close DB connection
            }
            return Terms; //return list
        }

        
    }
}