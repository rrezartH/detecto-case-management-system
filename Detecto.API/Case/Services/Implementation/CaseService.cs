using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Case.Services.Implementation
{
    public class CaseService
    {
        private readonly IMapper _mapper;
        private readonly DetectoDbContext _context;

        public CaseService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<GetCaseDTO>>> GetCases()
        {
            return _mapper.Map<List<GetCaseDTO>>(await _context.Cases.ToListAsync());
        }
    }
}
