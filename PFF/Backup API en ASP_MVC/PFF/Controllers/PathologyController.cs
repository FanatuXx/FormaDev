using Microsoft.AspNetCore.Mvc;
using PFF.App.Models;
using PFF.Domain.Commands;
using PFF.Domain.Model.Entities;
using PFF.Domain.Queries;
using PFF.Domain.Repositories;
using PFF.Tools.Results;

namespace PFF.App.Controllers
{
    public class PathologyController(IPathologyRepository pathologyRepository) : Controller
    {
        private readonly IPathologyRepository _pathologyRepository = pathologyRepository;

        public IActionResult Index()
        {
            Result<IEnumerable<Pathology>> result = _pathologyRepository.Handle(new GetPathologiesQuery());

            if (result.IsFailure)
            {
                ViewBag.ErrorMessage = result.Error.ToString();
                return View(Enumerable.Empty<Pathology>());
            }

            return View(result.Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePathologyForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            Result result = _pathologyRepository.Handle(new CreatePathologyCommand(form.Name));

            if (result.IsFailure)
            {
                ModelState.AddModelError("", result.Error.ToString());
                return View(form);
            }

            return RedirectToAction("Index");
        }
    }
}
