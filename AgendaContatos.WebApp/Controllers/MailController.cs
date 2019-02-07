using AgendaContatos.Application.Interfaces;
using AgendaContatos.Domain.Entities;
using AgendaContatos.WebApp.Helpers;
using AgendaContatos.WebApp.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaContatos.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailApplication _appMail;

        public MailController(IMailApplication appMail)
        {
            _appMail = appMail;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContactMailViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidCastException(ModelState.GetErrorModel());

                var entity = Mapper.Map<ContactMail>(model);

                await _appMail.UpdateAsync(entity);

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
        public async Task<IActionResult> Post([FromBody] ContactMailViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidCastException(ModelState.GetErrorModel());

                var entity = Mapper.Map<ContactMail>(model);

                await _appMail.AddAsync(entity);

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
                if (id <= 0)
                    throw new InvalidCastException("Informe o e-mail!");

                var entity = _appMail.GetAsync(id).Result;

                await _appMail.RemoveAsync(entity);

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mail = await _appMail.GetAsync(id);

                return Ok(mail);

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