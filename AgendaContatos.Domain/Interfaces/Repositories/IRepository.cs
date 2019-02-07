using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaContatos.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> List();

        Task<T> GetAsync(int id);
    }
}
