using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexsus.Model.Model;
using Nexsus.DatabaseContext.DatabaseContext;

namespace Nexsus.Repository.Repository
{
  public  class SupplierRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool IsExist(SupplierModel supplierModel)
        {

            int i = _dbContext.SupplierDataBaseSet
                .Where(c => c.Code == supplierModel.Code || c.Email == c.Email || c.Contact == c.Contact).Count();



            if (i > 0)
            {
                return true;
            }

            return false;
        }
        public bool Add(SupplierModel supplierModel)
        {
            //int i = _dbContext.SupplierDataBaseSet
            //    .Where(c => c.Code == supplierModel.Code || c.Name == supplierModel.Name).Count();



            //if (i > 0)
            //{
            //    return false;
            //}

            _dbContext.SupplierDataBaseSet.Add(supplierModel);
            return _dbContext.SaveChanges() > 0;
        }

        public List<SupplierModel> GetAll()
        {

            return _dbContext.SupplierDataBaseSet.ToList();
        }

        public SupplierModel GetById(int id)
        {

            return _dbContext.SupplierDataBaseSet.FirstOrDefault((c => c.Id == id));
        }

        public bool Update(SupplierModel supplier)
        {
            SupplierModel aSupplierModel = _dbContext.SupplierDataBaseSet.FirstOrDefault(c => c.Id == supplier.Id);
            if (aSupplierModel != null)
            {
                aSupplierModel.Code = supplier.Code;
                aSupplierModel.Name = supplier.Name;
                aSupplierModel.Address = supplier.Address;
                aSupplierModel.Email = supplier.Email;
                aSupplierModel.Contact = supplier.Contact;
                aSupplierModel.ContactPerson = supplier.ContactPerson;

            }

            return _dbContext.SaveChanges() > 0;
        }
    }
}
