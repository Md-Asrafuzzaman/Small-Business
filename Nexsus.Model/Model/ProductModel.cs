using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexsus.Model.Model
{
   public class ProductModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public  CategoryModel CategoryModel { get; set; }
        public int RecordedLevel { get; set; }
        public string Description { get; set; }
    }
}
