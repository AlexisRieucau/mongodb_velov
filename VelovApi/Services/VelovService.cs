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
    public class VelovService
    {
        private readonly IMongoCollection<Velov> _velov;

        public VelovService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("VelovDb"));
            var database = client.GetDatabase("VelovDb");
            _velov = database.GetCollection<Velov>("Velov");
        }

        public List<Velov> Get()
        {
            return _velov.Find(velov => true).ToList();
        }

        public Velov Get(string id)
        {
            return _velov.Find<Velov>(velov => velov.Id == id).FirstOrDefault();
        }

        public Velov Create(Velov velov)
        {
            _velov.InsertOne(velov);
            return velov;
        }

        public void Update(string id, Velov velovIn)
        {
            _velov.ReplaceOne(velov => velov.Id == id, velovIn);
        }

        public void Remove(Velov velovIn)
        {
            _velov.DeleteOne(velov => velov.Id == velovIn.Id);
        }

        public void Remove(string id)
        {
            _velov.DeleteOne(velov => velov.Id == id);
        }
    }
}
