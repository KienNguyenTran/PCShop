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
    public class AccountAdminController : Controller
    {
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        // GET: Admin/AccountAdmin
        public ActionResult Index()
        {
            var listAccount = objPCSHOPEntities.Accounts.ToList();
            return View(listAccount);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Account objaccount)
        {
            PCSHOPEntities sd = new PCSHOPEntities();

                objPCSHOPEntities.Accounts.Add(objaccount);
                objPCSHOPEntities.SaveChanges();
                return RedirectToAction("Index");
   
        }





        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objaccount = objPCSHOPEntities.Accounts.Where(n => n.id == id).FirstOrDefault();

            return View(objaccount);
        }
        [HttpPost]
        public ActionResult Edit(Account objaccount)
        {
           
            objPCSHOPEntities.Entry(objaccount).State = EntityState.Modified;
            objPCSHOPEntities.SaveChanges();
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objaccount = objPCSHOPEntities.Accounts.Where(n => n.id == id).FirstOrDefault();
            return View(objaccount);
        }
        [HttpPost]
        public ActionResult Delete(Account objpr)
        {
            var objaccount = objPCSHOPEntities.Accounts.Where(n => n.id == objpr.id).FirstOrDefault();
            objPCSHOPEntities.Accounts.Remove(objaccount);
            objPCSHOPEntities.SaveChanges();
            return RedirectToAction("Index");


        }
       

    }
}
