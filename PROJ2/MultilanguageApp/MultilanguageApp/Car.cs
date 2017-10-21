using System.Collections.Generic;
using FinderLib;
using FinderLib.AsRs.Ztp.Elements;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultilanguageApp
{
    public class Car
    {
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int NumberOfSeats { get; set; }

        public int MaxSpeed { get; set; }

        public ICollection<LanguageElement> Descriptions { get; set; }
    }
}