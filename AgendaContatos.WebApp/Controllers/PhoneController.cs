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
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneApplication _appPhone;

        public PhoneController(IPhoneApplication appPhone)
        {
            _appPhone = appPhone;
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ContactPhoneViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidCastException(ModelState.GetErrorModel());

                var entity = Mapper.Map<ContactPhone>(model);

                await _appPhone.UpdateAsync(entity);

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
        public async Task<IActionResult> Post([FromBody] ContactPhoneViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidCastException(ModelState.GetErrorModel());

                var entity = Mapper.Map<ContactPhone>(model);

                await _appPhone.AddAsync(entity);

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
                    throw new InvalidOperationException("Informe o telefone para ser removido");

                var entity = _appPhone.GetAsync(id).Result;

                await _appPhone.RemoveAsync(entity);

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
                var mail = await _appPhone.GetAsync(id);

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