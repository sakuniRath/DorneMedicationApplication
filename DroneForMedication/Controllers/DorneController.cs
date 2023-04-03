using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DorneForMedication.BusinessLayer.Iservices;
using DorneForMedication.BusinessLayer.Models;
using DorneForMedication.BusinessLayer.Services;
using System.Threading.Tasks;

namespace DroneForMedication.Controllers
{
    
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DorneController : ControllerBase
    {
        readonly IDorneService _dornService;

        public DorneController(IDorneService dornService)
        {
            _dornService = dornService;
        }

        [HttpGet]
        [ActionName("GetAllDorneDetails")]
        public async Task<List<DorneModel>> GetDorneDetails()
        {

            List<DorneModel> dornes = await _dornService.GetDorneDetails();
            return dornes;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterDorne(DorneModel dorneModel)//Dorne registration function
        {

            bool status = await _dornService.RegisterNewDorne(dorneModel);
            if (!status)
                return BadRequest(new { message = "Unable to Register Dorne" });
            return Ok(status);
        }

        
        [HttpGet]
        [ActionName("GetAllIdealDorneDetails")]
        public async Task<List<DorneModel>> GetIdleDorneDetails()
        {

            List<DorneModel> dornes = await _dornService.GetIdleDorneDetails();
            return dornes;
        }


    }
}
