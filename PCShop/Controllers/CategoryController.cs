using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        public ActionResult Category(int ID)
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProducts = objPCSHOPEntities.Products.Where(n => n.category_id == ID).ToList();
            objHomeModel.ListCategories = objPCSHOPEntities.Categories.ToList();

            return View(objHomeModel);
        }
        
    }
}