using System;
using System.Text.RegularExpressions;

namespace AgendaContatos.Domain.Entities
{
    public class ContactMail
    {
        public virtual int ContactMailId { get; protected set; }

        public virtual int ContactId { get; protected set; }
        
        public virtual string Address { get; protected set; }

        public virtual int ContactTypeId { get; protected set; }        

        public virtual ContactType ContactType { get; protected set; }
               
        protected ContactMail()
        {

        }

        public ContactMail(string address, int contactTypeId)
        {
            try
            {
                if (string.IsNullOrEmpty(address))
                    throw new InvalidOperationException("Informe o endereço do e-mail");               

                Address = address;

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

        public ContactMail(int mailId,int contactId, int contactTypeId, string address)
        {
            try
            {
                if (contactId < 0)
                    throw new InvalidOperationException("Informe o contato do e-mail");

                if(string.IsNullOrEmpty(address))
                    throw new InvalidOperationException("Informe o endereço do e-mail");                

                ContactId = contactId;

                Address = address;

                ContactTypeId = contactTypeId;

                ContactMailId = mailId;
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

        private void CheckMail() {

            try
            {
                var rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

                if (!rg.IsMatch(this.Address))
                    throw new InvalidCastException("Endereço de e-mail invalid");
            }
            catch (InvalidCastException ex) {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
