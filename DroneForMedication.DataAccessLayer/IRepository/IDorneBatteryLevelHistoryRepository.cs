using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.IRepository
{
    public interface IDorneBatteryLevelHistoryRepository
    {
        public Task<bool> AddNewHistoryDetails(DorneBatteryLevelHistory dorneBatteryLevelHistory);
        public List<DorneBatteryLevelHistory> GetAllDorneHistoryDetails();
    }
}
