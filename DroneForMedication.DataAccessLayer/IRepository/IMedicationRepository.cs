using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.IRepository
{
    public interface IMedicationRepository
    {
        public List<Medication> GetAllMedicationDetails();
        public Task<int> RegisterNewMedication(Medication newMedication);
    }
}
