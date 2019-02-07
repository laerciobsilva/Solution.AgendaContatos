using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Application
{
    public class MailApplication : Application<ContactMail>, IMailApplication
    {
        private readonly IMailService _services;

        public MailApplication(IMailService services) : base(services)
        {
            _services = services;
        }
    }
}
