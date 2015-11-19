using MvcSports.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSports.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //// GET: Product
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}