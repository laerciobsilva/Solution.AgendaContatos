using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Domain.Interfaces.Services;

namespace AgendaContatos.Domain.Services
{
    public class MailService : Service<ContactMail>, IMailService
    {
        private readonly IMailRepository _repository;

        public MailService(IMailRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
