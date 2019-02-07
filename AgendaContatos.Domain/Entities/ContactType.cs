namespace AgendaContatos.Domain.Entities
{
    public class ContactType
    {
        public virtual int ContactTypeId { get; protected set; }

        public virtual string Description { get; protected set; }
    }
}
