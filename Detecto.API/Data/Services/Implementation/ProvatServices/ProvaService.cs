using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.ProvatServices
{
    public class ProvaService : IProvaService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public ProvaService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ProvaDTO>>> GetProvat() =>
            _mapper.Map<List<ProvaDTO>>(await _context.Provat.ToListAsync());

        public async Task<ActionResult> GetProvaById(int id)
        {
            var mappedProva = _mapper.Map<ProvaDTO>(await _context.Provat.FindAsync(id));
            return mappedProva == null 
                ? new NotFoundObjectResult("Prova nuk ekziston.")
                : new OkObjectResult(mappedProva);
        }

        public async Task<ActionResult> DeleteProva(int id)
        {
            var dbProva = await _context.Provat.FindAsync(id);
            if (dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            _context.Provat.Remove(dbProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova u fshi me sukses!");
        }
    }
}
