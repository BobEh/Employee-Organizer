using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeOrganizer.Models
{
    public class WorkerTypeViewModel
    {
        public WorkerTypeViewModel() { }
        public string WorkerTypeName { get; set; }
        public int Id { get; set; }
        public List<WorkerType> WorkerTypes { get; set; }
        public IEnumerable<SelectListItem> GetWorkerTypes()
        {
            return WorkerTypes.Select(workerType => new SelectListItem { Text = workerType.Name, Value = workerType.Id.ToString() });
        }
    }
}
