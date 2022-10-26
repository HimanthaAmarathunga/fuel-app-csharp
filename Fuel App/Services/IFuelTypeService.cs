/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface IFuelTypeService
    {

        /// <summary>
        /// Get Fuel Types List
        /// </summary>
        List<FuelType> GetFuelTypesList();

        /// <summary>
        /// Get Fuel Type by Id
        /// </summary>
        /// <param name="fuelTypeID"></param>
        FuelType GetFuelTypeById(string fuelTypeID);


        /// <summary>
        /// Add Fuel Type
        /// </summary>
        /// <param name="fuelType"></param>
        FuelType AddFuelType(FuelType fuelType);


        /// <summary>
        /// Update Fuel Type Times
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="fuelType"></param>
        void UpdateFuelTypeTimes(string Id, FuelType fuelType);
    }
}
