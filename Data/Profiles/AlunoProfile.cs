using AutoMapper;
using CrossCutting.Dtos.Aluno;
using Domain;

namespace Data.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<Aluno, AlunoDto>();
            CreateMap<Aluno, AlunoAtualizarDto>();
            CreateMap<AlunoCriarDto, Aluno>();
            CreateMap<AlunoAtualizarDto, Aluno>();
            CreateMap<AlunoDto, AlunoAtualizarDto>();
        }
    }
}
