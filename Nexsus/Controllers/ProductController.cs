using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using Nexsus.BLL.Manager;
using Nexsus.Models;
using Nexsus.Model.Model;
namespace Nexsus.Controllers
{
    public class ProductController : Controller

    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        // GET: Product
        public ActionResult Add()
        {

            ProductViewModel productViewModel = new ProductViewModel();


            productViewModel.Products = _productManager.GetAll();
            productViewModel.SelectCategory = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();

            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            string message = "";

            //Student student = new Student();
            //student.RollNo = studentViewModel.RollNo;
            //student.Name = studentViewModel.Name;
            //student.Address = studentViewModel.Address;
            //student.Age = studentViewModel.Age;
            //student.DepartmentId = studentViewModel.DepartmentId;

            if (ModelState.IsValid)
            {
                ProductModel productModel = Mapper.Map<ProductModel>(productViewModel);
                if (_productManager.IsExist(productModel))
                {
                    message = "Data is exist ";
                }
                else
                {
                    if (_productManager.Add(productModel))
                    {
                        message = "Saved";
                    }
                    else
                    {
                        message = "Not Saved";
                    }
                }

              
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            productViewModel.Products = _productManager.GetAll();
            productViewModel.SelectCategory = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name

                    }
                ).ToList();


            return View(productViewModel);
        }
        public ActionResult Edit(int id)
        {
            ProductModel productModel = _productManager.GetById(id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(productModel);
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            string message;
            if (ModelState.IsValid)
            {

                ProductModel productModel = Mapper.Map<ProductModel>(productViewModel);

                //if (_categoryManager.IsExist(category))
                //{
                //    message = "Data is already Exist In Database";

                //}
                //else
                // {
                if (_productManager.Update(productModel))
                {

                    message = "Update";
                }
                else
                {
                    message = "Not Update";
                }
                // }


            }
            else
            {
                message = "ModelState Failed";
            }


            //


            ViewBag.Message = message;
            productViewModel.Products = _productManager.GetAll();
            return View(productViewModel);
        }
        public ActionResult Search(string seacrhing)
        {
            //CategoryViewModel categoryViewModel = new CategoryViewModel();
            //categoryViewModel.Categorys = _categoryManager.GetAll();
            //return View(categoryViewModel);

            //var category = from s in _dbContext.CategoryDatabaSet select s;
            var product = from s in _productManager.GetAll() select s;
            if (!String.IsNullOrEmpty(seacrhing))
            {
                product = product.Where(s => s.Code.Contains(seacrhing) || s.Name.Contains(seacrhing) || s.CategoryId.ToString().Contains(seacrhing));

            }


            return View(product.ToList());

        }
    }
}