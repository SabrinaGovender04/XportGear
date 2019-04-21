using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XportGear.Models
{
    public class Size
    {
        [Key]
        public int SizeId { get; set; }
        [Required]
        [Display(Name = "Size")]
        public string Name { get; set; }
       public virtual ICollection<ItemColorSize> ItemColorSize { get; set; }
    }
}