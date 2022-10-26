using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface IFSOwnerService
    {
        /// <summary>
        /// Get Fuel Station Details List
        /// </summary>
        /// <returns></returns>
        List<FSOwner> GetFuelStationDetailsList();


        /// <summary>
        /// Get Fuel Station Details List Filter by Fuel Types
        /// </summary>
        /// <returns></returns>
        List<FSOwner> GetFuelStationDetailsListFilterByFuelTypes(string location);


        /// <summary>
        /// Get Fuel Station Detail by Id
        /// </summary>
        /// <param name="stationId"></param>
        /// <returns></returns>
        FSOwner GetFuelStationDetailById(string stationId);


        /// <summary>
        /// Add Fuel Station
        /// </summary>
        /// <param name="fSOwner"></param>
        /// <returns></returns>
        FSOwner AddStation(FSOwner fSOwner);


        /// <summary>
        /// Update Fuel Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fSOwner"></param>
        void UpdateFuelStatus(string id, FSOwner fSOwner);
    }
}
