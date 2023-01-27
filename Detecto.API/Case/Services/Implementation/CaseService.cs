using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Case.Models;
using Detecto.API.Configurations;
using Detecto.API.Data.Services.Interfaces;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Case.Services.Implementation
{
    public class CaseService
    {
        private readonly IMapper _mapper;
        private readonly DetectoDbContext _context;
        private readonly IPala _palet;

        public CaseService(DetectoDbContext context, IMapper mapper, IPala palet)
        {
            _context = context;
            _mapper = mapper;
            _palet = palet;
        }

        public async Task<ActionResult<List<GetCaseDTO>>> GetCases()
        {
            return _mapper.Map<List<GetCaseDTO>>(await _context.Cases.ToListAsync());
        }

        public async Task<ActionResult<List<GetCaseDTO>>> GetCaseById(int id)
        {
            var dCase = await _context.Cases.FindAsync(id);
            if (dCase == null)
                return new NotFoundObjectResult("Dosja nuk ekziston!");

            var mappedCase = _mapper.Map<GetCaseDTO>(dCase);

            mappedCase.Viktimat = await _palet.GetViktimat(id);
            mappedCase.Deshmitaret = await _palet.GetDeshmitaret(id);
            mappedCase.TeDyshuarit = await _palet.GetTeDyshuarit(id);

            return new OkObjectResult(mappedCase);
        }
        public async Task<ActionResult> AddCase(AddCaseDTO caseDTO)
        {
            if (caseDTO == null)
                return new BadRequestObjectResult("You can't add an empty case!");
            var mappedCase = _mapper.Map<DCase>(caseDTO);
            await _context.Cases.AddAsync(mappedCase);
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dosja u shtua me sukses!");
        }

        internal Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
        {
            throw new NotImplementedException();
        }
        internal Task<ActionResult> DeleteCase(int id)
        {
            throw new NotImplementedException();
        }

    }
}
