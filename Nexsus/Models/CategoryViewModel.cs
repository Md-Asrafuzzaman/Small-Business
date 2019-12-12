using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nexsus.Model.Model;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace Nexsus.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        //[Remote("CheckExist", "Category", ErrorMessage = "The Code is exists")]
        [Required(ErrorMessage = "Code Cant be Emply")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code Lenght Must Be 4")]
        public string Code { get; set; }
        //[Remote("CheckExist", "Category", ErrorMessage = "The Name is exists")]
        //[Remote("CodeUnique", "Category", AdditionalFields = "Code", ErrorMessage = "This {0} is already used.")]
        [Required(ErrorMessage = "Name Cant be Emply")]
        public string Name { get; set; }
        
        public List<CategoryModel> Categorys { get; set; }
    }
}