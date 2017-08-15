using System.Collections.Generic;
using NHibernate;
using System;
using System.Windows;

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
            catch(Exception ex)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
                throw;
            }
        }

        public IList<T> FindAll()
        {
            try
            {
                return NhibernateSessionManager.OpenSession().CreateCriteria(typeof(T)).List<T>();
            }
            catch(Exception ex)
            {
                ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
                throw;
            }
        }

        public void SaveOrUpdate(T entity)
        {
            using (ITransaction transaction = NhibernateSessionManager.OpenSession().BeginTransaction())
            {
                try
                {
                    var session = NhibernateSessionManager.OpenSession();
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                    session.Flush();
                    session.Clear();
                    //return entity;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
                }
            }
        }

        public void Delete(T entity)
        {
            using (ITransaction transaction = NhibernateSessionManager.OpenSession().BeginTransaction())
            {
                try
                {
                    var session = NhibernateSessionManager.OpenSession();
                    session.Delete(entity);
                    transaction.Commit();
                    session.Flush();
                    session.Clear();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    ((MainWindow)Application.Current.MainWindow).AddExceptionTextMsg(ex.ToString());
                }
            }
        }
    }
}
