using AgendaContatos.Domain.Entities;
using FluentNHibernate.Mapping;

namespace AgendaContatos.Repository.EntityMapping
{
    public class ContactTypeMap : ClassMap<ContactType>
    {
        public ContactTypeMap()
        {
            Id(c => c.ContactTypeId);

            Map(c => c.Description)
                .Length(25)
                .Unique()
                .Not
                .Nullable();

            Table("ContactType");
        }
    }
}
