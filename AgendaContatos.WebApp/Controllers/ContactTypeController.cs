using AgendaContatos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaContatos.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeApplication _appContact;

        public ContactTypeController(IContactTypeApplication appContact)
        {
            _appContact = appContact;
        }

        [HttpGet("List")]
        public async Task<IActionResult> Get()
        {
            try
            {

                var itens = await _appContact.List(c=> c.ContactTypeId > 0);

                return Ok(itens);

            }
            catch (InvalidCastException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}