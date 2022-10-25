using Fuel_App.Models;
using Fuel_App.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fuel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FSOwnerController : ControllerBase
    {
        private readonly IFSOwnerService fSOwnerService;

        public FSOwnerController(IFSOwnerService fSOwnerService)
        {
            this.fSOwnerService = fSOwnerService;
        }

        /// <summary>
        /// Get List of Fuel Station Details List"
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFuelStationDetailsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<FSOwner>> GetFuelStationDetailsList()
        {
            return fSOwnerService.GetFuelStationDetailsList();
        }

        /// <summary>
        /// Get Fuel Station Detail by Id
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns></returns>
        [HttpGet("{id}/GetFuelStationDetailById")]
        public ActionResult<FSOwner> GetFuelStationDetailById(string id)
        {
            var fsowner = fSOwnerService.GetFuelStationDetailById(id);
            if (fsowner == null)
            {
                return NotFound($"Fuel status not found");
            }

            return fsowner;
        }


        // PUT api/<FSOwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        [HttpPost("AddStation")]
        public ActionResult<FSOwner> AddStation([FromBody] FSOwner fsowner)
        {
            fSOwnerService.AddStation(fsowner);

            return CreatedAtAction(nameof(GetFuelStationDetailById), new { id = fsowner.stationId }, fsowner);
        }

    }
}
