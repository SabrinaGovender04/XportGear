using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XportGear.Models.Data_Models;

namespace XportGear.Models
{
    public class Item
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCode { get; set; }
        [Required]
        [ForeignKey("Category")]
        [Display(Name = "Category")]
        public int Category_ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [MinLength(3)]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [MinLength(3)]
        [MaxLength(255)]

        public string Description { get; set; }
        [Required]
        [ForeignKey("Suppliers")]
        [Display(Name = "Supplier Name")]
        public int SupplierId { get; set; }
        [Display(Name = "Qty in Stock")]
        public int QuantityInStock { get; set; }
        //[Required]
        [Display(Name = "Picture")]
        //[DataType(DataType.Upload)]
        public byte[] Picture { get; set; }
        [Required]
        [Display(Name = "Supplier Cost")]
        [DataType(DataType.Currency)]
        public double CostPrice { get; set; }

        [Display(Name = "Markup %")]
        [Required]
        public double MarkupPercentage { get; set; }
        [Display(Name = "Re-Order When Stock Reaches?")]
        [Required]
        public int ReOrderLevel { get; set; }
        //[Display(Name = "Quantity To Be Stocked")]
        //[Required]
        //public int StockOnHand { get; set; }
       
        [Display(Name = "Safety Level")]
        public int SafetyStockLevel { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "On Offer?")]
        public string Status { get; set; }
       public string size { get; set; }
        public string color { get; set; }
        public double CalculateSellingPrice(double cost, double markup)
        {
            double selling = cost + (cost * (markup / 100));
            return selling;
        }
        public virtual Category Category { get; set; }
        public virtual ICollection<Cart_Item> Cart_Items { get; set; }
        public virtual Supplier Suppliers { get; set; }
        public virtual ICollection<ItemColorSize> ItemColorSize { get; set; }
    }
}