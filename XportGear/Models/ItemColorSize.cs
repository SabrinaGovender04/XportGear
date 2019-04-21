using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XportGear.Models
{
    public class ItemColorSize
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Size")]
        [Display(Name = "Size")]
        public int SizeId { get; set; }
        [Required]
        [ForeignKey("Color")]
        [Display(Name = "Color")]
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("Item")]
        [Display(Name = "Item")]
        public int ItemCode { get; set; }
        public virtual Item Item { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }



    }
}