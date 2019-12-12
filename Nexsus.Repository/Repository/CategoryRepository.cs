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
   public class CategoryRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool IsExist(CategoryModel categoryModel)
        {
           
            int i = _dbContext.CategoryDatabaSet
                .Where(c => c.Code == categoryModel.Code || c.Name == categoryModel.Name).Count();



            if (i > 0)
            {
                return true;
            }

            return false;
        }

        public bool Add(CategoryModel categoryModel)
        {
            //int i = _dbContext.CategoryDatabaSet
            //    .Where(c => c.Code == categoryModel.Code || c.Name == categoryModel.Name).Count();



            //if (i > 0)
            //{
            //    return false;
            //}

            _dbContext.CategoryDatabaSet.Add(categoryModel);
            return _dbContext.SaveChanges() > 0;
        }

        //public bool IsExist(CategoryModel categoryModel)
        //{
        //    int i = _dbContext.CategoryDatabaSet
        //        .Where(c => c.Code == categoryModel.Code || c.Name == categoryModel.Name).Count();



        //    if (i > 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        //public bool IsExist(CategoryModel categoryModel)
        //{
        // //int i =   _dbContext.CategoryDatabaSet.Where(c => c.Code == categoryModel.Code && c.Name == categoryModel.Name)
        // //       .Count();
        // //if (i > 0)
        // //{
        // //    return false;
        // //}

        // _dbContext.CategoryDatabaSet.IsExist(categoryModel);
        // return _dbContext.SaveChanges() > 0;

        //}

        //public bool Delete(int id)
        //{
        //    Student aStudent = _dbContext.Students.FirstOrDefault((c => c.Id == id));
        //    _dbContext.Students.Remove(aStudent);
        //    return _dbContext.SaveChanges() > 0;
        //}
        public bool Update(CategoryModel category)
        {
            CategoryModel aCategoryModel = _dbContext.CategoryDatabaSet.FirstOrDefault(c => c.Id == category.Id);
            if (aCategoryModel != null)
            {
              

                aCategoryModel.Code = category.Code;
                aCategoryModel.Name = category.Name;

            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<CategoryModel> GetAll()
        {

            return _dbContext.CategoryDatabaSet.ToList();
        }
        public CategoryModel GetById(int id)
        {

            return _dbContext.CategoryDatabaSet.FirstOrDefault((c => c.Id == id));
        }

      
    }
}
