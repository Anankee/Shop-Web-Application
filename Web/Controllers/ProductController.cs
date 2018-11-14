using Library.Interface;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Infrastrucure;

namespace Web.Controllers
{
    [ClientErrorHandler]
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
            return PartialView(productRepository.GetAll());
        }


        [HttpGet]
        public PartialViewResult Edit(int? id)
        {
            if (id == null)
                return PartialView(new Product());
            return PartialView(productRepository.GetById((int)id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Id > 0)
                {
                    productRepository.Update(product);
                    TempData["message"] = string.Format("{0} has been saved.", product.Name);
                }
                else
                {
                    productRepository.Add(product);
                    TempData["message"] = string.Format("{0} has been added.", product.Name);
                }                
                
                return RedirectToAction("List");
            }
            return Json(ModelState.GetErrorMessages());
        }

        public RedirectToRouteResult Delete(int id)
        {            
            var product = productRepository.Delete(id);
            TempData["message"] = string.Format("{0} has been deleted.", product.Name);
            return RedirectToAction("List");
        }
    }
}