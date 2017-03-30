using System;
using System.Collections.Generic;
using NHibernate;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSsolution.dbManager
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public T FindById(int id)
        {
            try
            {
                return NhibernateSessionManager.OpenSession().Load<T>(id);
            }
            catch
            {
                throw;
            }
        }

        public IList<T> FindAll()
        {
            try
            {
                return NhibernateSessionManager.OpenSession().CreateCriteria(typeof(T)).List<T>();
            }
            catch
            {
                throw;
            }
        }

        public T SaveOrUpdate(T entity)
        {
            using (ITransaction transaction = NhibernateSessionManager.OpenSession().BeginTransaction())
            {
                try
                {
                    NhibernateSessionManager.OpenSession().SaveOrUpdate(entity);
                    transaction.Commit();
                    return entity;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Delete(T entity)
        {
            using (ITransaction transaction = NhibernateSessionManager.OpenSession().BeginTransaction())
            {
                try
                {
                    NhibernateSessionManager.OpenSession().Delete(entity);
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
