using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XportGear.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string Full_Name { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyXportDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        //Temporal Shopping
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }
        //Shopping
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order_Item> Order_Items { get; set; }
        public DbSet<Order_Address> Order_Addresses { get; set; }
        public DbSet<Order_Tracking> Order_Trackings { get; set; }
        //
        public DbSet<Payment> Payments { get; set; }
        //
        public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<XportGear.Models.Data_Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<XportGear.Models.Size> Sizes { get; set; }

        public System.Data.Entity.DbSet<XportGear.Models.Color> Colors { get; set; }

        public System.Data.Entity.DbSet<XportGear.Models.ItemColorSize> ItemColorSizes { get; set; }
    }

  
}