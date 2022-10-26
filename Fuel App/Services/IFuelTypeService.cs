using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface IFuelTypeService
    {

        /// <summary>
        /// Get Fuel Types List
        /// </summary>
        /// <returns></returns>
        List<FuelType> GetFuelTypesList();

        /// <summary>
        /// Get Fuel Type by Id
        /// </summary>
        /// <param name="fuelTypeID"></param>
        /// <returns></returns>
        FuelType GetFuelTypeById(string fuelTypeID);


        /// <summary>
        /// Add Fuel Type
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns></returns>
        FuelType AddFuelType(FuelType fuelType);


        /// <summary>
        /// Update Fuel Type Times
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fuelType"></param>
        void UpdateFuelTypeTimes(string Id, FuelType fuelType);
    }
}
