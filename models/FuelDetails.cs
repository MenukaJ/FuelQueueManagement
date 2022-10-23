using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FuelQueueManagement.models
{
    [BsonIgnoreExtraElements]
    public class FuelDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("fuel_station")]
        public FuelStation fuelStation { get; set; }

        [BsonElement("type")]
        public string Type { get; set; } = String.Empty;

        [BsonElement("arrival_time")]
        public string ArrivalTime { get; set; } = String.Empty;

        [BsonElement("finish_time")]
        public string FinishTime { get; set; } = String.Empty;

        [BsonElement("date")]
        public string Date { get; set; } = String.Empty;

        [BsonElement("status")]
        public string Status { get; set; } = String.Empty;
    }
}


