using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Application
{
    public class PhoneApplication : Application<ContactPhone>, IPhoneApplication
    {
        private readonly IPhoneService _services;

        public PhoneApplication(IPhoneService services) : base(services)
        {
            _services = services;
        }
    }
}
