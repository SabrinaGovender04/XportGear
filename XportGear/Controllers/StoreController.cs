using System.Linq;
using System.Web.Mvc;
using XportGear.Models;

namespace XportGear.Controllers
{
    public class StoreController : Controller
    {
           ApplicationDbContext storeDB = new ApplicationDbContext();
        //
        // GET: /Store/

        public ActionResult MyCat()
        {
            var catagories = storeDB.Categories.ToList();
            return PartialView("MyCat",catagories);
            //return View(catagories);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string catagorie)
        {
            var si = (from x in storeDB.ItemColorSizes
                        join y in storeDB.Items
                        on x.ItemCode equals y.ItemCode
                        join z in storeDB.Sizes
                        on x.SizeId equals z.SizeId
                        select z.Name).FirstOrDefault();
            ViewBag.SizeEkse = si;
            ViewBag.Siz = new SelectList(si);
            var col = (from x in storeDB.Colors
                       select x.ColorName).ToList();
            var siizzee = (from x in storeDB.Sizes
                           select x.Name).ToList();
            ViewBag.size = new SelectList(siizzee);
            ViewBag.color = new SelectList(col);
            // Retrieve Genre and its Associated Items from database
            var catagorieModel = storeDB.Categories.Include("Items")
                .Single(g => g.Category_Name == catagorie);

            return View(catagorieModel);
        }
        //public ActionResult BrowseGenger(string Gender)
        //{
        //    // Retrieve Genre and its Associated Items from database
            

        //    return View(storeDB.Items.ToList().Single(X=>X.Gender == Gender));
        //}

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var item = storeDB.Items.Find(id);

            return View(item);
        }

        //
        // GET: /Store/GenreMenu
        //[ChildActionOnly]
        public ActionResult CatagorieMenu()
        {
            var catagories = storeDB.Categories.ToList();

            return PartialView(catagories);
        }
    }
}