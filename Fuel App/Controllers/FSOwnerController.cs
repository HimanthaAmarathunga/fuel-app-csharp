/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using Fuel_App.Models;
using Fuel_App.Services;
using Microsoft.AspNetCore.Mvc;



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
        /// Get List of Fuel Station Details List
        /// </summary>
        /// <returns>
        /// Fuel station list
        /// </returns>
        [HttpGet("GetFuelStationDetailsList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<FSOwner>> GetFuelStationDetailsList()
        {
            return fSOwnerService.GetFuelStationDetailsList();
        }


        /// <summary>
        /// Get Fuel Station Details List Filter by Fuel Types
        /// </summary>
        /// <returns>
        /// List of fuel by fuel type
        /// </returns>
        [HttpGet("{location}/GetFuelStationDetailsListFilterByFuelTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<FSOwner>> GetFuelStationDetailsListFilterByFuelTypes(string location)
        {
            return fSOwnerService.GetFuelStationDetailsListFilterByFuelTypes(location);
        }


        /// <summary>
        /// Get Fuel Station Detail by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Fuel station details
        /// </returns>
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


        /// <summary>
        /// Update Departure Time
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fSOwner"></param>
        /// <returns></returns>
        [HttpPut("{id}/UpdateFuelStatus")]
        public ActionResult UpdateFuelStatus(string id, [FromBody] FSOwner fSOwner)
        {
            var fuelStatus = fSOwnerService.GetFuelStationDetailById(id);

            if (fuelStatus == null)
            {
                return NotFound($"Fuel Status is empty with Id = {id}");
            }

            fSOwnerService.UpdateFuelStatus(id, fSOwner);

            return NoContent();
        }


        /// <summary>
        /// Add Station
        /// </summary>
        /// <param name="fsowner"></param>
        /// <returns>
        /// New station
        /// </returns>
        [HttpPost("AddStation")]
        public ActionResult<FSOwner> AddStation([FromBody] FSOwner fsowner)
        {
            fSOwnerService.AddStation(fsowner);

            return CreatedAtAction(nameof(GetFuelStationDetailById), new { id = fsowner.stationId }, fsowner);
        }

    }
}
