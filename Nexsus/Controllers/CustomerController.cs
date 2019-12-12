using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Nexsus.Model.Model;
using Nexsus.Models;
using Nexsus.BLL.Manager;
using Nexsus.DatabaseContext.DatabaseContext;

namespace Nexsus.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Customer _customer = new Customer();
        CustomerManager _customerManager = new CustomerManager();

        public ActionResult Add()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {



            string message;
            if (ModelState.IsValid)
            {


                Customer customer = Mapper.Map<Customer>(customerViewModel);



                if (_customerManager.Add(customer))
                {

                    message = "Saved";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "ModelState Failed";
            }
            ViewBag.Message = message;
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _customerManager.GetById(id);
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);

            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            string message;
            if (ModelState.IsValid)
            {

                Customer customer = Mapper.Map<Customer>(customerViewModel);


                if (_customerManager.Update(customer))
                {

                    message = "Update";
                }
                else
                {
                    message = "Not Update";
                }
            }
            else
            {
                message = "ModelState Failed";
            }


            //


            ViewBag.Message = message;
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
        public ActionResult Search()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Search(CustomerViewModel customerViewModel)
        {
            string message;

            var customers = _customerManager.GetAll();
            if (customerViewModel.Code != null)
            {
                customers = customers.Where(c => c.Code.Contains(customerViewModel.Code)).ToList();

            }


            if (customerViewModel.Name != null)
            {
                customers = customers.Where(c => c.Name.Contains(customerViewModel.Name)).ToList();
            }

            customerViewModel.Customers = customers;
            return View(customerViewModel);
        }

    }



}