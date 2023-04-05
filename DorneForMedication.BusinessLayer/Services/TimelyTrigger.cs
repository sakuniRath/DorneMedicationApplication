using DorneForMedication.BusinessLayer.Models;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
using DroneForMedication.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DorneForMedication.BusinessLayer.Services
{
    public class TimelyTrigger
    {
        
        private static System.Timers.Timer aTimer;
        private IDorneBatteryLevelHistoryRepository dorneBatteryLevelHistoryRepository = new DorneBatteryLevelHistoryRepository();
        private IDorneRepository dornRepo = new DorneRepository();
        public TimelyTrigger(int intervalInMilliseconds)
        {
            aTimer = new System.Timers.Timer(intervalInMilliseconds);
            aTimer.Elapsed += OnElapsed;
        }

        public void start()
        {
            aTimer.Start();
        }

        public void stop() { aTimer.Stop();}
        private void OnElapsed(object sender, ElapsedEventArgs e)
        {
            IEnumerable<Dorne> dorneAllList=dornRepo.GetAllDorneDetails().Where(a=>a.Sate== "DELIVERING");

            foreach (var items in dorneAllList) {
                DorneBatteryLevelHistory dorneBatteryLevelHistory=new DorneBatteryLevelHistory();
                dorneBatteryLevelHistory.BatteryCapacity=items.BatteryCapacity; 
                dorneBatteryLevelHistory.DorneId=items.DorneId;
                dorneBatteryLevelHistory.CurrentDate=DateTime.Now;
                dorneBatteryLevelHistoryRepository.AddNewHistoryDetails(dorneBatteryLevelHistory);
              }
        }

        public List<DorneBatteryLevelHistoryModel> GetAllHistoryDorneDetails()
        {
            IEnumerable<DorneBatteryLevelHistory> dorneHistoryAllList = dorneBatteryLevelHistoryRepository.GetAllDorneHistoryDetails();
            List<DorneBatteryLevelHistoryModel> dr = new List<DorneBatteryLevelHistoryModel>();
            foreach (var Items in dorneHistoryAllList)
            {
                dr.Add(new DorneBatteryLevelHistoryModel()
                {
                    DorneBatteryLevelHistoryId=Items.DorneBatteryLevelHistoryId,
                    DorneId = Items.DorneId,
                    BatteryCapacity=Items.BatteryCapacity,
                    CurrentDate =Items.CurrentDate,
                    
                 });
            
            }
            return dr;


        }
    }
}
