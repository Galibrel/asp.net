using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SalesWebmvc.Models;
using SalesWebmvc.Models.ViewModels;
using SalesWebmvc.Services;
using System.Security.AccessControl;

namespace SalesWebmvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SellerService _sallersService;
        private readonly DepartmentService _departmentService;

        public SallersController(SellerService sallersService, DepartmentService departmentService)//injeção de dependecia
        {
            _sallersService = sallersService;
            _departmentService = departmentService;
        }
        public IActionResult Index()//ação de colocar a lista na view
        {
            var list = _sallersService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();//puxando o os departamentos por select no banco
            var viewModel = new SallerFormViewModel { Departments = departments };
            return View(viewModel);// passando a instancia do Saller form View model
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallersService.Insert(saller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sallersService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sallersService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sallersService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
    }
}
