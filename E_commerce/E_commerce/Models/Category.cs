using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace E_commerce.Models
{
    [BsonIgnoreExtraElements]

    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ?Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        public int Price = 0;
        public string Description { get; set; } = null!;

    }
}