using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Nexsus.Model.Model;
using Nexsus.Models;

namespace Nexsus
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, CategoryModel>();
                cfg.CreateMap<CategoryModel, CategoryViewModel>();

                cfg.CreateMap<SupplierViewModel, SupplierModel>();
                cfg.CreateMap<SupplierModel,SupplierViewModel>();

                cfg.CreateMap<ProductViewModel, ProductModel>();
                cfg.CreateMap<ProductModel, ProductViewModel>();
            });
        }
    }
}
