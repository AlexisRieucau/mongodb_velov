using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VelovApi.Models
{
    public class Tourisme
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("properties")]
        public TourismeProperties properties { get; set; }

        [BsonElement("geometry")]
        public TourismeGeometry geometry { get; set; }
    }

    public class TourismeProperties
    {
        [BsonElement("id")]
        public string idid { get; set; }

        [BsonElement("id_sitra1")]
        public string id_sitra1 { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("type_detail")]
        public string type_detail { get; set; }

        [BsonElement("nom")]
        public string nom { get; set; }

        [BsonElement("adresse")]
        public string adresse { get; set; }

        [BsonElement("codepostal")]
        public string codePostal { get; set; }

        [BsonElement("commune")]
        public string commune { get; set; }

        [BsonElement("telephone")]
        public string telephone { get; set; }

        [BsonElement("fax")]
        public string fax { get; set; }

        [BsonElement("telephonefax")]
        public string telephoneFax { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("siteweb")]
        public string website { get; set; }

        [BsonElement("facebook")]
        public string facebook { get; set; }

        [BsonElement("classement")]
        public string classement { get; set; }

        [BsonElement("ouverture")]
        public string ouverture { get; set; }

        [BsonElement("tarifsenclair")]
        public string taris_en_clair { get; set; }

        [BsonElement("tarifsmin")]
        public string tarifs_min { get; set; }

        [BsonElement("tarifsmax")]
        public string tarifs_max { get; set; }

        [BsonElement("producteur")]
        public string producteur { get; set; }

        [BsonElement("gid")]
        public string gid { get; set; }

        [BsonElement("date_creation")]
        public string date_creat { get; set; }

        [BsonElement("last_update")]
        public string last_update { get; set; }

        [BsonElement("last_update_fme")]
        public string last_update_fme { get; set; }
    }

    public class TourismeGeometry
    {
        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("coordinates")]
        public double[] coordinates { get; set; }
    }
}
