using DorneForMedication.BusinessLayer.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.Iservices
{
    public interface IMedicationService
    {
        public Task<List<MedicationModel>> GetMedicationDetails();
        public Task<bool> RegisterNewMedication(MedicationModel medicationModel);

        public Task<bool> ResigterMedicationForDorne(int[] medicationModel);
    }
}
