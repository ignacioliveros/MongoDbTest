using Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MongoDbContext<T>where T: class
    {
        IMongoDatabase Database;
        private string collectionName;

        public MongoDbContext()
        {
            var MdClient = new MongoClient("mongodb://localhost");
            this.collectionName = typeof(T).Name;
            Database = MdClient.GetDatabase("Report");
        }

        public IMongoCollection<T> GetContext
        {
            get
            {
                return Database.GetCollection<T>(collectionName);
            }
        }

       
    }
}
