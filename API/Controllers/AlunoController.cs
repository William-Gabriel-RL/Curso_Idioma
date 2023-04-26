using API.Controllers.Base;
using AutoMapper;
using Business.Interfaces;
using CrossCutting.Dtos.Aluno;
using Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : BaseController<Aluno, AlunoDto, AlunoCriarDto, AlunoAtualizarDto>
    {
        private readonly IAlunoService _baseService;

        public AlunoController(IAlunoService baseService, IMapper mapper) : base(baseService, mapper)
        {
            _baseService = baseService;
        }

        [HttpPost]
        public ActionResult CriarAluno([FromBody] AlunoCriarDto alunoCriarDto)
        {
            return Ok(_baseService.CriarAluno(alunoCriarDto));
        }

        [HttpGet]
        public ActionResult BuscarTodosAlunos()
        {
            return BuscarTodos();
        }

        [HttpGet("{id}")]
        public ActionResult BuscarAlunoPorId(int id)
        {
            return BuscarPorId(id);
        }

        [HttpPut]
        public ActionResult AtualizarAluno(int id, AlunoAtualizarDto alunoAtualizarDto)
        {
            Atualizar(id, alunoAtualizarDto);
            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarAluno(int id)
        {
            return Remover(id);
        }

        [HttpPatch("{id}")]
        public ActionResult AtualizarParcialmenteAluno(int id, JsonPatchDocument<AlunoAtualizarDto> modeloAluno)
        {
            return AtualizarParcialmente(id, modeloAluno);
        }
    }
}
