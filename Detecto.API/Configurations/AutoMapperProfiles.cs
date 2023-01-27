using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Case.Models;
using Detecto.API.Data;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Models;

namespace Detecto.API.Configurations
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DCase, GetCaseDTO>();
            CreateMap<Viktima, ViktimaDTO>().ReverseMap();
            CreateMap<Deshmitari, DeshmitariDTO>().ReverseMap();
            CreateMap<iDyshuari, iDyshuariDTO>().ReverseMap();
            CreateMap<ProvaFizike, ProvaFizikeDTO>().ReverseMap();
            CreateMap<ProvaBiologjike, ProvaBiologjikeDTO>().ReverseMap();
            CreateMap<GjurmaBiologjike, GjurmaBiologjikeDTO>().ReverseMap();
            CreateMap<Deklarata, DeklarataDTO>().ReverseMap();
        }
    }
}
