using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeOrganizer.Models;

namespace EmployeeOrganizer.Controllers
{
    public class WorkerController : Controller
    {
        AppDbContext _db;
        public WorkerController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index(WorkerTypeViewModel workerType)
        {
            WorkerModel model = new WorkerModel(_db);
            WorkerViewModel viewModel = new WorkerViewModel();
            viewModel.Workers = model.GetAllByWorkerType(workerType.Id);
            viewModel.WorkerTypeName = model.GetWorkerType(workerType.Id).Name;
            return View(viewModel);
        }
    }
}
