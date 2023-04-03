using DorneForMedication.BusinessLayer.BLogic;
using DorneForMedication.BusinessLayer.Iservices;
using DorneForMedication.BusinessLayer.Models;
using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.Services
{
    public class MedicationService: IMedicationService
    {
        private MedicationBL medicationbl = new MedicationBL();
        public async Task<List<MedicationModel>> GetMedicationDetails()
        {
            List<MedicationModel> medicationDetails = await medicationbl.GetMedicationDetails();

            return medicationDetails;
        }

        public async Task<bool> RegisterNewMedication(MedicationModel medicationModel)
        {
            bool status = await medicationbl.RegisterNewMedication(medicationModel);

            return status;
        }
        public async Task<bool> ResigterMedicationForDorne(int[] dornMedicationModel)
        {
            bool status = await medicationbl.ResigterMedicationForDorne(dornMedicationModel);

            return status;
        }
    }
}
