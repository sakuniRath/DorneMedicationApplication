using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.Model
{
    public class Medication
    {
        
        public int MedicationId { get; set; }
        [Required]
        public string MedicationName { get; set; }
        [Required]
        public string Code { get; set; }

        [Required]  
        public int Weight { get; set; } 
        public string ImageURL { get; set; }

        public virtual ICollection<DorneMedication> DorneMedications { get; set; }
    }
}
