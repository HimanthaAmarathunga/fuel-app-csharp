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
    public class FSOwnerService : IFSOwnerService
    {
        private readonly IMongoCollection<FSOwner> _fsOwner;
        public FSOwnerService(IFuelStationDbSettings fuelStationDbSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(fuelStationDbSettings.DatabaseName);
            _fsOwner = database.GetCollection<FSOwner>(fuelStationDbSettings.FuelStationDataCollectionName);
        }


        /// <summary>
        /// Get Fuel Station Details List
        /// </summary>
        /// <returns>
        /// Fuel station list</returns>
        public List<FSOwner> GetFuelStationDetailsList()
        {
            return _fsOwner.Find(fsowner => true).ToList();
        }


        /// <summary>
        /// Get Fuel Station Details List Filter by Fuel Types
        /// </summary>
        /// <param name="location"></param>
        /// <returns>
        /// filter by fuel type
        /// </returns>
        public List<FSOwner> GetFuelStationDetailsListFilterByFuelTypes(string location)
        {
            var fSOwners = _fsOwner.Find(fsowner => true).ToList();

            var fuelStation = fSOwners.Where(fsowner => fsowner.location == location)
                               .FirstOrDefault();

            if (fuelStation.fuelFinishTime == null)
            {
                return fSOwners.Where(c => c.fuelFinishTime == null).ToList(); 
            }

            return null; 
        }


        /// <summary>
        /// Get Fuel Station Detail by Id
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns>
        /// Station by Id
        /// </returns>
        public FSOwner GetFuelStationDetailById(string stationId)
        {
            return _fsOwner.Find(fsowner => fsowner.stationId == stationId).FirstOrDefault();

        }


        /// <summary>
        /// Add Fuel Station
        /// </summary>
        /// <param name="fSOwner"></param>
        /// <returns>
        /// Add station
        /// </returns>
        public FSOwner AddStation(FSOwner fSOwner)
        {
            _fsOwner.InsertOne(fSOwner);

            return fSOwner;
        }


        /// <summary>
        /// Update Fuel Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fSOwner"></param>
        /// <retuns>
        /// Updates the status
        /// </retuns>
        public void UpdateFuelStatus(string id, FSOwner fSOwner)
        {
            var test = _fsOwner.Find(fsowner => fsowner.stationId == id)
                               .FirstOrDefault();
            /*if (test.fuelTypeId == "1")
            {
                var t = _fsOwner.Find(fsowner => fsowner.stationId == id)
                                .FirstOrDefault();
            }
            else if (test.fuelTypeId == "2")
            {

            }
            test.fuelTypeId = fSOwner.fuelTypeId;
            test.fuelArrivalTime = fSOwner.fuelArrivalTime;
            test.fuelFinishTime = fSOwner.fuelFinishTime;*/
            //_fsOwner.UpdateOne(test);

            _fsOwner.ReplaceOne(fSOwner => fSOwner.stationId == id, fSOwner);
        }

    }
}
