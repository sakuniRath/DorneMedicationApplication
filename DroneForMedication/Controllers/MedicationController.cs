using DorneForMedication.BusinessLayer.Iservices;
using DorneForMedication.BusinessLayer.Models;
using DorneForMedication.BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DroneForMedication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        readonly IMedicationService _medicationService;

        public MedicationController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet]
        [ActionName("GetMedicationDetails")]
        public async Task<List<MedicationModel>> GetMedicationDetails()
        {

            List<MedicationModel> medications = await _medicationService.GetMedicationDetails();
            return medications;
        }
        [HttpPost]
        [ActionName("RegisterMedication")]
        public async Task<IActionResult> RegisterMedication(MedicationModel medicationModel)//Medication registration function
        {

            bool status = await _medicationService.RegisterNewMedication(medicationModel);
            if (!status)
                return BadRequest(new { message = "Unable to Register Medication" });
            return Ok(status);
        }
        [HttpPost]
        [ActionName("RegisterMedicationForDorne")]
        public async Task<IActionResult> ResigterMedicationForDorne(int[] dornMedicationModel)
        {
            bool status = await _medicationService.ResigterMedicationForDorne(dornMedicationModel);
            if (!status)
                return BadRequest(new { message = "Unable to Register Medication for Dorne" });
            return Ok(status);
        }
        [HttpGet]
        [ActionName("GetMedicationDetailsForGivenDorne")]
        public async Task<List<string>> GetMedicationDetailsForGivenDorne(int dorneId)
        {

            List<string> medications = await _medicationService.GetMedicationDetailsForGivenDorne(dorneId);
            return medications;
        }




    }
}
