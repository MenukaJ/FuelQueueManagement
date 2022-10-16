using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FuelQueueManagement.models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("first_name")]
        public string FistName { get; set; }  = String.Empty;

        [BsonElement("last_name")]
        public string LastName { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("contact_no")]
        public string ContactNo { get; set; } = String.Empty;

        [BsonElement("nic")]
        public string Nic { get; set; } = String.Empty;

        [BsonElement("address_line_1")]
        public string AddressLine1 { get; set; } = String.Empty;

        [BsonElement("address_line_2")]
        public string AddressLine2 { get; set; }

        [BsonElement("address_line_3")]
        public string AddressLine3 { get; set; }

        [BsonElement("role")]
        public String Role { get; set; } = String.Empty;

        [BsonElement("vehicle_no")]
        public string VehicleNo { get; set; } = String.Empty;

        [BsonElement("vehicle_type")]
        public string VehicleType { get; set; } = String.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;
    }
}
