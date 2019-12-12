using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nexsus.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace Nexsus.Models
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]
        [MaxLength(4, ErrorMessage = "Maximum Lenght is 4")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Code Lenght Must Be 4")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Code Cant be Emply")]
        public string Contact { get; set; }

        public string ContactPerson { get; set; }

        public List<SupplierModel> Suppliers { get; set; }

    }
}