using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MatchCityNameApi.DataAccess.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string Id { get; set; }
        public string geoname_id { get; set; } = String.Empty;
        public string name { get; set; } = String.Empty;
        public string ascii_name { get; set; } = String.Empty;
        public string country_code { get; set; } = String.Empty;
        public string cou_name_en { get; set; } = String.Empty;
        public string country_code_2 { get; set; } = String.Empty;
        public int population { get; set; }
        public int dem { get; set; } 
        public string timezone { get; set; } = String.Empty;
        public string label_en { get; set; } = String.Empty;
        public double lon { get; set; }
        public double lat { get; set; }

    }
}
