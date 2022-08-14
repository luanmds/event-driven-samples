using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UrlShortened.Api.Domain.Entities
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}