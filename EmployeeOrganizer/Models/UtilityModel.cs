using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeOrganizer.Models
{
    public class UtilityModel
    {
        private AppDbContext _db;
        public UtilityModel(AppDbContext context) // will be sent by controller
        {
            _db = context;
        }

        public bool loadWorkerTables(string stringJson)
        {
            bool workerTypesLoaded = false;
            bool workersLoaded = false;
            try
            {
                dynamic objectJson = Newtonsoft.Json.JsonConvert.DeserializeObject(stringJson);
                workerTypesLoaded = loadWorkerTypes(objectJson);
                workersLoaded = loadWorkers(objectJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return workerTypesLoaded && workersLoaded;
        }

        private bool loadWorkerTypes(dynamic objectJson)
        {
            bool loadedWorkerTypes = false;
            try
            {
                // clear out the old rows
                _db.WorkerTypes.RemoveRange(_db.WorkerTypes);
                _db.SaveChanges();
                List<String> allWorkerTypes = new List<String>();
                foreach (var node in objectJson)
                {
                    allWorkerTypes.Add(Convert.ToString(node["WORKERTYPE"]));
                }
                // distinct will remove duplicates before we insert them into the db
                IEnumerable<String> workerTypes = allWorkerTypes.Distinct<String>();
                foreach (string catname in workerTypes)
                {
                    WorkerType wt = new WorkerType();
                    wt.Name = catname;
                    _db.WorkerTypes.Add(wt);
                    _db.SaveChanges();
                }
                loadedWorkerTypes = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
            }
            return loadedWorkerTypes;
        }

        private bool loadWorkers(dynamic objectJson)
        {
            bool loadedItems = false;
            try
            {
                List<WorkerType> workerTypes = _db.WorkerTypes.ToList();
                // clear out the old
                _db.Workers.RemoveRange(_db.Workers);
                _db.SaveChanges();
                foreach (var node in objectJson)
                {
                    Worker worker = new Worker();
                    worker.FirstName = Convert.ToString(node["FIRSTNAME"].Value);
                    worker.LastName = Convert.ToString(node["LASTNAME"].Value);
                    string wt = Convert.ToString(node["WORKERTYPE"].Value);
                    // add the FK here
                    foreach (WorkerType workerType in workerTypes)
                    {
                        if (workerType.Name == wt)
                            worker.WorkerType = workerType;
                    }
                    _db.Workers.Add(worker);
                    _db.SaveChanges();
                }
                loadedItems = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error - " + ex.Message);
            }
            return loadedItems;
        }
    }
}
