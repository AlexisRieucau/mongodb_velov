using System;
using System.Collections.Generic;
using System.Linq;
using VelovApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VelovApi.Services
{
    public class TourismeService
    {
        private readonly IMongoCollection<Tourisme> _tourisme;

        public TourismeService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("VelovDb"));
            var database = client.GetDatabase("VelovDb");
            _tourisme = database.GetCollection<Tourisme>("Tourisme");
        }

        public List<Tourisme> Get()
        {
            return _tourisme.Find(tourisme => true).ToList();
        }

        public Tourisme Get(string id)
        {
            return _tourisme.Find<Tourisme>(tourisme => tourisme.Id == id).FirstOrDefault();
        }

        public Tourisme Create(Tourisme tourisme)
        {
            _tourisme.InsertOne(tourisme);
            return tourisme;
        }

        public void Update(string id, Tourisme tourismeIn)
        {
            _tourisme.ReplaceOne(tourisme => tourisme.Id == id, tourismeIn);
        }

        public void Remove(Tourisme tourismeIn)
        {
            _tourisme.DeleteOne(tourisme => tourisme.Id == tourismeIn.Id);
        }

        public void Remove(string id)
        {
            _tourisme.DeleteOne(tourisme => tourisme.Id == id);
        }
    }
}
