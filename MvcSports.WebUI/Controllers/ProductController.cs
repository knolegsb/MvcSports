﻿using MvcSports.Domain.Abstract;
using MvcSports.WebUI.Models;
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

        //public ViewResult List()
        //{
        //    return View(repository.Products);
        //}

        public int PageSize = 4;

        //public ViewResult List(int page = 1)
        //{
        //    return View(repository.Products
        //        .OrderBy(p => p.ProductID)
        //        .Skip((page - 1)* PageSize)
        //        .Take(PageSize));
        //}

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    //TotalItems = repository.Products.Count()

                    // *adding count
                    TotalItems = category == null ?
                        repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}