using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppUI.Models;
using AppUI.Services;

namespace AppUI.Controllers
{
    public class ProductsController : Controller
    {

        private readonly StoreService _storeService;

        public ProductsController(StoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public ActionResult<List<Product>> Index()
        {
            return View(_storeService.Get());
        }

        [HttpGet("Details/{id:length(24)}")]
        public ActionResult<Product> Details(string id)
        {
            var p = _storeService.Get(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                _storeService.Create(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("Edit/{id:length(24)}")]
        public ActionResult Edit(string id)
        {
            var p = _storeService.Get(id);
            if (p == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(p);
        }

        [HttpPost("Edit/{id:length(24)}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Product product)
        {
            try
            {
                var p = _storeService.Get(id);

                if (p == null)
                {
                    return View();
                }

                _storeService.Update(id, product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("Delete/{id:length(24)}")]
        public ActionResult Delete(string id)
        {

            var p = _storeService.Get(id);

            if (p == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(p);
        }

        [HttpPost("Delete/{id:length(24)}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, Product product)
        {
            try
            {
                var p = _storeService.Get(id);

                if (p == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                _storeService.Remove(p.ProductId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
