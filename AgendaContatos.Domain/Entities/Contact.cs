using System;
using System.Collections.Generic;

namespace AgendaContatos.Domain.Entities
{
    public class Contact
    {
        public virtual int ContactId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Address { get; protected set; }

        public virtual string Company { get; protected set; }        

        protected Contact() {

        }

        public Contact(string name, string address = "", string company = "")
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new InvalidOperationException("Informe o nome do contato");

                Name = name;

                Address = address;

                Company = company;
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

        public Contact(int contatcId, string name, string address = "", string company = "")
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    throw new InvalidOperationException("Informe o nome do contato");

                Name = name;

                Address = address;

                Company = company;

                ContactId = contatcId;

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

        public virtual ICollection<ContactPhone> Phones { get; protected set; }

        public virtual ICollection<ContactMail> Mails { get; protected set; }
    }
}
