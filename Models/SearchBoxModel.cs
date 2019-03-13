using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{
    [Serializable]    
    public class SearchBox 
    {
        

        [Key]
        public int Id { get; set; }

        public string FName {get; set; }
        public String LName {get; set;}
        
    }

    
   
 
}