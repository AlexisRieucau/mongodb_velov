using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VelovApi.Models
{
    public class Velov
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("properties")]
        public VelovProperties properties { get; set; }

        [BsonElement("geometry")]
        public VelovGeometry geometry { get; set; }
    }

    public class VelovProperties
    {
        [BsonElement("number")]
        public int number { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("address")]
        public string address { get; set; }

        [BsonElement("address2")]
        public string address2 { get; set; }

        [BsonElement("commune")]
        public string commune { get; set; }

        [BsonElement("nmarrond")]
        public int nmArrond { get; set; }

        [BsonElement("bonus")]
        public string bonus { get; set; }

        [BsonElement("pole")]
        public string pole { get; set; }

        [BsonElement("lat")]
        public double lattitude { get; set; }

        [BsonElement("lng")]
        public double longitude { get; set; }

        [BsonElement("bike_stands")]
        public int bike_stands { get; set; }

        [BsonElement("status")]
        public string status { get; set; }

        [BsonElement("available_bike_stands")]
        public int available_bike_stands { get; set; }

        [BsonElement("available_bikes")]
        public int available_bikes { get; set; }

        [BsonElement("availabilitycode")]
        public int availabilitycode { get; set; }

        [BsonElement("availability")]
        public string availability { get; set; }

        [BsonElement("banking")]
        public int banking { get; set; }

        [BsonElement("gid")]
        public int gid { get; set; }

        //[BsonDateTimeOptions]
        [BsonElement("last_update")]
        public string last_update { get; set; }

        [BsonElement("last_update_fme")]
        public string last_update_fme { get; set; }

        [BsonElement("code_insee")]
        public string code_insee { get; set; }

        [BsonElement("langue")]
        public string langue { get; set; }

        [BsonElement("etat")]
        public string etat { get; set; }

        [BsonElement("nature")]
        public string nature { get; set; }

        [BsonElement("titre")]
        public string titre { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("startdate")]
        public string startDate { get; set; }

        [BsonElement("enddate")]
        public string endDate { get; set; }
    }

    public class VelovGeometry
    {
        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("coordinates")]
        public double[] coordinates { get; set; }
    }
}
