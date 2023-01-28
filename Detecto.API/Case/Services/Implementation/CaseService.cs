using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Case.Models;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
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

        public async Task<ActionResult<List<GetCasesDetailsDTO>>> GetCases()
        {
            return _mapper.Map<List<GetCasesDetailsDTO>>(await _context.Cases.ToListAsync());
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

        public async Task<ActionResult> UpdateCase(int id, UpdateCaseDTO updateCaseDTO)
        {
            if (updateCaseDTO == null)
                return new BadRequestObjectResult("Nuk ka nevoje te perditesohet asgje.");

            var dbCase = await _context.Cases.FindAsync(id);
            if (dbCase == null)
                return new NotFoundObjectResult("Dosja nuk ekziston!");

            dbCase.ImageUrl = updateCaseDTO.ImageUrl ?? dbCase.ImageUrl;
            dbCase.Identifier = updateCaseDTO.Identifier ?? dbCase.Identifier;
            dbCase.Title = updateCaseDTO.Title ?? dbCase.Title;
            dbCase.Status = updateCaseDTO.Status ?? dbCase.Status;
            dbCase.Details = updateCaseDTO.Details ?? dbCase.Details;
            dbCase.DateClosed = updateCaseDTO.DateClosed ?? dbCase.DateClosed;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Dosja updated succesfully!");
        }
        public async Task<ActionResult> DeleteCase(int id)
        {
            var dbCase = await _context.Cases.FindAsync(id);
            if (dbCase == null)
                return new NotFoundObjectResult("Dosja nuk ekziston!!");

            _context.Cases.Remove(dbCase);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dosja u fshi me sukses!");
        }
    }
}
