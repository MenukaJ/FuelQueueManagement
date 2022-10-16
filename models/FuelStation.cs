using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuelQueueManagement.models
{
    [BsonIgnoreExtraElements]
    public class FuelStation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("owner")]
        public User Owner { get; set; }


        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;


        [BsonElement("contact_no")]
        public string ContactNo { get; set; } = String.Empty;

        [BsonElement("address_line_1")]
        public string AddressLine1 { get; set; } = String.Empty;

        [BsonElement("address_line_2")]
        public string AddressLine2 { get; set; }

        [BsonElement("address_line_3")]
        public string AddressLine3 { get; set; }
    }
}
