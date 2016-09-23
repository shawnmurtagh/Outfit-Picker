using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Outfit_Picker.Models
{
    public class Top
    {
        
        public int TopID { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }


        public string PhotoPath { get; set; }

        [Required, StringLength(40)]
        public string Type { get; set; }

        [Required]
        public Color _Color { get; set; }

        [Required]
        public string Season { get; set; }

        [Required]
        public string Occasion { get; set; }

        public virtual IEnumerable<Outfit>Outfit { get; set; }

    }
}