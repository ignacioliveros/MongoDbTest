using Domain;
using Domain.Entities;
using Domain.Repository;
using MongoDbTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDbTest.Controllers
{
    public class ReportController : Controller
    {
        private MongoDbContext<Report> repoContext = new MongoDbContext<Report>();
        private MongoDbContext<ReportMetadata> metaRepoContext = new MongoDbContext<ReportMetadata>();
        private ReportRepository repo;
        private ReportMetadataRepository metaRepo;

        public ReportController()
        {
            this.repo = new ReportRepository(repoContext);
            this.metaRepo = new ReportMetadataRepository(metaRepoContext);
        }



        public ActionResult Index()
        {
            var vm = GetReportViewModel();
            return View(vm);
        }

        public ActionResult ReportGrid()
        {
            var vm = GetReportViewModel();

            return PartialView("_ReportView", vm);
        }
        
        [HttpPost]
        public ActionResult Create(Report report,string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                report.Id = Guid.NewGuid().ToString();
                repo.AddOne(report);
                metaRepo.SeedRepoMeta(report.Id);
                
            }
            else
            {
                repo.UpDate(report, id);
            }
            return RedirectToAction("Index");
        }


        public JsonResult LoadUpdateForm(string id)
        {
            var vm = repo.GetById(id);
            return Json(vm, JsonRequestBehavior.AllowGet);
        }
       
        public void Delete(string id)
        {
            if (id != null)
            {
                repo.Delete(id);
            }
        }

        private ReportViewModel GetReportViewModel()
        {
            var report = new Report();
            var reportViewModel = new ReportViewModel();  
                       
           reportViewModel.Reports= repo.GetAll();
           reportViewModel.Report = report;
           return reportViewModel;
        }

    }
}
