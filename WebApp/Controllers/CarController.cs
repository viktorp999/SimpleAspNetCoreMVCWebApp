using Microsoft.AspNetCore.Mvc;
using WebApp.AppUnitOfWork;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CarController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CarController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cars = _unitofwork.CarRepository.GetAll();

            return View(cars);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var car = _unitofwork.CarRepository.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            return View("Details", car);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostCreate(Car car)
        {
             _unitofwork.CarRepository.Add(car);
             _unitofwork.Save();
             _unitofwork.Dispose();

             return RedirectToAction("Index");         
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var car = _unitofwork.CarRepository.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            return View("Delete", car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int id)
        {
            _unitofwork.CarRepository.Delete(id);
            _unitofwork.Save();
            _unitofwork.Dispose();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var car = _unitofwork.CarRepository.Get(id);

            if (car == null)
            {
                return NotFound();
            }

            return View("Edit", car);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostUpdate(Car car)
        {
            _unitofwork.CarRepository.Update(car);
            _unitofwork.Save();
            _unitofwork.Dispose();

            return RedirectToAction("Index");
        }
    }
}
