using Deal.Vendas.Api.Commands;
using Deal.Vendas.Api.Entities;
using Deal.Vendas.Api.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Deal.Vendas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase
    {

        private readonly IVendasRepositorio _vendasRepositorio;

        public VendasController(IVendasRepositorio vendasRepositorio)
        {
            _vendasRepositorio = vendasRepositorio;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _vendasRepositorio.GetAsync();

            if (result == null || !result.Any())
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _vendasRepositorio.GetAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(InserirVendasCommand command)
        {
            await _vendasRepositorio.PostAsync(command);
            return Created("", null);
        }


        [HttpPatch]
        public async Task<IActionResult> Put(AtualizarVendasCommand command)
        {
            await _vendasRepositorio.PutAsync(command);
            return Ok();
        }

    }
}
