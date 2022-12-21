using Microsoft.AspNetCore.Mvc;
using WebApp.AppUnitOfWork;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IUnitOfWork _unitofwork;

        public OwnerController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var owners = _unitofwork.OwnerRepository.GetAll();

            return View(owners);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var owner = _unitofwork.OwnerRepository.Get(id);

            if (owner == null)
            {
                return NotFound();
            }

            return View("Details", owner);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostCreate(Owner owner)
        {
            _unitofwork.OwnerRepository.Add(owner);
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

            var owner = _unitofwork.OwnerRepository.Get(id);

            if (owner == null)
            {
                return NotFound();
            }

            return View("Delete", owner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDelete(int id)
        {
            _unitofwork.OwnerRepository.Delete(id);
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

            var owner = _unitofwork.OwnerRepository.Get(id);

            if (owner == null)
            {
                return NotFound();
            }

            return View("Edit", owner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostUpdate(Owner owner)
        {
            _unitofwork.OwnerRepository.Update(owner);
            _unitofwork.Save();
            _unitofwork.Dispose();

            return RedirectToAction("Index");
        }
    }
}
