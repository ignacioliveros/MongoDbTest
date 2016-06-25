using System.Collections.Generic;

namespace Domain.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void AddOne(T entity);
        void Delete(string Id);
        List<T> GetAll();
        T GetById(string Id);
        void UpDate(T entity, string Id);
    }
}