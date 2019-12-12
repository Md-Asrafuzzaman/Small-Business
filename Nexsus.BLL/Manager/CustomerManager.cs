using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexsus.Model.Model;
using Nexsus.Repository.Repository;

namespace Nexsus.BLL.Manager
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer categoryModel)
        {
            return _customerRepository.Add(categoryModel);
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }


    }
}
