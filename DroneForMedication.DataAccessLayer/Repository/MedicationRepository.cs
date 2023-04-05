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
    public class MedicationRepository: IMedicationRepository
    {
        public MedicationRepository()
        {
            
            using (var context = new DatabaseContext())
            {
                var list = context.Medications.ToList();
                if (list.Count()<=0)
                {
                    var medicationItem = new List<Medication> {
                new Medication()
                {
                    MedicationId=1,
                    MedicationName="Paracetamol",
                    Code="PL_01",
                    Weight=50,
                    ImageURL="http://uuuiiii.com"

                },
                new Medication()
                {
                    MedicationId=2,
                    MedicationName="Domperidone",
                    Code="DD_01",
                    Weight=40,
                    ImageURL="http://uuuiiii.com"

                },
                 new Medication()
                {
                    MedicationId=3,
                    MedicationName="Samahan",
                    Code="SH_01",
                    Weight=10,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=4,
                    MedicationName="Cetirizine",
                    Code="CZ_01",
                    Weight=40,
                    ImageURL="http://uuuiiii.com"

                },
                 new Medication()
                {
                    MedicationId=5,
                    MedicationName="Asamodagam",
                    Code="AS_01",
                    Weight=150,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=6,
                    MedicationName="Paspanguwa",
                    Code="PS_01",
                    Weight=60,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=7,
                    MedicationName="Amoxicillin",
                    Code="AL_01",
                    Weight=50,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=8,
                    MedicationName="Deriphyllin",
                    Code="DL_01",
                    Weight=40,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=9,
                    MedicationName="Ventolin",
                    Code="VL_01",
                    Weight=40,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=10,
                    MedicationName="Plaster",
                    Code="PL_01",
                    Weight=20,
                    ImageURL="http://uuuiiii.com"

                },

                  new Medication()
                {
                    MedicationId=11,
                    MedicationName="Betadine",
                    Code="BT_01",
                    Weight=100,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=12,
                    MedicationName="Surgical Sprit",
                    Code="SS_01",
                    Weight=150,
                    ImageURL="http://uuuiiii.com"

                },
                  new Medication()
                {
                    MedicationId=13,
                    MedicationName="Wintogeno Cream",
                    Code="WC_01",
                    Weight=100,
                    ImageURL="http://uuuiiii.com"

                },
                   new Medication()
                {
                    MedicationId=14,
                    MedicationName="Bicozeen Syrup",
                    Code="BS_01",
                    Weight=200,
                    ImageURL="http://uuuiiii.com"

                },
                };
                    context.Medications.AddRange(medicationItem);
                    context.SaveChanges();
                }
            }
        }
        public List<Medication> GetAllMedicationDetails()
        {
            using (var context = new DatabaseContext())
            {
                var list = context.Medications.ToList();
                return list;
            }
        }

        public async Task<int> RegisterNewMedication(Medication newMedication)//new Dorne added to system
        {
            using (var context = new DatabaseContext())
            {
                await context.Medications.AddAsync(newMedication);
                await context.SaveChangesAsync();
            }
            return newMedication.MedicationId;
        }

    }
}
