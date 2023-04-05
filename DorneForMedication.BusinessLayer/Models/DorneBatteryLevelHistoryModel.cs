using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DorneForMedication.BusinessLayer.Models
{
    public class DorneBatteryLevelHistoryModel
    {
        public int DorneBatteryLevelHistoryId { get; set; }
        public int DorneId { get; set; }
        public int BatteryCapacity { get; set; }
        
        public DateTime CurrentDate { get; set; }
    }
}
