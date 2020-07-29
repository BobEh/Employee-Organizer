using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Models
{
    public class WorkerViewModel
    {
        public string WorkerTypeName { get; set; }
        public IEnumerable<Worker> Workers { get; set; }
    }
}
