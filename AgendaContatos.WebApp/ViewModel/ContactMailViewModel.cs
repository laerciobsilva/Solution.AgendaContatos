using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.WebApp.ViewModel
{
    public class ContactMailViewModel
    {
        public int ContactMailId { get; set; }
        
        public int ContactId { get; set; }

        public int ContactTypeId { get; set; }

        [Required(ErrorMessage = "Informe o endereço de e-mail")]
        [EmailAddress(ErrorMessage = "Informe um endereço de e-mail válido")]
        public string Address { get; set; }
    }
}
