using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSIhackathon.Models
{
    public class SearchModel
    {
        public int? Page { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public string IDNumber { get; set; }
    }
}