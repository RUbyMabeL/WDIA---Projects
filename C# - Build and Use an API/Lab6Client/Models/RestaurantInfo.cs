using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6Client.Models
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        [RegularExpression(@"^(ON|BC|QC|MB|SK|AB|NB|NS|PE|NL|NT|YT|NU)$", ErrorMessage = "Province must be one of the Canadian provinces or territories (e.g., ON, BC, QC, etc.)")]
        public string provstate { get; set; }
        [RegularExpression(@"^[A-Z]\d[A-Z] \d[A-Z]\d$", ErrorMessage = "Postal code must be in the format L2L 3K4")]
        public string postalzipcode { get; set; }
    }

    public class Rating
    {
        public int minRating { get; set; } = 0;         //default to 0
        public int maxRating { get; set; } = 5;         //default to 5
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int currentRating { get; set; }
    }
    public class Cost
    {
        public int minCost { get; set; } = 0;
        public int maxCost { get; set; } = 5;
        [Range(1, 5, ErrorMessage = "Cost must be between 1 and 5.")]
        public int currentCost { get; set; }
    }
    public class RestaurantInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public string summary { get; set; }
        public string foodType { get; set; }
        public Rating rating { get; set; }

        public Cost cost { get; set; }

    }
}