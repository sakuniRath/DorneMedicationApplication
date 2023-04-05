using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue("true")]
        public bool IsTaskLevel { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}
    
