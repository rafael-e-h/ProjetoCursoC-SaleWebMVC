using Microsoft.AspNetCore.Mvc;
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
    }
}
