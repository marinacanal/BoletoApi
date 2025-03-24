using BoletoApi.DTOs;
using BoletoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoletoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BancoController : ControllerBase
    {
        private readonly BancoService _bancoService;

        public BancoController(BancoService bancoService)
        {
            _bancoService =  bancoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarBoleto([FromBody] BancoRequestDTO bancoRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bancoResponse = await _bancoService.CriarBanco(bancoRequest);
                return CreatedAtAction(nameof(BuscarBancoPorId), new { id = bancoResponse.Id }, bancoResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarBancoPorId(Guid id)
        {
            try
            {
                var bancoResponse = await _bancoService.BuscarBancoPorId(id);
                return Ok(bancoResponse);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodosBancos()
        {
            try
            {
                var bancoResponse = await _bancoService.BuscarTodosBancos();
                return Ok(bancoResponse);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}