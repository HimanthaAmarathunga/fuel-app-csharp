/*
 * Fuel App
 * 
 * EAD ASSIGNMENT - 2022 
 * Group - 64
 * IT19040172 Perera T.W.I.V <it19040172@my.sliit.lk>
 * IT19035086 Amarathunga A.A.H.S.B. <it19035086@my.sliit.lk>
 */
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Fuel_App.Models
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        //Customer Model
        [BsonId]
        public string Id { get; set; }
        public string NIC { get; set; }
        public string FirstName { get; set; }
        public string ArrivalTime { get; set; } = DateTime.Now.ToString("t");
        public string? DepartureTime { get; set; } 
    }
}
