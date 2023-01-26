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

        public async Task<ActionResult> GetViktimaById(int id)
        {
            var mappedViktima = _mapper.Map<ViktimaDTO>(await _context.Viktimat.FindAsync(id));
            if (mappedViktima == null)
                return new NotFoundObjectResult("Viktima nuk ekziston.");
            return new OkObjectResult(mappedViktima);
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

        public async Task<ActionResult> UpdateViktima(int id, UpdateViktimaDTO updateViktimaDTO)
        {
            if (updateViktimaDTO == null)
                return new BadRequestObjectResult("Viktima nuk mund të jetë null!!");

            var dbViktima = await _context.Viktimat.FindAsync(id);
            if (dbViktima == null)
                return new NotFoundObjectResult("Viktima nuk ekziston!!");

            dbViktima.Profesioni = updateViktimaDTO.Profesioni ?? dbViktima.Profesioni;
            dbViktima.Statusi = updateViktimaDTO.Statusi ?? dbViktima.Statusi;
            dbViktima.GjendjaMendore = updateViktimaDTO.GjendjaMendore ?? dbViktima.GjendjaMendore;
            dbViktima.eKaluara = updateViktimaDTO.eKaluara ?? dbViktima.eKaluara;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Viktima updated succesfully!");
        }

        public async Task<ActionResult> DeleteViktima(int id)
        {
            var dbViktima = await _context.Viktimat.FindAsync(id);
            if (dbViktima == null)
                return new NotFoundObjectResult("Viktima nuk ekziston!!");

            _context.Viktimat.Remove(dbViktima);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Viktima deleted succesfully!");
        }
    }
}
