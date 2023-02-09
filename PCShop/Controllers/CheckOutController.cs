using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        public ActionResult CheckOut()
        {
            HomeModel objHomeModel = new HomeModel();
            objHomeModel.ListProducts = objPCSHOPEntities.Products.ToList();
            objHomeModel.ListCategories = objPCSHOPEntities.Categories.ToList();

            return View(objHomeModel);
        }
        public ActionResult Done()
        {
            return View();
        }
    }
    
}