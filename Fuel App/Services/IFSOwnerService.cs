using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface IFSOwnerService
    {
        List<FSOwner> GetFuelStationDetailsList();

        FSOwner GetFuelStationDetailById(string stationId);
        FSOwner AddStation(FSOwner fSOwner);
    }
}
