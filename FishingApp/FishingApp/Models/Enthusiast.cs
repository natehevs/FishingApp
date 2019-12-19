using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FishingApp.Models
{
    public class Enthusiast
    {
        [Key]
        [Display(Name = "Enthusiast ID")]
        public int EnthusiastID { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int Zipcode { get; set; }
    }
}