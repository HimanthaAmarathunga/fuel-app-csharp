using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Fuel_App.Models
{
    [BsonIgnoreExtraElements]
    public class FSOwner
    {
        [BsonId]
        public string stationId { get; set; }
        public string? location { get; set; }
        public string fuelTypeId { get; set; }
        public string fuelArrivalTime { get; set; } = DateTime.Now.ToString("t");
        public string? fuelFinishTime { get; set; } = DateTime.Now.ToString("t");

        ///public virtual FuelType FuelType { get; set; }
    }
}
