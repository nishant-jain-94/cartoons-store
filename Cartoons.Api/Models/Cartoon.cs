using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Cartoons.Models
{
    public class Cartoon
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty(PropertyName="id")]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName="imageUrl")]
        public string ImageUrl { get; set; }
        
        [JsonProperty(PropertyName="tags")]
        public string[] Tags { get; set; }
    }
}