﻿using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Repositories;

namespace AgendaContatos.Repository.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {

    }
}
