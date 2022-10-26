using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Fuel_App.Models
{
    [BsonIgnoreExtraElements]
    public class FuelType
    {
        [BsonId]
        public string fuelTypeId { get; set; }
        public string fuelTypeName { get; set; }
    }
}
