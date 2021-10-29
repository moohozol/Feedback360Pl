using Feedback360Pl.DAL.Interfaces;
using Feedback360Pl.DAL.Models;
using Feedback360Pl.DAL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        //[HttpGet("/kompetencje/index")]
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Insert([FromBody] ICRUDModel<CompetencyVM> value)
        {
            Competency competency = new Competency();
            competency.Name = value.value.Name;
            competency.Keywords = value.value.Keywords;
            await unitOfWork.Competencies.AddAsync(competency);
            return Json(value.value);
        }

        public async Task<ActionResult> Update([FromBody] ICRUDModel<CompetencyVM> value)
        {
            Competency competency = new Competency();
            competency = await unitOfWork.Competencies.GetByIdAsync(value.value.Id);
            competency.Name = value.value.Name;
            competency.Keywords = value.value.Keywords;
            await unitOfWork.Competencies.UpdateAsync(competency);

            return Json(value.value);
        }

        public async Task<ActionResult> Delete([FromBody] ICRUDModel<CompetencyVM> value)
        {
            Competency competency = new Competency();
            var id = (JsonSerializer.Deserialize<CompetencyVM>(value.key.ToString())).Id;
            competency = await unitOfWork.Competencies.GetByIdAsync(id);

            await unitOfWork.Competencies.RemoveAsync(competency);
            return Json(value);
        }

        public async Task<ActionResult> UrlDataSource([FromBody] DataManagerRequest dm)
        {
            IEnumerable<CompetencyVM> DataSource = new List<CompetencyVM>();

            IEnumerable<Competency> competencies = new List<Competency>();
            competencies = await unitOfWork.Competencies.GetAllAsync();
            DataSource = competencies.Select(a => new CompetencyVM()
            {
                Id = a.Id,
                Name = a.Name,
                Keywords = a.Keywords
            });

            DataOperations operation = new DataOperations();
            if (dm.Search != null && dm.Search.Count > 0)
            {
                DataSource = operation.PerformSearching(DataSource, dm.Search);  //Search
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0) //Sorting
            {
                DataSource = operation.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0) //Filtering
            {
                DataSource = operation.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
            }
            int count = DataSource.Cast<CompetencyVM>().Count();
            if (dm.Skip != 0)
            {
                DataSource = operation.PerformSkip(DataSource, dm.Skip);   //Paging
            }
            if (dm.Take != 0)
            {
                DataSource = operation.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? Json(new { result = DataSource, count = count }) : Json(DataSource);
        }
    }
}
