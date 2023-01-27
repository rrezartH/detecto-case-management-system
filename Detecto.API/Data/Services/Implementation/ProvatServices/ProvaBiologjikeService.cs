using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.ProvatServices
{
    public class ProvaBiologjikeService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public ProvaBiologjikeService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvatBiologjike()
        {
            return _mapper.Map<List<ProvaBiologjikeDTO>>(await _context.ProvatBiologjike.ToListAsync());
        }

        public async Task<ActionResult> GetProvenBiologjikeById(int id)
        {
            var mappedProva = _mapper.Map<ProvaBiologjikeDTO>(await _context.ProvatBiologjike.FindAsync(id));
            if (mappedProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston.");
            return new OkObjectResult(mappedProva);
        }

        public async Task<ActionResult> AddProvaBiologjike(ProvaBiologjikeDTO provaDTO)
        {
            if (provaDTO == null)
                return new BadRequestObjectResult("Prova fizike can't be null!");
            var mappedProva = _mapper.Map<ProvaBiologjike>(provaDTO);
            await _context.ProvatBiologjike.AddAsync(mappedProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova added succesfully!");
        }

        public async Task<ActionResult> UpdateProvaBiologjike(int id, UpdateProvaBiologjikeDTO updateProvaDTO)
        {
            if (updateProvaDTO == null)
                return new BadRequestObjectResult("Prova nuk mund të jetë null!!");

            var dbProva = await _context.ProvatBiologjike.FindAsync(id);
            if (dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            dbProva.Emri = updateProvaDTO.Emri ?? dbProva.Emri;
            dbProva.KohaENxjerrjes = updateProvaDTO.KohaENxjerrjes ?? dbProva.KohaENxjerrjes;
            dbProva.Vendndodhja = updateProvaDTO.Vendndodhja ?? dbProva.Vendndodhja;
            dbProva.Attachment = updateProvaDTO.Attachment ?? dbProva.Attachment;
            dbProva.TeknikaENxjerrjes = updateProvaDTO.TeknikaENxjerrjes ?? dbProva.TeknikaENxjerrjes;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Prova updated succesfully!");
        }

        public async Task<ActionResult> DeleteProvaBiologjike(int id)
        {
            var dbProva = await _context.ProvatBiologjike.FindAsync(id);
            if (dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            _context.ProvatBiologjike.Remove(dbProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova deleted succesfully!");
        }
    }
}
