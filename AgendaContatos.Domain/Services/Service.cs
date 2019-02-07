using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Domain.Services
{
    public class Service<T> : IService<T>, IDisposable where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual async Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter)
        {
            return await _repository.List(filter);
        }

        public virtual async Task<IEnumerable<T>> List()
        {
            return await _repository.List();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
