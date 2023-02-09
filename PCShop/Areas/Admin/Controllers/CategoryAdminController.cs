using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PCShop.Models;
using PCShop.Security;

namespace PCShop.Areas.Admin.Controllers
{
    
    public class CategoryAdminController : Controller
    {
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        // GET: Admin/ProductAdmin
        public ActionResult Index()
        {
            var listCategory = objPCSHOPEntities.Categories.ToList();
            return View(listCategory);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Category objcategory)
        {
            PCSHOPEntities sd = new PCSHOPEntities();

            try
            {
                if (objcategory.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objcategory.ImageUpload.FileName);
                    string extension = Path.GetExtension(objcategory.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objcategory.avatar = fileName;
                    objcategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Asset/img/hinh Category"), fileName));
                }
                objPCSHOPEntities.Categories.Add(objcategory);
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
            var objcategory = objPCSHOPEntities.Categories.Where(n => n.id == id).FirstOrDefault();
            return View(objcategory);
        }
        [HttpPost]
        public ActionResult Edit(Category objcategory)
        {
            if (objcategory.ImageUpload != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(objcategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objcategory.ImageUpload.FileName);
                fileName = fileName + extension;
                objcategory.avatar = fileName;
                objcategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/items/"), fileName));
            }
            objPCSHOPEntities.Entry(objcategory).State = EntityState.Modified;
            objPCSHOPEntities.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objcategory = objPCSHOPEntities.Categories.Where(n => n.id == id).FirstOrDefault();
            return View(objcategory);
        }
        [HttpPost]
        public ActionResult Delete(Category objca)
        {
            var objcategory = objPCSHOPEntities.Categories.Where(n => n.id == objca.id).FirstOrDefault();
            objPCSHOPEntities.Categories.Remove(objcategory);
            objPCSHOPEntities.SaveChanges();
            return RedirectToAction("Index");


        }
       
    }
}