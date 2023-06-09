﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public bool IsTaskLevel { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
    }
}
    
