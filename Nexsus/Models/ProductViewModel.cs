using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nexsus.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Nexsus.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code Cant be Emply")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code Lenght Must Be 4")]
        public string Code { get; set; }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }
        public  List<SelectListItem> SelectCategory { get; set; }
        public int RecordedLevel { get; set; }
        public string Description { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}