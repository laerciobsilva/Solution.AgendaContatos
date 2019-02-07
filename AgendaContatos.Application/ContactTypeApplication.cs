using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Application
{
    public class ContactTypeApplication : Application<ContactType>, IContactTypeApplication
    {
        private readonly IContactTypeService _services;

        public ContactTypeApplication(IContactTypeService services) : base(services)
        {
            _services = services;
        }
    }
}
