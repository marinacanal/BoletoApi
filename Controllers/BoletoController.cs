using BoletoApi.DTOs;
using BoletoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoletoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly BoletoService _boletoService;

        public BoletoController(BoletoService boletoService)
        {
            _boletoService = boletoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarBoleto([FromBody] BoletoRequestDTO boletoRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var boletoResponse = await _boletoService.CriarBoleto(boletoRequest);
                return CreatedAtAction(nameof(BuscarBoletoPorId), new { id = boletoResponse.Id }, boletoResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarBoletoPorId(Guid id)
        {
            try
            {
                var boletoResponse = await _boletoService.BuscarBoletoPorId(id);
                return Ok(boletoResponse);
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