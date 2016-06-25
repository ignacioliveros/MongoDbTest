using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T :class
    {
        protected MongoDbContext<T> context;

        public BaseRepository(MongoDbContext<T> Context)
        {
            this.context = Context;
        }

        public T GetById(string Id)
        {
            var filter = new BsonDocument{ { "_id", Id } };

            return context.GetContext.Find(filter).FirstOrDefault();
        }

        /// <summary>
        ///  Este Metodo reemplaza el objeto por uno nuevo   
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="Id"></param>
        public void UpDate(T entity, string Id)
        {
            var filter = new BsonDocument { { "_id", Id } };

            context.GetContext.FindOneAndReplace(filter, entity);
        }

        public List<T> GetAll()
        {            
            return context.GetContext.Find(_ => true).ToList();
        }

        public void AddOne(T entity)
        {
            context.GetContext.InsertOne(entity);
        }

        public void Delete(string Id)
        {
            var filter = new BsonDocument { { "_id", Id } };
            context.GetContext.DeleteOne(filter);
        }


    }
}
