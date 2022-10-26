using Fuel_App.Models;
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
            return _fsOwner.Find(fsowner => fsowner.stationId == stationId).FirstOrDefault();

        }

        public List<FSOwner> GetFuelStationDetailsList()
        {
            return _fsOwner.Find(fsowner => true).ToList();

            //if (result.fuelTypeId = 1)
            //{
            //    if (result.fuelArrivalTime != null && result.fuelFinishTime == null)
            //    {
            //        GetFuelStationDetailsList();
            //    }
            //    else if (result.fuelFinishTime != null)
            //    {
            //        var status = "Fuel status not found";
            //        return status;
            //    }
            //}
            //if (result.fuelType == "Diesel")
            //{
            //    if (result.fuelArrivalTime != null && result.fuelFinishTime == null)
            //    {
            //        GetFuelStationDetailsList();
            //    }
            //}
            //return result;
        }

        public FSOwner AddStation(FSOwner fSOwner)
        {
            _fsOwner.InsertOne(fSOwner);

            return fSOwner;
        }

        public void UpdateFuelStatus(string id, FSOwner fSOwner)
        {
            var test = _fsOwner.Find(fsowner => fsowner.stationId == id)
                               .FirstOrDefault();

            //GetFuelStationDetailById(id);

            test.fuelType = fSOwner.fuelType;
            test.fuelArrivalTime = fSOwner.fuelArrivalTime;
            test.fuelFinishTime = fSOwner.fuelFinishTime;
            //_fsOwner.UpdateOne(test);

            _fsOwner.ReplaceOne(fSOwner => fSOwner.stationId == id, fSOwner);

           // return test; 
        }

    }
}
