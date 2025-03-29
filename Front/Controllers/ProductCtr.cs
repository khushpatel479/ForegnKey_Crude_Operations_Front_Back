using Inmemory_Consumer.Models;
using Inmemory_Consumer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Inmemory_Consumer.Controllers
{
    public class ProductCtr : Controller
    {
        ProductServices ser;
        public ProductCtr(ProductServices _ser)
        {
            ser= _ser;
        }
        public async Task<IActionResult> Index()
        {
            var ty = await ser.prget();
            return View(ty);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductModel pl)
        {
            var ty = await ser.prins(pl);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ty = await ser.getid(id);
            return View(ty);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id , ProductModel mp)
        {
            var ty = await ser.updpr(mp, id);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var ty = await ser.disbyid(id);
            return View(ty);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ty = await ser.fghid(id);
            return View(ty);
        }
        [HttpPost]
        public async Task<IActionResult> Delete1(int id)
        {
            var ty = await ser.delpr(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Search1(string ProductName)
        {
            var ty = await ser.serchbyname(ProductName);
            return View(ty);
        }


    }
}
