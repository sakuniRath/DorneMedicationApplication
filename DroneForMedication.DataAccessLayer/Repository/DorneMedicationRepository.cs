using DroneForMedication.DataAccessLayer.DataContext;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
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


            } }

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
    }
        
}
