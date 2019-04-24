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

                cmd.CommandText = "SELECT * FROM Client WHERE [Client].Fname like '"+ searchTerm + "%' OR [Client].LName like '"+ searchTerm + "%' OR [Client].SSN like '"+ searchTerm + "%'"; //SQL statement
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

        
        public static List<Demographics> ClientDetails(string id)
        {
            SqlCommand cmd = null; //initialize command
            List<Demographics> Terms = new List<Demographics>(); //Create List based on Demographics Model

            try{
                 cmd = openConnection(); //Opens SQL connection

                cmd.CommandText = "SELECT * FROM Client WHERE [Client].ClientID = '"+ id + "'"; //SQL statement
                cmd.CommandType = System.Data.CommandType.Text; //Execute statement

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //Create reader based on statement

                while(rdr.Read() == true) //While there are things left in the reader
                {
                    Demographics Term = new Demographics(); //Create Term object

                    Term.Id = Convert.ToInt32(rdr["ClientId"].ToString()); //add clientID
                    Term.FirstName = rdr["FName"].ToString(); //Add first name
                    Term.LastName = rdr["LName"].ToString(); //Add Last Name
                    Term.DateOfBirth = (DateTime) rdr["DateOfBirth"];
                    Term.AddressOne = rdr["HomeAddress"].ToString();
                    Term.City = rdr["City"].ToString();
                    Term.State = Convert.ToInt32(rdr["StateID"].ToString());
                    Term.Zip = Convert.ToInt32(rdr["ZipCode"].ToString());                    
                    Term.Phone = rdr["Phone"].ToString();
                    Term.EmailAddress = rdr["EmailAddress"].ToString();
                    Term.EmergencyContactFirst = rdr["EmergencyContactFirst"].ToString();
                    Term.EmergencyContactLast = rdr["EmergencyContactLast"].ToString();
                    Term.EmergencyContactPhone = rdr["EmergencyContactPhone"].ToString();
                    Term.BranchOfService = rdr["BranchOfService"].ToString();
                    Term.DisabilityRating = Convert.ToInt32(rdr["DisabilityRating"].ToString());
                    Term.Employed = (bool) rdr["Employed"];
                    Term.Contractor = (bool) rdr["Contractor"];
                    Term.SSN = rdr["SSN"].ToString();
                    Term.Unemployed = (bool) rdr["Unemployed"];
                    Term.Reserves = (bool) rdr["Reserves"];
                    Term.ActiveDuty = (bool) rdr["ActiveDuty"];
                    Term.NationalGuard = (bool) rdr["NationalGuard"];
                    Term.CombatVet = (bool) rdr["CombatVet"];
                    Term.Rental = (bool) rdr["Rental"];

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

        public static List<VolunteerModel> VolunteerDetails(string id)
        {
            SqlCommand cmd = null; //initialize command
            List<VolunteerModel> Terms = new List<VolunteerModel>(); //Create List based on VolunteerModel Model

            try{
                 cmd = openConnection(); //Opens SQL connection

                cmd.CommandText = "SELECT * FROM Volunteer WHERE [Volunteer].VolunteerID = '"+ id + "'"; //SQL statement
                cmd.CommandType = System.Data.CommandType.Text; //Execute statement

                SqlDataReader rdr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection); //Create reader based on statement

                while(rdr.Read() == true) //While there are things left in the reader
                {
                    VolunteerModel Term = new VolunteerModel(); //Create Term object

                    Term.VolunteerId = Convert.ToInt32(rdr["VolunteerID"].ToString()); //add clientID
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









        public static List<SearchBox> CombinedSearchChoice(string searchTerm, bool isClient)
        {

            if(isClient){
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
                    Term.isClient = true;
                    

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

            if(!isClient)
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
                    Term.isClient = false;
                    

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
            return null;
        }



        public static List<SearchBox> CombinedSearch(string searchTerm)
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
                    Term.isClient = true;
                    

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
            

           
                 cmd = null; //reinitialize command
         //   List<SearchBox> Terms = new List<SearchBox>(); //Create List based on SearchBox Model

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
                    Term.isClient = false;
                    

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