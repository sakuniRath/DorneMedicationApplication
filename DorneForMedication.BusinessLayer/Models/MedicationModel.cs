using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.Models
{
    public class MedicationModel
    {
        public int MedicationId { get; set; }
        public string MedicationName { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }

        public int Weight { get; set; }

    }
}
