using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexsus.Model.Model;
using Nexsus.Repository.Repository;

namespace Nexsus.BLL.Manager
{
   public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool Add(ProductModel productModel)
        {
            return _productRepository.Add(productModel);
        }

        public List<ProductModel> GetAll()
        {
            return _productRepository.GetAll();
        }

        public ProductModel GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public bool Update(ProductModel productModel)
        {
            return _productRepository.Update(productModel);
        }

        public bool IsExist(ProductModel productModel)
        {
            return _productRepository.IsExist(productModel);
        }
    }
}
