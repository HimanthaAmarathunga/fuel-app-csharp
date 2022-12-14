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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fuel_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeService fuelTypeService;
        public FuelTypeController(IFuelTypeService fuelTypeService)
        {
            this.fuelTypeService = fuelTypeService;
        }

        /// <summary>
        /// Get List of Fuel Types
        /// </summary>
        /// <returns>
        /// Fuel type list
        /// </returns>
        [HttpGet("GetFuelTypesList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<FuelType>> GetFuelTypesList()
        {
            return fuelTypeService.GetFuelTypesList();
        }

        /// <summary>
        /// Get Fuel Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Fuel type
        /// </returns>
        [HttpGet("{id}/GetFuelTypeById")]
        public ActionResult<FuelType> GetFuelTypeById(string id)
        {
            var fuelType = fuelTypeService.GetFuelTypeById(id);
            if (fuelType == null)
            {
                return NotFound($"Fuel type with Id = {id} not found");
            }

            return fuelType;
        }


        /// <summary>
        /// Add Fuel Type
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns>
        /// Add fuel type
        /// </returns>
        [HttpPost("AddFuelType")]
        public ActionResult<FuelType> AddFuelType([FromBody] FuelType fuelType)
        {
            fuelTypeService.AddFuelType(fuelType);

            return CreatedAtAction(nameof(GetFuelTypeById), new { id = fuelType.fuelTypeId }, fuelType);
        }


        /// <summary>
        /// Update Fuel Type Times
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fuelType"></param>
        /// <returns>
        /// update fuel type
        /// </returns>
        [HttpPut("{id}/UpdateFuelTypeTimes")]
        public ActionResult UpdateFuelTypeTimes(string id, [FromBody] FuelType fuelType)
        {
            var fuelStatus = fuelTypeService.GetFuelTypeById(id);

            if (fuelStatus == null)
            {
                return NotFound($"Fuel Type is empty with Id = {id}");
            }

            fuelTypeService.UpdateFuelTypeTimes(id, fuelType);

            return NoContent();
        }
    }
}
