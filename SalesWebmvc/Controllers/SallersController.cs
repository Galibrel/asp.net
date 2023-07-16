using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SalesWebmvc.Models;
using SalesWebmvc.Models.ViewModels;
using SalesWebmvc.Services;
using SalesWebmvc.Services.Exceptions;
using System.Diagnostics;
using System.Security.AccessControl;

namespace SalesWebmvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SellerService _sallersService;
        private readonly DepartmentService _departmentService;
        private object _sallerService;

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
                return RedirectToAction(nameof(Error), new { message = "Id not provided"});
            }
            var obj = _sallersService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
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
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = _sallersService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sallersService.FindById(id.Value);//ve se existe o id no banco
            if (obj == null)
            {
                return NotFound();
            }
            List<Department> departments = _departmentService.FindAll();
            SallerFormViewModel viewModel = new SallerFormViewModel { Saller = obj, Departments = departments };//lista os departamentos e o vendedor na tela de edit 

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Saller saller)
        {
            if (id != saller.Id)//verifica o id
            {
                return BadRequest();
            }
            try
            {
                _sallersService.Update(saller);//faz update no banco apos o edi 
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException e)
            {
                return BadRequest();
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
              
                Message = message
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
