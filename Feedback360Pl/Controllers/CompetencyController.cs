using Feedback360Pl.DAL.Interfaces;
using Feedback360Pl.DAL.Models;
using Feedback360Pl.DAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback360pl.Controllers
{
    public class CompetencyController : Controller
    {
        private readonly ILogger<CompetencyController> logger;
        private readonly IUnitOfWork unitOfWork;

        public CompetencyController(ILogger<CompetencyController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        // GET: CompetencyController
        [HttpGet("/kompetencje/index")]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Competency> competencies = new List<Competency>();
            competencies = await unitOfWork.Competencies.GetAllAsync();
            ViewBag.DataSource = competencies.Select(a => new CompetencyVM()
            {
                Id = a.Id,
                Name = a.Name,
                Keywords = a.Keywords
            });

            return View();
        }

        // GET: CompetencyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompetencyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompetencyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompetencyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompetencyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompetencyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
