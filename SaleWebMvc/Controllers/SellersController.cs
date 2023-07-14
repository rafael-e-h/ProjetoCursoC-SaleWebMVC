using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index() //Controller Call
        {
            var list = _sellerService.FindAll(); //Model acceess and return the data of List

            return View(list); //Show the View with this data
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]          //anotation to indicatte that this action is post, not get
        [ValidateAntiForgeryToken] //prevent cross-site request forgeru (XSRF/CSRF) attacl in asp.net core
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); //return to index
        }
    }
}
