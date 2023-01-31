using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.ProvatServices
{
    public class ProvaFizikeService : IProvaFizikeService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public ProvaFizikeService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetProvatFizike() =>
                     _mapper.Map<List<ProvaFizikeDTO>>(await _context.ProvatFizike.ToListAsync());

        public async Task<ActionResult> GetProvenFizikeById(int id)
        {
            var mappedProva = _mapper.Map<ProvaFizikeDTO>(await _context.ProvatFizike.FindAsync(id));
            return mappedProva == null
                ? new NotFoundObjectResult("Prova nuk ekziston.")
                : new OkObjectResult(mappedProva);
        }

        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetPerEkzaminim(bool b)
        {
            return _mapper.Map<List<ProvaFizikeDTO>>(await _context.ProvatFizike
                                .Where(p => p.DuhetEkzaminim == b)
                                .ToListAsync());
        }

        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetMeGjurmeBiologjike(bool b)
        {
            return _mapper.Map<List<ProvaFizikeDTO>>(await _context.ProvatFizike
                                .Where(p => p.KaGjurmeBiologjike == b)
                                .ToListAsync());
        }

        public async Task<ActionResult<List<ProvaFizikeDTO>>> GetSipasRrezikut(string str)
        {
            return _mapper.Map<List<ProvaFizikeDTO>>(await _context.ProvatFizike
                                .Where(p => p.Rrezikshmeria == str)
                                .ToListAsync());
        }

        public async Task<ActionResult> AddProvaFizike(ProvaFizikeDTO provaDTO)
        {
            if (provaDTO == null)
                return new BadRequestObjectResult("Prova nuk mund të jetë null!!");
            var mappedProva = _mapper.Map<ProvaFizike>(provaDTO);
            await _context.ProvatFizike.AddAsync(mappedProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova u shtua me sukses!");
        }

        public async Task<ActionResult> UpdateProvaFizike(int id, UpdateProvaFizikeDTO updateProvaDTO)
        {
            if (updateProvaDTO == null)
                return new BadRequestObjectResult("Prova nuk mund të jetë null!!");

            var dbProva = await _context.ProvatFizike.FindAsync(id);
            if (dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            dbProva.Emri = updateProvaDTO.Emri ?? dbProva.Emri;
            dbProva.KohaENxjerrjes = updateProvaDTO.KohaENxjerrjes ?? dbProva.KohaENxjerrjes;
            dbProva.Vendndodhja = updateProvaDTO.Vendndodhja ?? dbProva.Vendndodhja;
            dbProva.Attachment = updateProvaDTO.Attachment ?? dbProva.Attachment;
            dbProva.EPerdorurNeKrim = updateProvaDTO.EPerdorurNeKrim ?? dbProva.EPerdorurNeKrim;
            dbProva.Rrezikshmeria = updateProvaDTO.Rrezikshmeria ?? dbProva.Rrezikshmeria;
            dbProva.Klasifikimi = updateProvaDTO.Klasifikimi ?? dbProva.Klasifikimi;
            dbProva.DuhetEkzaminim = updateProvaDTO.DuhetEkzaminim ?? dbProva.DuhetEkzaminim;
            dbProva.KaGjurmeBiologjike = updateProvaDTO.KaGjurmeBiologjike ?? dbProva.KaGjurmeBiologjike;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Prova u përditësua me sukses!");
        }

        public async Task<ActionResult> DeleteProvaFizike(int id)
        {
            var dbProva = await _context.ProvatFizike.FindAsync(id);
            if (dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            _context.ProvatFizike.Remove(dbProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova u fshi me sukses!");
        }

    }
}
