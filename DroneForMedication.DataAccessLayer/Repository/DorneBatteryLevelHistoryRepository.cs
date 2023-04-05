using DroneForMedication.DataAccessLayer.DataContext;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.Repository
{
    public class DorneBatteryLevelHistoryRepository : IDorneBatteryLevelHistoryRepository
    {
        public async Task<bool> AddNewHistoryDetails(DorneBatteryLevelHistory dorneBatteryLevelHistory)
        {
            try
            {
                using (var context = new DatabaseContext())
                {
                    await context.dorneBatteryLevelHistorys.AddAsync(dorneBatteryLevelHistory);
                    await context.SaveChangesAsync();
                }
                return true;
            }
            catch {
                return false;
            }
            
        }

        public List<DorneBatteryLevelHistory> GetAllDorneHistoryDetails()
        {
            using (var context = new DatabaseContext())
            {
                var list = context.dorneBatteryLevelHistorys.ToList();
                return list;
            }
        }
    }
}
