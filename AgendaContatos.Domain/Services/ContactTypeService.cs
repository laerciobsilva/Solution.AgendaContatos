using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Domain.Services
{
    public class ContactTypeService : Service<ContactType>, IContactTypeService
    {
        private readonly IContactTypeRepository _repository;

        public ContactTypeService(IContactTypeRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
