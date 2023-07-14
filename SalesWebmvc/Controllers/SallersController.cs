using Microsoft.AspNetCore.Mvc;
using SalesWebmvc.Services;
using System.Security.AccessControl;

namespace SalesWebmvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SellerService _sallersService;

        public SallersController(SellerService sallersService)//injeção de dependecia
        {
            _sallersService= sallersService;
        }
        public IActionResult Index()
        {
            var list = _sallersService.FindAll();
            return View(list);
        }
    }
}
