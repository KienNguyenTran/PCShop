using PCShop.Models;
using PCShop.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PCShop.Areas.Admin.Controllers
{

    public class HomeController : Controller
    {
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        // GET: Admin/Home


        public ActionResult Index()
        {

            var listproduct = objPCSHOPEntities.Products.ToList();
            return View(listproduct);
        }

       

        public ActionResult NotAuthorize()
        {
            return View();
        }

       

    }


}