using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_final_AVMB.DataModels;

namespace Projeto_Final_AVMB.Controllers
{
    [ApiController]
    [Route("uniformes")]
    public class UniformeController : ControllerBase
    {
        [HttpGet]
        [Route("todos")]

        public async Task<IActionResult> getAll(
            [FromServices] Contexto contexto)
        {
            var uniformes = await contexto
                .Uniformes
                .AsNoTracking()//Só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .ToListAsync();

            return uniformes == null ? NotFound() : Ok(uniformes);
        }

        [HttpGet]
        [Route("uniformes/{id}")]
        public async Task<IActionResult> getByIdAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var uniforme = await contexto
                .Uniformes.AsNoTracking() //AsNoTracking = cancela a ligação com o Banco de Dados, usado apenas para mostrar algo...
                .FirstOrDefaultAsync(p => p.id == id);

            return uniforme == null ? NotFound() : Ok(uniforme);
        }

        [HttpPost]
        [Route("uniformes")]
        public async Task<IActionResult> PostAsync(
            [FromServices] Contexto contexto,
            [FromBody] Uniforme uniforme
            )
        {
            try
            {
                await contexto.Uniformes.AddAsync(uniforme);
                await contexto.SaveChangesAsync();
                return Created($"api/uniforme/{uniforme.id}", uniforme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("uniformes/{id}")]
        public async Task<IActionResult> PutAsync
            (
                [FromServices] Contexto contexto,
                [FromBody] Uniforme uniforme,
                [FromRoute] int id

            )
        {

            var p = await contexto.Uniformes
                .FirstOrDefaultAsync(x => x.id == id);

            if (p == null)
                return NotFound("Uniforme não encontrado!");

            try
            {
                p.peca_roupa = uniforme.peca_roupa;

                contexto.Uniformes.Update(p);
                await contexto.SaveChangesAsync();
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("uniformes/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id)
        {
            var p = await contexto.Uniformes.FirstOrDefaultAsync(x => x.id == id);

            if (p == null)
                return BadRequest("Uniforme não encontrado");

            try
            {
                contexto.Uniformes.Remove(p);
                await contexto.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}