using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PCShop.Models;
namespace PCShop.Models
{   
    public class HomeModel
    {
        public List<Product> ListProducts { get; set; }
        public List<Category> ListCategories { get; set; }

        public List<Account> ListAccount { get; set; }
        public int id { get; set; }
        public int pk { get; set; }
    }
}