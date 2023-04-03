using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.Model
{
    public class Dorne
    {
        
        public int DorneId { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int WeightLimit { get; set; }
        [Required]
        public int BatteryCapacity { get; set; }
        [Required]
        public string Sate { get; set; }

        public virtual ICollection<DorneMedication> DorneMedications { get; set; }

    }
}
