using Library.Interface;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult List()
        {
            return PartialView(productRepository.GetProducts());
        }

        [HttpGet]
        public PartialViewResult Create()
        {
            return PartialView(new Product());
        }

        [HttpPost]
        public bool Create(Product product)
        {
            productRepository.Add(product);
            return true;
        }

        [HttpPost]
        public void Delete(int id)
        {
            productRepository.Remove(id);
        }
    }
}