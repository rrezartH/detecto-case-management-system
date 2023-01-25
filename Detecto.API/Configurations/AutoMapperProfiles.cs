using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Case.Models;

namespace Detecto.API.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DCase, GetCaseDTO>();
        }
    }
}
