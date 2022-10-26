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
    public interface IFSOwnerService
    {
        /// <summary>
        /// Get Fuel Station Details List
        /// </summary>
        List<FSOwner> GetFuelStationDetailsList();


        /// <summary>
        /// Get Fuel Station Details List Filter by Fuel Types
        /// </summary>
        List<FSOwner> GetFuelStationDetailsListFilterByFuelTypes(string location);


        /// <summary>
        /// Get Fuel Station Detail by Id
        /// </summary>
        /// <param name="stationId"></param>
        FSOwner GetFuelStationDetailById(string stationId);


        /// <summary>
        /// Add Fuel Station
        /// </summary>
        /// <param name="fSOwner"></param>
        FSOwner AddStation(FSOwner fSOwner);


        /// <summary>
        /// Update Fuel Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fSOwner"></param>
        void UpdateFuelStatus(string id, FSOwner fSOwner);
    }
}
