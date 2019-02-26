using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{
    [Serializable]    
    public class Test 
    {
        

        [Key]
        public int Id { get; set; }

        public string PName {get; set; }
        public int Age {get; set;}
        public int num {get; set;}

        public IEnumerable<Test> Tester {get; set;}
    }

    
   
    /*
    public class testDBContext : testDBContext{
        public testDBContext()
        {}
        public DbSet<Test>TestDB{get;set;}
    }
    */
}