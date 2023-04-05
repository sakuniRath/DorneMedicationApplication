using DorneForMedication.BusinessLayer.Models;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
using DroneForMedication.DataAccessLayer.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.BLogic
{
    public class MedicationBL
    {
        private IMedicationRepository medicationRepo = new MedicationRepository();
        private IDorneRepository dorneRepository= new DorneRepository();
        private IDorneMedicationRepository dorneMedicationRepository= new DorneMedicationRepository();  
        public async Task<List<MedicationModel>> GetMedicationDetails()
        {
            List<MedicationModel> mm = new List<MedicationModel>();
            IEnumerable<Medication> medicationAllList = medicationRepo.GetAllMedicationDetails();
            foreach (var medication in medicationAllList)
            {
                mm.Add(new MedicationModel()
                {

                    MedicationId = medication.MedicationId,
                    MedicationName = medication.MedicationName,
                    Code = medication.Code,
                    Weight = medication.Weight,
                    Image = medication.ImageURL

                });


            }

            return mm;
        }

        public async Task<bool> RegisterNewMedication(MedicationModel medicationModel)//new medication map to MedicationModel
        {
            try
            {

                Medication newMedication = new Medication
                {
                    MedicationName= medicationModel.MedicationName, 
                    Code = medicationModel.Code,
                    Weight = medicationModel.Weight,
                    ImageURL=medicationModel.Image
                };
                var result = await medicationRepo.RegisterNewMedication(newMedication);
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

        public async Task<bool> ResigterMedicationForDorne(int[] dronMedicationModel)
        {
            IEnumerable<Medication> medicationList= medicationRepo.GetAllMedicationDetails();
            int medicationWeight=0;
            bool status = false;

            foreach (int items in dronMedicationModel)
            {
                int weightOfMedicine = medicationList.Where(a => a.MedicationId == items).Select(a => a.Weight).FirstOrDefault();
                medicationWeight = medicationWeight + weightOfMedicine;
            }
            
            if (medicationWeight > 500)
            {
                status = false;
            }
            else if (medicationWeight <= 500 && medicationWeight > 450)
            {
                int availableDorneID = dorneRepository.GetIdelDorneDetails().Where(a => a.Model == "Heavyweight").Select(b => b.DorneId).FirstOrDefault();
                if (availableDorneID == 0)
                {
                    return status = false;
                }
                await SaveDorneMedicationDetails(dronMedicationModel, availableDorneID);
                return status = true;   
            }
            else if (medicationWeight <= 450 && medicationWeight > 400)
            {
                int availableDorneID = dorneRepository.GetIdelDorneDetails().Where(a => a.Model == "Cruiserweight" || a.Model == "Heavyweight").Select(b => b.DorneId).FirstOrDefault();
                if (availableDorneID == 0)
                {
                    return status = false;
                }
                await SaveDorneMedicationDetails(dronMedicationModel, availableDorneID);
                return status = true;
            }
            else if (medicationWeight <= 400 && medicationWeight > 300)
            {
                int availableDorneID = dorneRepository.GetIdelDorneDetails().Where(a => a.Model == "Cruiserweight" || a.Model == "Heavyweight"|| a.Model == "Middleweight").Select(b => b.DorneId).FirstOrDefault();
                if (availableDorneID == 0)
                {
                    return status = false;
                }
                await SaveDorneMedicationDetails(dronMedicationModel, availableDorneID);
                return status = true;
            }
            else if (medicationWeight <= 300)
            {
                int availableDorneID = dorneRepository.GetIdelDorneDetails().Select(b => b.DorneId).FirstOrDefault();
                if (availableDorneID == 0)
                {
                    return status = false;
                }
                await SaveDorneMedicationDetails(dronMedicationModel, availableDorneID);
                return status = true;
            }
            return status;
        }

        public async Task<bool> SaveDorneMedicationDetails(int[] dronMedicationModel,int dorneId)
        {
            foreach (int items in dronMedicationModel)
            {
                await dorneMedicationRepository.DorneMedicationRepository(dorneId, items);
            }
            return true;
        
        }
        public async Task<List<string>> GetMedicationDetailsForGivenDorne(int dorneId)
        {
            List<string> medicationDetails=dorneMedicationRepository.GetMedicationDetailsForGivenDorne(dorneId);
            return medicationDetails;
        }
     }
}
