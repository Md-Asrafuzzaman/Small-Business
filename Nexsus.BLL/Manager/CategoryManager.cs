using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexsus.Model.Model;
using Nexsus.Repository.Repository;

namespace Nexsus.BLL.Manager
{
   public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool Add(CategoryModel categoryModel)
        {
            return _categoryRepository.Add(categoryModel);
        }

        public CategoryModel GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<CategoryModel> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public bool Update(CategoryModel category)
        {
            return _categoryRepository.Update(category);
        }

        public bool IsExist(CategoryModel categoryModel)
        {
            return _categoryRepository.IsExist(categoryModel);
        }





    }
}
