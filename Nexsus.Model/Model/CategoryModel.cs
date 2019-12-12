using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexsus.Model;
using System.Threading.Tasks;


namespace Nexsus.Model.Model
{
  public  class CategoryModel
    {

        public CategoryModel()
        {
            ProductModels = new List<ProductModel>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual List<ProductModel> ProductModels { get; set; }



    }
}
