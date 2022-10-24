using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FuelQueueManagement.models
{
    [BsonIgnoreExtraElements]
    public class FuelQueue
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("user")]
        public User user { get; set; }

        [BsonElement("fuel_station")]
        public FuelStation fuelStation { get; set; }

        [BsonElement("arrival_time")]
        public string ArrivalTime { get; set; } = String.Empty;

        [BsonElement("departure_time")]
        public string DepartureTime { get; set; } = String.Empty;

        [BsonElement("date")]
        public string Date { get; set; } = String.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;
    }
}