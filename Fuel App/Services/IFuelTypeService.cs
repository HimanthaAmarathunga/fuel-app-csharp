using Fuel_App.Models;

namespace Fuel_App.Services
{
    public interface IFuelTypeService
    {
        List<FuelType> GetFuelTypesList();

        FuelType GetFuelTypeById(string fuelTypeID);

        FuelType AddFuelType(FuelType fuelType);
    }
}
