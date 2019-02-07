using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgendaContatos.WebApp.ViewModel
{
    public class ContactViewModel
    {
        public int ContactId { get; set; }

        [Required( AllowEmptyStrings = false, ErrorMessage = "Informe o nome do contato")]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Company { get; set; }

        public List<ContactMailViewModel> Mails { get; set; }

        public List<ContactPhoneViewModel> Phones { get; set; }        
       
    }
}
