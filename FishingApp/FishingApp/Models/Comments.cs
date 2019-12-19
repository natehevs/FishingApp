﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FishingApp.Models
{
    public class Comments
    {
        [Key]
        [Display(Name = "Comment ID")]
        public int CommentID { get; set; }

        [ForeignKey("Marker ID")]
        public int MarkerID { get; set; }

        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }
}