using System;
using System.Collections.Generic;

namespace her_care.Models
{
    public class Adress 
    {
         public string AddressOne { get; set; }
         public string AddressTwo { get; set; }
         public string City { get; set; }
         public string State { get; set; }
         public string Zip { get; set; }

    }

    public class Vetran
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public List<Adress> Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid Uuid { get; set; }
    }
    
}
