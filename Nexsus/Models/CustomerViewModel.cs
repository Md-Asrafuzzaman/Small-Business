using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Nexsus.Model.Model;

namespace Nexsus.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code Lenght Must Be 4")]
        public string Code { get; set; }

        //[Remote("CodeUnique", "Customer", AdditionalFields = "Code", ErrorMessage = "This {0} is already used.")]
        [Required(ErrorMessage = "Name Cant be Emply")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]


        public string Contact { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]

        public string Email { get; set; }
        public int LoyalityPoint { get; set; }


        public List<Customer> Customers { get; set; }
    }
}