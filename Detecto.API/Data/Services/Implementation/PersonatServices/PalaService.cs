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
        /*
         * DeklarataService dhe GjurmaBiologjikeService instancohen te kjo klasë
         * ashtu që të mos ripërsëritet kodi që veqse ekziston.
         * Gjithashtu deklarohen si fusha të klasës sepse përdoren në më shumë se një metodë
         * kështu që shihet më efektive si e tillë.
         */
        private readonly DeklarataService deklarataService;
        private readonly GjurmaBiologjikeService gjurmaBiologjikeService;

        public PalaService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            deklarataService = new DeklarataService(_context, _mapper);
            gjurmaBiologjikeService = new GjurmaBiologjikeService(_context, _mapper);
        }

        public async Task<ActionResult> DeletePersoni(int id)
        {
            var dbPersoni = await _context.Personat.FindAsync(id);
            if (dbPersoni == null)
                return new NotFoundObjectResult("Personi nuk ekziston!!");

            _context.Personat.Remove(dbPersoni);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Personi u fshi me sukses!");
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

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id) => 
            await deklarataService.GetDeklaratatEPersonit(id);

        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO) =>
            new OkObjectResult(await deklarataService.AddDeklarata(deklarataDTO));

        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO) =>
            new OkObjectResult(await deklarataService.UpdateDeklarata(id, updateDeklarataDTO));

        public async Task<string> Compare(int d1Id, int d2Id) => 
            await deklarataService.Compare(d1Id, d2Id);

        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> GetGjurmetEPersonit(int id) =>
            await gjurmaBiologjikeService.GetGjurmetEPersonit(id);

        public async Task<ActionResult> AddGjurmaBiologjike(GjurmaBiologjikeDTO gjurmaDTO) =>
            new OkObjectResult(await gjurmaBiologjikeService.AddGjurmaBiologjike(gjurmaDTO));

        public async Task<ActionResult> UpdateGjurmaBiologjike(int id, UpdateGjurmaBiologjikeDTO updateGjurmaBiologjikeDTO) =>
            new OkObjectResult(await gjurmaBiologjikeService.UpdateGjurmaBiologjike(id, updateGjurmaBiologjikeDTO));
    }
}