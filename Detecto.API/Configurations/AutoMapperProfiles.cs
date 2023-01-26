using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Case.Models;
using Detecto.API.Data;
using Detecto.API.Data.Models;

namespace Detecto.API.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DCase, GetCaseDTO>();
            CreateMap<Viktima, ViktimaDTO>().ReverseMap();
        }
    }
}
