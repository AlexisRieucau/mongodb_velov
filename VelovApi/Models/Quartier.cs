using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VelovApi.Models
{
    public class Quartier
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("properties")]
        public QuartierProperties properties { get; set; }

        [BsonElement("geometry")]
        public QuartierGeometry geometry { get; set; }

    }

    public class QuartierProperties
    {
        [BsonElement("nom")]
        public string nom { get; set; }

        [BsonElement("theme")]
        public string theme { get; set; }

        [BsonElement("soustheme")]
        public string sousTheme { get; set; }

        [BsonElement("identifiant")]
        public string identifiant { get; set; }

        [BsonElement("idexterne")]
        public string idExterne { get; set; }

        [BsonElement("siret")]
        public string siret { get; set; }

        [BsonElement("datecreation")]
        public string date_creat { get; set; }

        [BsonElement("gid")]
        public string gid { get; set; }
    }

    public class QuartierGeometry
    {
        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("coordinates")]
        public double[][][] coordinates { get; set; }
    }
}
