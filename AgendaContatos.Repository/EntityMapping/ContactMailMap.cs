using AgendaContatos.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaContatos.Repository.EntityMapping
{
    public class ContactMailMap : ClassMap<ContactMail>
    {
        public ContactMailMap()
        {
            Id(c => c.ContactMailId);

            Map(c => c.Address)
                .Length(90)                
                .Not
                .Nullable();

            Map(c => c.ContactId)
                .Not
                .Nullable();

            Map(c => c.ContactTypeId)
                .Not
                .Nullable();            

            HasOne(c => c.ContactType)
                .LazyLoad();

            Table("ContactMail");
        }
    }
}
