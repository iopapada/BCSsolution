using System.Collections.Generic;

namespace BCSsolution.dbManager
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        IList<T> FindAll();
        void SaveOrUpdate(T entity);
        void Delete(T entity);
    }
}