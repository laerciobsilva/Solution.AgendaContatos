using AgendaContatos.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaContatos.Repository.EntityMapping
{
    public class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Id(c => c.ContactId);

            Map(c => c.Name)
                .Length(25)
                .Not
                .Nullable();

            Map(c => c.Address)
                .Length(50)
                .Nullable();

            Map(c => c.Company)
                .Length(50)
                .Nullable();

            HasMany(c => c.Phones)
                .KeyColumn("ContactId")
                .Inverse();

            HasMany(c => c.Mails)
                .KeyColumn("ContactId")
                .Inverse();
                


            Table("Contact");
        }
    }
}
