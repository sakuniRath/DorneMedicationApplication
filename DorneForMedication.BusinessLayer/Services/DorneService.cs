using DorneForMedication.BusinessLayer.BLogic;
using DorneForMedication.BusinessLayer.Iservices;
using DorneForMedication.BusinessLayer.Models;
using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.Services
{
    public class DorneService : IDorneService
    {
        private DorneBL dornebl=new DorneBL();
        public async Task<List<DorneModel>> GetDorneDetails()
        {
            List<DorneModel> dorneDetails = await dornebl.GetDorneDetails();

            return dorneDetails;
        }
       
        public async Task<bool> RegisterNewDorne(DorneModel dorneModel)
        {
            bool status = await dornebl.RegisterNewDorne(dorneModel);

            return status;
        }

        public async Task<List<DorneModel>> GetIdleDorneDetails()
        {
            List<DorneModel> dorneDetails = await dornebl.GetIdleDorneDetails();

            return dorneDetails;
        }
    }
}
