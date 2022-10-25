using Fuel_App.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Fuel_App.Services
{
    public class FSOwnerService : IFSOwnerService
    {
        private readonly IMongoCollection<FSOwner> _fsOwner;
        public FSOwnerService(IFuelStationDbSettings fuelStationDbSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(fuelStationDbSettings.DatabaseName);
            _fsOwner = database.GetCollection<FSOwner>(fuelStationDbSettings.FuelStationDataCollectionName);
        }

        public FSOwner GetFuelStationDetailById(string stationId)
        {
            var result = _fsOwner.Find(fsowner => fsowner.stationId == stationId ).FirstOrDefault();

            if(result.fuelType == "Petrol")
            {
                if (result.fuelArrivalTime != null && result.fuelFinishTime == null)
                {
                    GetFuelStationDetailsList();
                }
            }
            return result;
        }

        public List<FSOwner> GetFuelStationDetailsList()
        {
            return _fsOwner.Find(fsowner => true).ToList();
        }

        public FSOwner AddStation(FSOwner fSOwner)
        {
            _fsOwner.InsertOne(fSOwner);

            return fSOwner;
        }
    }
}
