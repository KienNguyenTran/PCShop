using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCShop.Common
{
    [Serializable]
    public class UserLogin
    {
        public int id { set; get; }
        public string email { set; get; }
        public int pk { set; get; }
    }
}