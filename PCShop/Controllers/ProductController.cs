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


        public ActionResult Index(string SearchString)
        {
            var objproduct = objPCSHOPEntities.Products.ToList();
            if ( SearchString != null)
            {
                objproduct = objPCSHOPEntities.Products.Where(n => n.name.ToUpper().Contains(SearchString.ToUpper())).ToList();
                return View(objproduct);
            }
            else 
            {
                return View(objproduct);
            }

        }

    }
} 