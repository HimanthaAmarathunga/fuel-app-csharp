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
    public interface IFuelStationDbSettings
    {
        string CustomerDataCollectionName { get; set; }
        string FuelStationDataCollectionName { get; set; }
        string FuelTypeDataCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
