using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Models
{
    public class WorkerTypeModel
    {
        private AppDbContext _db;
        public WorkerTypeModel(AppDbContext ctx)
        {
            _db = ctx;
        }
        public List<WorkerType> GetAll()
        {
            return _db.WorkerTypes.ToList<WorkerType>();
        }
    }
}
