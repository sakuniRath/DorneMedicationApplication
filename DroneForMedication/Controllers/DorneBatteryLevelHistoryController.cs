using DorneForMedication.BusinessLayer.Iservices;
using DorneForMedication.BusinessLayer.Models;
using DorneForMedication.BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DroneForMedication.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DorneBatteryLevelHistoryController : ControllerBase
    {
        readonly TimelyTrigger timelyTrigger=new TimelyTrigger(5000);

        public DorneBatteryLevelHistoryController()
        {
            
        }

        [HttpGet]
        [ActionName("GetAllDorneBatteryHistoryDetails")]
        public async Task<List<DorneBatteryLevelHistoryModel>> GetAllHistoryDorneDetails()
        {

            List<DorneBatteryLevelHistoryModel> historyDetails =  timelyTrigger.GetAllHistoryDorneDetails();
            return historyDetails;
        }
    }
}
