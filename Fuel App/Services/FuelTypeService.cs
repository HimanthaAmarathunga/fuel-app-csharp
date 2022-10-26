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

        public List<FuelType> GetFuelTypesList()
        {
            return _fuelType.Find(fuelType => true).ToList();
        }

        public FuelType GetFuelTypeById(string fuelTypeId)
        {
            return _fuelType.Find(fuelType => fuelType.fuelTypeId == fuelTypeId).FirstOrDefault();
        }

        public FuelType AddFuelType(FuelType fuelType)
        {
            _fuelType.InsertOne(fuelType);

            return fuelType;
        }
    }
}
