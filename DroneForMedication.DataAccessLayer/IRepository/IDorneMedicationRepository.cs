using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.IRepository
{
    public interface IDorneMedicationRepository
    {
        public Task<bool> DorneMedicationRepository(int dorneId, int medicationId);
    }
}
