using MvcSports.Domain.Abstract;
using MvcSports.Domain.Entities;
using MvcSports.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSports.WebUI.Controllers
{
    public class CartController : Controller
    {
        //// GET: Cart
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private IProductRepository repository;
        private IOrderProcessor orderProcessor;

        public CartController (IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                //Cart = GetCart(),
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                //GetCart().AddItems(product, 1);
                cart.AddItems(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                //GetCart().RemoveLine(product);
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if(cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}