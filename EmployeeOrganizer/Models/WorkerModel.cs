using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Models
{
    public class WorkerModel
    {
        private AppDbContext _db;
        public WorkerModel(AppDbContext context)
        {
            _db = context;
        }
        public List<Worker> GetAll()
        {
            return _db.Workers.ToList();
        }
        public List<Worker> GetAllByWorkerType(int id)
        {
            return _db.Workers.Where(item => item.WorkerType.Id == id).ToList();
        }
        public WorkerType GetWorkerType(int id)
        {
            return _db.WorkerTypes.FirstOrDefault(type => type.Id == id);
        }
    }
}
