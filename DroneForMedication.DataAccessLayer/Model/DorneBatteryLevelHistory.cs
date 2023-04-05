using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneForMedication.DataAccessLayer.Model
{
    public class DorneBatteryLevelHistory
    {
        
        public int DorneBatteryLevelHistoryId { get; set; }
        public int DorneId { get; set; }
        [Required]
        public int BatteryCapacity { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
    }
}
