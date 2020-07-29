using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeOrganizer.Models;

namespace EmployeeOrganizer.Controllers
{
    public class WorkerTypeController : Controller
    {
        AppDbContext _db;
        public WorkerTypeController(AppDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            WorkerTypeModel model = new WorkerTypeModel(_db);
            WorkerTypeViewModel viewModel = new WorkerTypeViewModel();
            viewModel.WorkerTypes = model.GetAll();
            return View(viewModel);
        }
    }
}
