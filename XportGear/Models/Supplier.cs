using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace XportGear.Models.Data_Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        [Required]
        [Display(Name = "Supplier Name")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use Characters only")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string phoneNumber { get; set; }
        [Required]
        [Display(Name = "Physical Address")]
        public string physicalAddress { get; set; }
        public List<Item> Items { get; set; }
    }
}