using System;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{

    public class Test
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string PName {get; set; }
    }
    /*
    public class testDBContext : testDBContext{
        public testDBContext()
        {}
        public DbSet<Test>TestDB{get;set;}
    }
    */
}