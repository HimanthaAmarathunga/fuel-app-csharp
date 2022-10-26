/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using Fuel_App.Models;
using MongoDB.Driver;

namespace Fuel_App.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IMongoCollection<FuelType> _fuelType;

        public FuelTypeService(IFuelStationDbSettings fuelStationDbSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(fuelStationDbSettings.DatabaseName);
            _fuelType = database.GetCollection<FuelType>(fuelStationDbSettings.FuelTypeDataCollectionName);
        }

        /// <summary>
        /// Get Fuel Types List
        /// </summary>
        /// <returns>
        /// Fuel type List
        /// </returns>
        public List<FuelType> GetFuelTypesList()
        {
            return _fuelType.Find(fuelType => true).ToList();
        }


        /// <summary>
        /// Get Fuel Type by Id
        /// </summary>
        /// <param name="fuelTypeId"></param>
        /// <returns>
        /// Fuel type
        /// </returns>
        public FuelType GetFuelTypeById(string fuelTypeId)
        {
            return _fuelType.Find(fuelType => fuelType.fuelTypeId == fuelTypeId).FirstOrDefault();
        }


        /// <summary>
        /// Add Fuel Type
        /// </summary>
        /// <param name="fuelType"></param>
        /// <returns>
        /// Add Fuel type
        /// </returns>
        public FuelType AddFuelType(FuelType fuelType)
        {
            _fuelType.InsertOne(fuelType);

            return fuelType;
        }


        /// <summary>
        /// Update Fuel Type Times
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fuelType"></param>
        /// <returns>
        /// Update fuel type
        /// </returns>
        public void UpdateFuelTypeTimes(string id, FuelType fuelType)
        {
            var test = _fuelType.Find(fuelType => fuelType.fuelTypeId == id)
                               .FirstOrDefault();

            test.fuelArrivalTime = DateTime.Now.ToString("t");
            test.fuelFinishTime = DateTime.Now.ToString("t");
        }
    }
}
