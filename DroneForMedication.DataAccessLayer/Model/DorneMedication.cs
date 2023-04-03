using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.Model
{
    public class DorneMedication
    {
        public int DorneId { get; set; }
        public Dorne Dorne { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }
    }
}
    
