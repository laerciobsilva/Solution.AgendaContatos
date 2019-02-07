using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Application
{
    public class ContactApplication : Application<Contact>, IContactApplication
    {
        private readonly IContactService _services;

        public ContactApplication(IContactService services) : base(services)
        {
            _services = services;
        }
    }
}
