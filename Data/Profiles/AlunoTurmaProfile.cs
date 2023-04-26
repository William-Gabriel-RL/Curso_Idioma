using AutoMapper;
using CrossCutting.Dtos.AlunoTurma;
using Domain;

namespace Data.Profiles
{
    public class AlunoTurmaProfile : Profile
    {
        public AlunoTurmaProfile()
        {
            CreateMap<AlunoTurma, AlunoTurmaDto>();
            CreateMap<AlunoTurma, AlunoTurmaAtualizarDto>();
            CreateMap<AlunoTurmaCriarDto, AlunoTurma>();
            CreateMap<AlunoTurmaAtualizarDto, AlunoTurma>();
            CreateMap<AlunoTurmaDto, AlunoTurmaAtualizarDto>();
        }
    }
}
