using DroneForMedication.DataAccessLayer.DataContext;
using DroneForMedication.DataAccessLayer.IRepository;
using DroneForMedication.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DroneForMedication.DataAccessLayer.Repository
{
    public class DorneRepository:IDorneRepository
    {
        public DorneRepository() {
            using (var context = new DatabaseContext())
            {
                var list = context.Dornes.ToList();
                if (list.Count() >= 0)
                {
                    var dorne = new List<Dorne>
                { new Dorne
                {
                    DorneId=1,
                    SerialNumber="SN_001",
                    Model="Heavyweight",
                    WeightLimit=500,
                    BatteryCapacity=100,
                    Sate="IDLE"
                },
                new Dorne
                {
                    DorneId=2,
                    SerialNumber="SN_002",
                    Model="Cruiserweight",
                    WeightLimit=450,
                    BatteryCapacity=90,
                    Sate="IDLE"
                },
                new Dorne
                {
                    DorneId=3,
                    SerialNumber="SN_003",
                    Model="Middleweight",
                    WeightLimit=400,
                    BatteryCapacity=90,
                    Sate="IDLE"
                },
                 new Dorne
                {
                    DorneId=4,
                    SerialNumber="SN_0004",
                    Model="Lightweight",
                    WeightLimit=300,
                    BatteryCapacity=90,
                    Sate="IDLE"
                },
                  new Dorne
                {
                    DorneId=5,
                    SerialNumber="SN_0005",
                    Model="Lightweight",
                    WeightLimit=300,
                    BatteryCapacity=80,
                    Sate="LOADED"
                },
                   new Dorne
                {
                    DorneId=6,
                    SerialNumber="SN_0006",
                    Model="Cruiserweight",
                    WeightLimit=450,
                    BatteryCapacity=50,
                    Sate="DELIVERING"
                },
                    new Dorne
                {
                    DorneId=7,
                    SerialNumber="SN_0007",
                    Model="Middleweight",
                    WeightLimit=400,
                    BatteryCapacity=60,
                    Sate="DELIVERED"
                },
                    new Dorne
                    {
                    DorneId=8,
                    SerialNumber="SN_0008",
                    Model="Middleweight",
                    WeightLimit=400,
                    BatteryCapacity=60,
                    Sate="RETURNING"
                },
                };
                    context.Dornes.AddRange(dorne);
                    context.SaveChanges();
                }
            }
        
        }
        public List<Dorne> GetAllDorneDetails()
        {
            using (var context = new DatabaseContext())
            {
                var list = context.Dornes.ToList();
                return list;    
            }
        }
        public async Task<int> RegisterNewDorne(Dorne newDorne)//new Dorne added to system
        {
            using (var context = new DatabaseContext())
            {
                await context.Dornes.AddAsync(newDorne);
                await context.SaveChangesAsync();
            }
            return newDorne.DorneId;
        }

        public List<Dorne> GetIdelDorneDetails()
        {
            using (var context = new DatabaseContext())
            {
                var list = context.Dornes.Where(a=>a.Sate== "IDLE").ToList();
                return list;
            }

        }


    }
}
