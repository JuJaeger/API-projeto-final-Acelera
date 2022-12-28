using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_final_AVMB.DataModels;
using Projeto_Final_AVMB.DataModels;

namespace Projeto_Final_AVMB.Controllers
{
    [ApiController]
    [Route("alunos")]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        [Route("alunos")]

        public async Task<IActionResult> getAllAsync(
            [FromServices] Contexto contexto)
        {
            var alunos = await contexto
                .Alunos
                .AsNoTracking()//Só pode ser utilizado em consultas - altamente recomendado por questões de desempenho
                .ToListAsync();

            return alunos == null ? NotFound() : Ok(alunos);
        }

        [HttpGet]
        [Route("aluno/{id}")]
        public async Task<IActionResult> getByIdAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id
            )
        {
            var aluno = await contexto
                .Alunos.AsNoTracking() //AsNoTracking = cancela a ligação com o Banco de Dados, usado apenas para mostrar algo...
                .FirstOrDefaultAsync(p => p.id == id);

            return aluno == null ? NotFound() : Ok(aluno);
        }

        [HttpPost]
        [Route("aluno")]
        public async Task<IActionResult> PostAsync(
            [FromServices] Contexto contexto,
            [FromBody] Aluno aluno
            )
        {
            try
            {
                await contexto.Alunos.AddAsync(aluno);
                //contexto.Alunos.Entry(aluno).State = EntityState.Detached;
                foreach (AlunoUniforme item in aluno.AlunoUniformes)
                {
                    contexto.Entry(item).State = EntityState.Unchanged;
                    //contexto.Entry(item).State = EntityState.Detached;
                }
                await contexto.SaveChangesAsync();
                return Created($"api/alunos/{aluno.id}", aluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("alunos/{id}")]
        public async Task<IActionResult> PutAsync
            (
                [FromServices] Contexto contexto,
                [FromBody] Aluno aluno,
                [FromRoute] int id

            )
        {

            var p = await contexto.Alunos
                .FirstOrDefaultAsync(x => x.id == id);

            if (p == null)
                return NotFound("Aluno não encontrado!");

            try
            {
                p.nome_completo = aluno.nome_completo;
                p.nome_guerra = aluno.nome_guerra;
                p.numero = aluno.numero;
                p.nome_responsavel = aluno.nome_responsavel;
                p.data_cadastro = aluno.data_cadastro;

                contexto.Alunos.Update(p);
                await contexto.SaveChangesAsync();
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("alunos/{id}")]

        public async Task<IActionResult> DeleteAsync(
            [FromServices] Contexto contexto,
            [FromRoute] int id)
        {
            var p = await contexto.Alunos.FirstOrDefaultAsync(x => x.id == id);

            if (p == null)
                return BadRequest("Aluno não encontrado");

            try
            {
                contexto.Alunos.Remove(p);
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