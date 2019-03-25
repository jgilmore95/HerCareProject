using System;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{
    [Serializable]
    public class SearchModel
    {
        
        public string SearchValue{get; set;}
        public bool isClient {get; set;}
        public int Id {get; set;}
    }
}