using PCShop.Models;
using PCShop.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCShop.Areas.Admin.Controllers
{
    [DeatAuthorize(Order = 3)]
    public class ProductAdminController : Controller
    {
        // GET: Admin/ProductAdmin
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            var listProduct = objPCSHOPEntities.Products.ToList();
            return View(listProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product objproduct)
        {
            PCSHOPEntities sd = new PCSHOPEntities();

            try
            {
                if (objproduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objproduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objproduct.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objproduct.Avatar = fileName;
                    objproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Asset/img/hinh Product"), fileName));
                }
                objPCSHOPEntities.Products.Add(objproduct);
                objPCSHOPEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objproduct = objPCSHOPEntities.Products.Where(n => n.id == id).FirstOrDefault();
            ViewBag.CategoryList = new SelectList(GetCategories(), "id", "name");
            ViewBag.AccountList = new SelectList(GetAccounts(), "id", "email");
            return View(objproduct);
        }
        [HttpPost]
        public ActionResult Edit(Product objproduct)
        {
            if (objproduct.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objproduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objproduct.ImageUpload.FileName);
                fileName = fileName + extension;
                objproduct.Avatar = fileName;
                objproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/img/hinh Product"), fileName));
            }
            objPCSHOPEntities.Entry(objproduct).State = EntityState.Modified;
            objPCSHOPEntities.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objproduct = objPCSHOPEntities.Products.Where(n => n.id == id).FirstOrDefault();
            return View(objproduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objpr)
        {
            var objproduct = objPCSHOPEntities.Products.Where(n => n.id == objpr.id).FirstOrDefault();
            objPCSHOPEntities.Products.Remove(objproduct);
            objPCSHOPEntities.SaveChanges();
            return RedirectToAction("Index");


        }
        public List<Category> GetCategories()
        {
            PCSHOPEntities sd = new PCSHOPEntities();
            List<Category> categories = sd.Categories.ToList();
            return categories;

        }
        public List<Account> GetAccounts()
        {
            PCSHOPEntities sd = new PCSHOPEntities();
            List<Account> accounts = sd.Accounts.ToList();
            return accounts;
        }


            


        }
    }



