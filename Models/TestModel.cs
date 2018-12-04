using System;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{

    public class Test
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}