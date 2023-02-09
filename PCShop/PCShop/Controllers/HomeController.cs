using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PCShop.Common;
using PCShop.Models;
namespace PCShop.Controllers
{
    public class HomeController : Controller
    {
        PCSHOPEntities objPCSHOPEntities = new PCSHOPEntities();
        [AllowAnonymous]
        public ActionResult Index()
        {
           HomeModel objHomeModel = new HomeModel();
           objHomeModel.ListProducts = objPCSHOPEntities.Products.ToList();
           objHomeModel.ListCategories = objPCSHOPEntities.Categories.ToList();
   
            return View(objHomeModel);
        }

        
      


        [HttpGet]
        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account _user)
        {
            if (ModelState.IsValid)
            {
                var check = objPCSHOPEntities.Accounts.FirstOrDefault(s => s.email == _user.email);
                if (check == null)
                {
                    _user.password = GetMD5(_user.password);
                    objPCSHOPEntities.Configuration.ValidateOnSaveEnabled = false;
                    objPCSHOPEntities.Accounts.Add(_user);
                    objPCSHOPEntities.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
       
        public ActionResult Login()
        {
            return View();
        }
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = objPCSHOPEntities.Accounts.Where(s => s.email.Equals(email) && s.password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    var user = objPCSHOPEntities.Accounts.FirstOrDefault(x => x.email == email);
                    var userSession = new UserLogin();
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().email;
                    Session["idUser"] = data.FirstOrDefault().id;
                    Session["role"] = data.FirstOrDefault().role;
                    userSession.pk = (int)user.pk;

                    Session.Add(CommonContants.USER_SESSION, userSession);

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult NotAuthorize()
        {
            return View();
        }
        public ActionResult ts()
        {
            return View();
        }

    }
}