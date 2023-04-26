using AutoMapper;
using Business.Interfaces.Base;
using CrossCutting.Dtos.Base;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Base
{
    public class BaseController<T, TDto, TCriarDto, TAtualizarDto> : ControllerBase where T : class where TDto : class where TCriarDto : class where TAtualizarDto : BaseAtualizarDto
    {
        protected readonly IBaseService<T> _service;
        protected readonly IMapper _mapper;

        public BaseController(IBaseService<T> baseService, IMapper mapper)
        {
            _service = baseService;
            _mapper = mapper;
        }

        protected ActionResult Criar(TCriarDto dto)
        {
            var obj = _mapper.Map<TCriarDto, T>(dto);
            var response = _service.Criar(obj);

            return Ok(response);
        }

        protected ActionResult BuscarPorId(int id)
        {
            var response = _service.BuscarPorId(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<T, TDto>(response));
        }

        protected ActionResult BuscarTodos()
        {
            var response = _service.BuscarPorTodos();
            if (response.Any())
            {
                return Ok(_mapper.Map<IEnumerable<TDto>>(response));
            }
            return NoContent();
        }

        protected ActionResult Atualizar(int id, TAtualizarDto dto)
        {
            var obj = _mapper.Map<TAtualizarDto, T>(dto);
            var response = _service.Atualizar(id, obj);

            return Ok(response);
        }

        protected ActionResult Remover(int id)
        {
            _service.Remover(id);
            return NoContent();
        }

        protected ActionResult AtualizarParcialmente(int id, JsonPatchDocument<TAtualizarDto> modeloClasse)
        {
            if (_service.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            var objParaAtualizar = _mapper.Map<TAtualizarDto>(_service.BuscarPorId(id));

            modeloClasse.ApplyTo(objParaAtualizar);

            if (!TryValidateModel(objParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            var objAtualizado = _mapper.Map<TAtualizarDto, T>(objParaAtualizar);

            _service.Atualizar(id, objAtualizado);

            return Ok("Atualizado com sucesso");
        }
    }
}
