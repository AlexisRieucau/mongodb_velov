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
    public class QuartierService
    {
        private readonly IMongoCollection<Quartier> _quartier;

        public QuartierService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("VelovDb"));
            var database = client.GetDatabase("VelovDb");
            _quartier = database.GetCollection<Quartier>("Quartiers");
        }

        public List<Quartier> Get()
        {
            return _quartier.Find(quartier => true).ToList();
        }

        public Quartier Get(string id)
        {
            return _quartier.Find<Quartier>(quartier => quartier.Id == id).FirstOrDefault();
        }

        public Quartier Create(Quartier quartier)
        {
            _quartier.InsertOne(quartier);
            return quartier;
        }

        public void Update(string id, Quartier quartierIn)
        {
            _quartier.ReplaceOne(quartier => quartier.Id == id, quartierIn);
        }

        public void Remove(Quartier quartierIn)
        {
            _quartier.DeleteOne(quartier => quartier.Id == quartierIn.Id);
        }

        public void Remove(string id)
        {
            _quartier.DeleteOne(quartier => quartier.Id == id);
        }
    }
}
