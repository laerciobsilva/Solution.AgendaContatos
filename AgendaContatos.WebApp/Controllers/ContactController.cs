using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.WebApp.Helpers;
using AgendaContatos.WebApp.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactApplication _appContact;
        private readonly IPhoneApplication _appPhone;
        private readonly IMailApplication _appMail;

        public ContactController(IContactApplication appContact, IPhoneApplication appPhone, IMailApplication appMail)
        {
            _appContact = appContact;
            _appMail = appMail;
            _appPhone = appPhone;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContactViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidCastException(ModelState.GetErrorModel());

                var entity = Mapper.Map<Contact>(model);

                await _appContact.UpdateAsync(entity);

                return Ok();

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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidCastException(ModelState.GetErrorModel());

                var entity = Mapper.Map<Contact>(model);

                await _appContact.AddAsync(entity);

                if (entity.ContactId > 0) {

                    model.Phones.ForEach(item =>
                    {
                        item.ContactId = entity.ContactId;

                        var phone = Mapper.Map<ContactPhone>(item);

                        _appPhone.AddAsync(phone);
                    });

                    model.Mails.ForEach(item =>
                    {
                        try
                        {
                            item.ContactId = entity.ContactId;

                            var mail = Mapper.Map<ContactMail>(item);

                            _appMail.AddAsync(mail);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    });
                }

                return Ok();

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id<= 0)
                    throw new InvalidCastException("Informe o contato para ser excluído!");

                var entity = _appContact.GetAsync(id).Result;

                await _appContact.RemoveAsync(entity);

                return Ok();

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

        
          
        [HttpGet("List")]
        public async Task<IActionResult> Get()
        {
            try
            {

                var itens = await _appContact.List();

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

        [HttpGet("Search")]
        public async Task<IActionResult> Get([FromQuery] string name, string phone, string mail)
        {
            try
            {
                if (!string.IsNullOrEmpty(string.Concat(name, phone, mail))){

                    var itens = await _appContact.List(a => a.Name.Contains(name)
                                                   || a.Phones.Where(b => b.Number.Contains(phone)).Count() > 0
                                                   || a.Mails.Where(b => b.Address.Contains(mail)).Count() > 0);

                    return Ok(itens);
                }
                else {

                    var itens = await _appContact.List();

                    return Ok(itens);

                }
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _appContact.GetAsync(id);

                return Ok(entity);

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