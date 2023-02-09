using PCShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        public ActionResult Product(int ID)
        {
            var objproduct = objPCSHOPEntities.Products.Where(n => n.id == ID).FirstOrDefault();
            return View(objproduct);
        }


     

    }
} 