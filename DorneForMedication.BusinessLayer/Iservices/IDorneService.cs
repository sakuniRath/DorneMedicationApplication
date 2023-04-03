using DorneForMedication.BusinessLayer.Models;
using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.Iservices
{
    public interface IDorneService
    {
        public  Task<List<DorneModel>> GetDorneDetails();
        public Task<bool> RegisterNewDorne(DorneModel dorneModel);

        public Task<List<DorneModel>> GetIdleDorneDetails();

        
    }
}
