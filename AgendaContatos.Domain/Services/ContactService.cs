using System;
using System.Linq;
using System.Threading.Tasks;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Domain.Services
{
    public class ContactService : Service<Contact>, IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task AddAsync(Contact entity)
        {
            try
            {
                beforeAdd(entity);

                await base.AddAsync(entity);
            }
            catch (InvalidOperationException ex) {

                 throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void beforeAdd(Contact entity) {

            try
            {
                if (string.IsNullOrEmpty(entity.Name.Trim()))
                    throw new InvalidOperationException("Informe o nome contato!");

                if (base.List(c => c.Name.Equals(entity.Name.Trim())).Result.ToList().Count > 0)
                    throw new InvalidOperationException("Este contato já existe!");

            }
            catch (InvalidOperationException ex) {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
