using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Repository.Helpers;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaContatos.Repository.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        ISession session;

        ITransaction transaction;


        public Repository()
        {
            session = InMemorySessionFactory.OpenSession();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                BeginTransaction();

                await session.SaveAsync(entity);
                await session.FlushAsync();
                CommitTransaction();

                CloseSession();
            }
            catch (Exception ex)
            {
                RollbackTransaction();

                throw ex.InnerException;
            }


        }

        public void Dispose()
        {
            if (transaction != null)
            {
                CommitTransaction();
            }
            if (session != null)
            {
                session.Flush();
                CloseSession();
            }


            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter)
        {
            return await session.Query<T>().Where(filter).ToListAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                BeginTransaction();

                await session.DeleteAsync(entity);
                
                CommitTransaction();

            }
            catch (Exception ex)
            {
                RollbackTransaction();

                throw ex.InnerException;
            }


        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                BeginTransaction();

                await session.SaveOrUpdateAsync(entity);                

                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();

                throw ex.InnerException;
            }

        }

        private void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void CommitTransaction()
        {

            transaction.Commit();
            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }
        private void CloseTransaction()
        {
            transaction.Dispose();
            transaction = null;
        }

        private void CloseSession()
        {
            session.Close();
            session.Dispose();
            session = null;
        }

        public async Task<T> GetAsync(int id)
        {
            return await session.GetAsync<T>(id);
        }

        public async Task<IEnumerable<T>> List()
        {
            return await session.Query<T>().ToListAsync();
        }
    }
}
