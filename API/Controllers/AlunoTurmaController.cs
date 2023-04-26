using API.Controllers.Base;
using AutoMapper;
using Business.Interfaces;
using CrossCutting.Dtos.AlunoTurma;
using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoTurmaController : BaseController<AlunoTurma, AlunoTurmaDto, AlunoTurmaCriarDto, AlunoTurmaAtualizarDto>
    {
        public AlunoTurmaController(IAlunoTurmaService baseService, IMapper mapper) : base(baseService, mapper)
        {
        }

        [HttpPost]
        public ActionResult CriarAlunoTurma([FromBody] AlunoTurmaCriarDto alunoTurmaCriarDto)
        {
            return Criar(alunoTurmaCriarDto);
        }

        [HttpGet]
        public ActionResult BuscarTodosAlunosTurmas()
        {
            return BuscarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult BuscarAlunoTurmaPorId(int id)
        {
            return BuscarPorId(id);
        }

        [HttpPut]
        public ActionResult AtualizarAlunoTurma(int id, AlunoTurmaAtualizarDto alunoTurmaAtualizarDto)
        {
            Atualizar(id, alunoTurmaAtualizarDto);
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarAlunoTurma(int id)
        {
            return Remover(id);
        }

        [HttpPatch("{id}")]
        public ActionResult AtualizarParcialmenteAlunoTurma(int id, JsonPatchDocument<AlunoTurmaAtualizarDto> modeloAlunoTurma)
        {
            return AtualizarParcialmente(id, modeloAlunoTurma);
        }
    }
}