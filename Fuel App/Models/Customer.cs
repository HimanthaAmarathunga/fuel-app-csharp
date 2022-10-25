using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Fuel_App.Models
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string ArrivalTime { get; set; } = DateTime.Now.ToString("t");
        public string? DepartureTime { get; set; } = DateTime.Now.ToString("t");
    }
}
