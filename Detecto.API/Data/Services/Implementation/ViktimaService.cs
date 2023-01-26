using Abp.Domain.Uow;
using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Configurations;
using Detecto.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data
{
    public class ViktimaService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public ViktimaService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimat()
        {
            return _mapper.Map<List<ViktimaDTO>>(await _context.Viktimat.ToListAsync());
        }

        public async Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO)
        {
            if (viktimaDTO == null)
                return new BadRequestObjectResult("Viktima can't be null!");
            var mappedViktima = _mapper.Map<Viktima>(viktimaDTO);
            await _context.Viktimat.AddAsync(mappedViktima);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Viktima added succesfully!");
        }
    }
}
