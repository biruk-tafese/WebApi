namespace DriverAppApi.Model;
using MongoDB.Bson.Serialization.Attributes;

     public class Driver
    {
       [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string DriverName { get; set; } = null!;

        public string Team { get; set; } = null!;
        
        
        
        // Add this property to match the 'Number' field in your MongoDB document
        public int Number { get; set; }
    }
