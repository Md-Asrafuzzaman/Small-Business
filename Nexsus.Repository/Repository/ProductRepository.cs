using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Nexsus.Model.Model;
using Nexsus.DatabaseContext.DatabaseContext;
namespace Nexsus.Repository.Repository
{
    public class ProductRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(ProductModel productModel)
        {
            _dbContext.ProductDbSet.Add(productModel);
            return _dbContext.SaveChanges() > 0;
        }
        public List<ProductModel> GetAll()
        {

            return _dbContext.ProductDbSet.ToList();
        }
        public ProductModel GetById(int id)
        {

            return _dbContext.ProductDbSet.FirstOrDefault((c => c.Id == id));
        }
        public bool Update(ProductModel productModel)
        {
            ProductModel aproductModel = _dbContext.ProductDbSet.FirstOrDefault(c => c.Id == productModel.Id);
            if (aproductModel != null)
            {
                aproductModel.Code = productModel.CategoryId.ToString();
                aproductModel.Code = productModel.Code;
                aproductModel.Name = productModel.Name;
                aproductModel.Name = productModel.RecordedLevel.ToString();
                aproductModel.Name = productModel.Description;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public bool IsExist(ProductModel productModel)
        {

            int i = _dbContext.ProductDbSet
                .Where(c => c.Code == productModel.Code).Count();



            if (i > 0)
            {
                return true;
            }

            return false;
        }
    }
}
