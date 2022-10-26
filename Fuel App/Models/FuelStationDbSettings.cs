/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
namespace Fuel_App.Models
{
    public class FuelStationDbSettings : IFuelStationDbSettings
    {
        public string CustomerDataCollectionName { get; set; } = String.Empty;
        public string FuelStationDataCollectionName { get; set; } = String.Empty;
        public string FuelTypeDataCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
