namespace Fuel_App.Models
{
    public class FuelStationDbSettings : IFuelStationDbSettings
    {
        public string CustomerDataCollectionName { get; set; } = String.Empty;
        public string FuelStationDataCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
