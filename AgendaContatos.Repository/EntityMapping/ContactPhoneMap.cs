using AgendaContatos.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaContatos.Repository.EntityMapping
{
    public class ContactPhoneMap : ClassMap<ContactPhone>
    {
        public ContactPhoneMap()
        {
            Id(c => c.ContactPhoneId);

            Map(c => c.ContactId)
                .Not
                .Nullable();

            Map(c => c.Number)
                .Not
                .Nullable();

            Map(c => c.ContactTypeId)
                .Not
                .Nullable();

            HasOne(c => c.ContactType) ;

            Table("ContactPhone");
        }
    }
}
