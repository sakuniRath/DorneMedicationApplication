using DorneForMedication.BusinessLayer.Models;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
using DroneForMedication.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.BLogic
{
    public class DorneBL
    {
        private IDorneRepository dornRepo = new DorneRepository();
        public async Task<List<DorneModel>> GetDorneDetails()
        {
            List<DorneModel> dr = new List<DorneModel>();
            IEnumerable<Dorne> dorneAllList = dornRepo.GetAllDorneDetails();
            foreach (var dorne in dorneAllList)
            {
                dr.Add(new DorneModel()
                { 
                    DorneId = dorne.DorneId,
                    SerialNumber = dorne.SerialNumber,
                    WeightLimit = dorne.WeightLimit,
                    BatteryCapacity = dorne.BatteryCapacity,
                    State = dorne.Sate 
                });
            }
            return dr;
        }
        public async Task<bool> RegisterNewDorne(DorneModel dorneModel)//new dorne map to dorneModel
        {
            try
            {
                   Dorne newDorne = new Dorne
                {
                    SerialNumber = dorneModel.SerialNumber,
                    Model = dorneModel.Model,
                    WeightLimit = dorneModel.WeightLimit,
                    BatteryCapacity = dorneModel.BatteryCapacity,
                    Sate = dorneModel.State
                };
                var result = await dornRepo.RegisterNewDorne(newDorne);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<DorneModel>> GetIdleDorneDetails()
        {
            List<DorneModel> dr = new List<DorneModel>();
            IEnumerable<Dorne> dorneAllList = dornRepo.GetIdelDorneDetails();
            foreach (var dorne in dorneAllList)
            {
                dr.Add(new DorneModel()
                {

                    DorneId = dorne.DorneId,
                    SerialNumber = dorne.SerialNumber,
                    WeightLimit = dorne.WeightLimit,
                    BatteryCapacity = dorne.BatteryCapacity,
                    State = dorne.Sate

                });
            }
            return dr;
        }


    }
}
