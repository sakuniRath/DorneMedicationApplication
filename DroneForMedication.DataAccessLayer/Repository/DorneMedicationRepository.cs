using DroneForMedication.DataAccessLayer.DataContext;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.Repository
{
    public class DorneMedicationRepository : IDorneMedicationRepository
    {
        public DorneMedicationRepository()
        {
            
                using (var context = new DatabaseContext())
            {
                var list = context.DorneMedications.ToList();
                if (list.Count()>= 0)
                {
                    var dornMedication = new List<DorneMedication>
                {
                    new DorneMedication
                    {
                        DorneId=1,
                        MedicationId=14,
                    },
                     new DorneMedication
                    {
                        DorneId=1,
                        MedicationId=13,
                    },
                      new DorneMedication
                    {
                        DorneId=1,
                        MedicationId=12,
                    }


                };
                    context.DorneMedications.AddRange(dornMedication);
                    context.SaveChanges();

                }
            } 
        }

        async Task<bool> IDorneMedicationRepository.DorneMedicationRepository(int dorneId, int medicationId)
        {
            using (var context = new DatabaseContext())
            {
                DorneMedication dm = new DorneMedication();
                dm.DorneId = dorneId;
                dm.MedicationId = medicationId;
                await context.DorneMedications.AddAsync(dm);
                await context.SaveChangesAsync();
            }
            return true;
        }
        public List<string> GetMedicationDetailsForGivenDorne(int dorneId)
        {
            using (var context = new DatabaseContext())
            {
                List<int> list = context.DorneMedications.Where(a => a.DorneId == dorneId).Select(b => b.MedicationId).ToList();
                List<string> MedicationNames = new List<string>();
                //List<DorneMedication> medicationList=context.DorneMedications.Where(a => a.DorneId == dorneId).Include(b=>b.Medication.MedicationName).ToList();
                foreach (int items in list)
                {
                    //= context.DorneMedications.Where(s => s.DorneId == items)
                    //       .Select(s => new
                    //       {
                    //           MedicationName = s.Medication.MedicationName,
                    //       });
                    var medicationName = context.Medications.Where(s => s.MedicationId == items).Select(b=>b.MedicationName).FirstOrDefault();


                    MedicationNames.Add(medicationName.ToString());
                }
                return MedicationNames;
            }
        }
    }
        
}
