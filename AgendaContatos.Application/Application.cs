using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AgendaContatos.Application
{
    public class Application<T> : IApplication<T>, IDisposable where T : class
    {
        private readonly IService<T> _services;

        public Application(IService<T> services)
        {
            _services = services;
        }

        public async Task AddAsync(T entity)
        {
            await _services.AddAsync(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<T> GetAsync(int id)
        {
            return await _services.GetAsync(id);
        }

        public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> filter)
        {
            return await _services.List(filter);
        }

        public async Task<IEnumerable<T>> List()
        {
            return await _services.List();
        }

        public async Task RemoveAsync(T entity)
        {
            await _services.RemoveAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _services.UpdateAsync(entity);
        }
    }
}
