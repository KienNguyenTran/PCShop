using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using PCShop.Models;

namespace PCShop.Models
{
    public class PartialMetadataType
    {

        [MetadataType(typeof(UserMasterData))]
        public partial class User
        {

        }
    }


    [MetadataType(typeof(UserMasterData))]
    public partial class Product
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    public partial class Category
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}