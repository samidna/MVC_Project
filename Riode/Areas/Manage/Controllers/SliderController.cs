using Microsoft.AspNetCore.Mvc;
using Riode.Extentions;
using Riode.Models;
using Riode.Services.Interfaces;
using Riode.ViewModels.SliderVMs;

namespace Riode.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly ISliderService _service;

        public SliderController(ISliderService service)
        {
            _service=service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM vm)
        {
            if (vm.ImageFile != null)
            {
                if (!vm.ImageFile.IsTypeValid("image"))
                    ModelState.AddModelError("ImageFile", "Wrong file type");
                if (vm.ImageFile.IsSizeValid(2))
                    ModelState.AddModelError("ImageFile", "File max size is 2mb");
            }
            if (!ModelState.IsValid) return View();
            await _service.Create(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}













