using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class PalaService : IPala
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public PalaService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<DeshmitariDTO>> GetDeshmitaret(int caseId) =>
            _mapper.Map<ICollection<DeshmitariDTO>>(await _context.Deshmitaret
                                .Where(p => p.CaseId == caseId)
                                .ToListAsync());

        public async Task<ICollection<iDyshuariDTO>> GetTeDyshuarit(int caseId) =>
            _mapper.Map<ICollection<iDyshuariDTO>>(await _context.TeDyshuarit
                                .Where(p => p.CaseId == caseId)
                                .ToListAsync());

        public async Task<ICollection<ViktimaDTO>> GetViktimat(int caseId) =>
            _mapper.Map<ICollection<ViktimaDTO>>(await _context.Viktimat
                                    .Where(p => p.CaseId == caseId)
                                    .ToListAsync());

        //Strategy Pattern
        //Metoda kthen një empty string sepse bëhet override tek nënklasat!
        public async virtual Task<ActionResult<string>> GetInfo(int id)
        {
            return "";
        }
    }
}
