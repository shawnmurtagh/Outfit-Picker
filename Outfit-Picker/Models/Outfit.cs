﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outfit_Picker.Models
{
    public class Outfit
    {

        public int OutfitID { get; set; }

        public string OutfitName { get; set; }

        public virtual Top Top { get; set; }

        public virtual Bottom Bottom { get; set; }

        public virtual Shoe Shoe { get; set; }

        public virtual IEnumerable<Accessory> Accessory { get; set; }

    }
}