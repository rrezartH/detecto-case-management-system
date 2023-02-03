using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class PalaService : IPala
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        private readonly DeklarataService deklarataService;
        public PalaService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            deklarataService = new DeklarataService(_context, _mapper);
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

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id)
        {
            return await deklarataService.GetDeklaratatEPersonit(id);
        }

        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            return new OkObjectResult(await deklarataService.AddDeklarata(deklarataDTO));
        }

        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO)
        {
            return new OkObjectResult(await deklarataService.UpdateDeklarata(id, updateDeklarataDTO));
        }

        public async Task<string> Compare(int d1Id, int d2Id)
        {
            return await deklarataService.Compare(d1Id, d2Id);
        }
    }
}
