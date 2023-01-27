using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation
{
    public class DeklarataService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;

        public DeklarataService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat()
        {
            return _mapper.Map<List<DeklarataDTO>>(await _context.Deklaratat.ToListAsync());
        }
    }
}
