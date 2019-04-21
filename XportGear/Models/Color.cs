using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XportGear.Models
{
    public class Color
    {

        [Key]
        public int SizeId { get; set; }
        [Required]
        [Display(Name = "Color Code")]
        public string ColorName { get; set; }
        //[Required]
        [Display(Name = "Color Name")]
        public string ColorN { get; set; }

      
        public virtual ICollection<ItemColorSize> ItemColorSize { get; set; }
    }
}