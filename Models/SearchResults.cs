using System;
using System.ComponentModel.DataAnnotations;

namespace her_care.Models
{
    [Serializable]
    public class SearchModel
    {
        
        public string SearchValue
        {
            get; set;
        }
    }
}