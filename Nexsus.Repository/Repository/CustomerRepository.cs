using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexsus.Model.Model;
using Nexsus.DatabaseContext.DatabaseContext;

namespace Nexsus.Repository.Repository
{
    public class CustomerRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Customer customerModel)
        {
            int i = _dbContext.CustomerDatabaSet
                .Where(c => c.Code == customerModel.Code || c.Contact == customerModel.Contact || c.Email == customerModel.Email).Count();



            if (i > 0)
            {
                return false;
            }

            _dbContext.CustomerDatabaSet.Add(customerModel);
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
        public bool Update(Customer customer)
        {
            Customer aCustomerModel = _dbContext.CustomerDatabaSet.FirstOrDefault(c => c.Id == customer.Id);
            if (aCustomerModel != null)
            {
                aCustomerModel.Code = customer.Code;
                aCustomerModel.Name = customer.Name;
                aCustomerModel.Address = customer.Address;
                aCustomerModel.Contact = customer.Contact;
                aCustomerModel.Email = customer.Email;
                aCustomerModel.LoyalityPoint = customer.LoyalityPoint;

            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Customer> GetAll()
        {
            return _dbContext.CustomerDatabaSet.ToList();
        }
        public Customer GetById(int id)
        {

            return _dbContext.CustomerDatabaSet.FirstOrDefault((c => c.Id == id));
        }

    }
}
