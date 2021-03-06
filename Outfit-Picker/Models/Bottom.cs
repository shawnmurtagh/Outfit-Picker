﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Outfit_Picker.Models
{
    public class Bottom
    {
        public int BottomID { get; set; }

        [Required, StringLength(40)]
        public string BottomName { get; set; }

        public string PhotoPath { get; set; }

        [Required, StringLength(40)]
        public string Type { get; set; }

        [Required]
        public int ColorID { get; set; }

        [Required]
        public int SeasonID { get; set; }

        [Required]
        public int OccasionID { get; set; }

        //Navigation Properties 
        public virtual Color Color { get; set; }
        public  virtual Season Season { get; set; }
        public  virtual Occasion Occasion { get; set; }

        public virtual IEnumerable<Outfit> Outfit { get; set; }
    }
}