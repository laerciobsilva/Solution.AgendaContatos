using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Interfaces.Repositories;
using AgendaContatos.Domain.Interfaces.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Domain.Services
{
    public class PhoneService : Service<ContactPhone>, IPhoneService
    {
        private readonly IPhoneRepository _repository;

        public PhoneService(IPhoneRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task RemoveAsync(ContactPhone entity)
        {
            try
            {
                BeforeRemove(entity);

                await base.RemoveAsync(entity);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task AddAsync(ContactPhone entity)
        {
            try
            {
                BeforeAdd(entity);

                await base.AddAsync(entity);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task UpdateAsync(ContactPhone entity)
        {
            try
            {
                BeforeAdd(entity);

                await base.UpdateAsync(entity);
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BeforeRemove(ContactPhone entity)
        {

            try
            {
                if (entity.ContactPhoneId <= 0)
                    throw new InvalidOperationException("Informe o telefone para ser removido!");

                if (base.List(c => !c.ContactPhoneId.Equals(entity.ContactPhoneId) && c.ContactId.Equals(entity.ContactId)).Result.Count() < 1)
                    throw new InvalidOperationException("O cliente deve ao menos ter um telefone!");
            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        private void BeforeAdd(ContactPhone entity)
        {

            try
            {
                if (entity.ContactId <= 0)
                    throw new InvalidOperationException("Informe o contato!");

                if (entity.ContactTypeId <= 0)
                    throw new InvalidOperationException("Informe o tipo do contato!");

                if (base.List(c => c.ContactId.Equals(entity.ContactId) && c.Number.Equals(entity.Number) && c.ContactTypeId.Equals(entity.ContactTypeId)).Result.Count() > 0)
                    throw new InvalidOperationException("Este telefone já existe para este contato!");


            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
