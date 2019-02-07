using System;

namespace AgendaContatos.Domain.Entities
{
    public class ContactPhone
    {

        public virtual int ContactPhoneId { get; protected set; }

        public virtual int ContactId { get; protected set; }

        public virtual int ContactTypeId { get; protected set; }

        public virtual string Number { get; protected set; }        

        public virtual ContactType ContactType { get; protected set; }

        protected ContactPhone() {

        }

        public ContactPhone(int contactId, int contactPhoneId, int contactTypeId, string number)
        {
            try
            {
                if(string.IsNullOrEmpty(number.Trim()))
                    throw new InvalidOperationException("Informe o numero de telefone!");

                ContactPhoneId = contactPhoneId;

                ContactId = contactId;

                Number = number.Trim();

                ContactTypeId = contactTypeId;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ContactPhone(int phoneId, string number)
        {
            try
            {
                if (string.IsNullOrEmpty(number.Trim()))
                    throw new InvalidOperationException("Informe o numero de telefone!");

                ContactPhoneId = phoneId;

                Number = number.Trim();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
