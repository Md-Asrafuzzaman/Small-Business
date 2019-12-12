using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Nexsus.Model.Model;
using Nexsus.Models;
using Nexsus.BLL.Manager;
using Nexsus.DatabaseContext.DatabaseContext;

namespace Nexsus.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryModel _categoryModel = new CategoryModel();
        CategoryManager  _categoryManager = new CategoryManager();
        ProjectDbContext _dbContext = new ProjectDbContext();

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Add()
        {

            CategoryViewModel categoryViewModel = new CategoryViewModel();

            categoryViewModel.Categorys = _categoryManager.GetAll();
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
           


            string message;
            if (ModelState.IsValid)
            {
                
               
                CategoryModel category = Mapper.Map<CategoryModel>(categoryViewModel);
                if (_categoryManager.IsExist(category))
                {
                    message = "Data is already Exist In Database";
                   
                }
                else
                {
                    if (_categoryManager.Add(category))
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
                message = "ModelState Failed";
            }

            

            //

            //if (DuplicateEntry(categoryViewModel))


            // { 
            //    message ="Code is Exist";
            //    return View();
            // }

            ViewBag.Message = message;
            categoryViewModel.Categorys = _categoryManager.GetAll();
            return View(categoryViewModel);
        }

        public ActionResult Edit(int id)
        {
            CategoryModel category = _categoryManager.GetById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            string message;
            if (ModelState.IsValid)
            {

                CategoryModel category = Mapper.Map<CategoryModel>(categoryViewModel);

                //if (_categoryManager.IsExist(category))
                //{
                //    message = "Data is already Exist In Database";

                //}
                //else
               // {
                    if (_categoryManager.Update(category))
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
            categoryViewModel.Categorys = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
      

        public ActionResult Search(string seacrhing)
        {
            //CategoryViewModel categoryViewModel = new CategoryViewModel();
            //categoryViewModel.Categorys = _categoryManager.GetAll();
            //return View(categoryViewModel);

            //var category = from s in _dbContext.CategoryDatabaSet select s;
            var category = from s in _categoryManager.GetAll() select s;
            if (!String.IsNullOrEmpty(seacrhing))
           {
               category = category.Where(s => s.Code.Contains(seacrhing) || s.Name.Contains(seacrhing));
               


           }

          
           return View(category.ToList());

        }

        //[HttpPost]
        //public ActionResult Search(CategoryViewModel categoryViewModel)
        //{
        //    string message;

        //    var categorys = _categoryManager.GetAll();
        //    if (categoryViewModel.Code != null)
        //    {
        //        categorys = categorys.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();

        //    }


        //    if (categoryViewModel.Name != null)
        //    {
        //        categorys = categorys.Where(c => c.Name.Contains(categoryViewModel.Name)).ToList();
        //    }

        //    categoryViewModel.Categorys = categorys;
        //    return View(categoryViewModel);
        //}

        //public JsonResult CodeUnique(CategoryModel categoryModel)
        //{
        //    return IsExist(categoryModel.Code, categoryModel.Name)
        //        ? Json(true, JsonRequestBehavior.AllowGet)
        //        : Json(false, JsonRequestBehavior.AllowGet);
        //}

        //public bool IsExist(string Code, string Name)
        //{
        //    //True:False--- action that implement to check barcode uniqueness

        //    return false;//Always return false to display error message
        //}
       
        //public ActionResult CheckExist(string code, string name )
        //{
        //    var validateName = _dbContext.CategoryDatabaSet.FirstOrDefault
        //        (x => x.Code == code || x.Name == name);
        //    if (validateName != null)
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //}




    }






    }
