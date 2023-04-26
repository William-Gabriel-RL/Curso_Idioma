using API.Controllers.Base;
using AutoMapper;
using Business.Interfaces;
using CrossCutting.Dtos.Turma;
using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : BaseController<Turma, TurmaDto, TurmaCriarDto, TurmaAtualizarDto>
    {
        public TurmaController(ITurmaService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }

        [HttpPost]
        public ActionResult CriarTurma([FromBody] TurmaCriarDto turmaCriarDto)
        {
            return Criar(turmaCriarDto);
        }

        [HttpGet]
        public ActionResult BuscarTodoasTurmas()
        {
            return BuscarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult BuscarTurmaPorId(int id)
        {
            return BuscarPorId(id);
        }

        [HttpPut]
        public ActionResult AtualizarTurma(int id, TurmaAtualizarDto turmaAtualizarDto)
        {
            Atualizar(id, turmaAtualizarDto);
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarTurma(int id)
        {
            return Remover(id);
        }

        [HttpPatch("{id}")]
        public ActionResult AtualizarParcialmenteTurma(int id, JsonPatchDocument<TurmaAtualizarDto> modeloTurma)
        {
            return AtualizarParcialmente(id, modeloTurma);
        }
    }
}
