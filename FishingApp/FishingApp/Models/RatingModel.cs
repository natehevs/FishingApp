using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FishingApp.Models
{
    public class RatingModel : LocationMarkers
    {
        [Key]
        [Display(Name = "Rating ID")]
        public int RatingID { get; set; }

        [ForeignKey("Marker ID")]
        public int MarkerID { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [ForeignKey("Enthusiast ID")]
        public string EnthusiastID { get; set; }
    }
}