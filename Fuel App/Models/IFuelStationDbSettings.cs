namespace Fuel_App.Models
{
    public interface IFuelStationDbSettings
    {
        string CustomerDataCollectionName { get; set; }
        string FuelStationDataCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
