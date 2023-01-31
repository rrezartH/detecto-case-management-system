using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces;
using Detecto.API.Data.Services.Interfaces.ProvatInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.ProvatServices
{
    public class ProvaBiologjikeService : IProvaBiologjikeService
    {
        private readonly IMapper _mapper;
        private readonly DetectoDbContext _context;
        private readonly IGjurmaBiologjikeService _gjurmaBiologjikeService;

        public ProvaBiologjikeService(IMapper mapper, DetectoDbContext detectoDbContext, IGjurmaBiologjikeService gjurmaBiologjikeService)
        {
            _mapper = mapper;
            _context = detectoDbContext;
            _gjurmaBiologjikeService = gjurmaBiologjikeService;
        }

        public async Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvatBiologjike() => 
            _mapper.Map<List<ProvaBiologjikeDTO>>(await _context.ProvatBiologjike.ToListAsync());

        public async Task<ActionResult> GetProvenBiologjikeById(int id)
        {
            var mappedProva = _mapper.Map<ProvaBiologjikeDTO>(await _context.ProvatBiologjike.FindAsync(id));
            return mappedProva == null 
                ? new NotFoundObjectResult("Prova nuk ekziston!")
                : new OkObjectResult(mappedProva);
        }

        public async Task<ActionResult> AddProvaBiologjike(ProvaBiologjikeDTO provaDTO)
        {
            if (provaDTO == null)
                return new BadRequestObjectResult("Prova nuk mund të jetë null!!");
            var mappedProva = _mapper.Map<ProvaBiologjike>(provaDTO);
            await _context.ProvatBiologjike.AddAsync(mappedProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova u shtua me sukses!");
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
            dbProva.Specifikimi = updateProvaDTO.Specifikimi ?? dbProva.Specifikimi;
            dbProva.Lloji = updateProvaDTO.Lloji ?? dbProva.Lloji;

            await _context.SaveChangesAsync();

            return new OkObjectResult("Prova u përditësua me sukses!");
        }

        public async Task<ActionResult> DeleteProvaBiologjike(int id)
        {
            var dbProva = await _context.ProvatBiologjike.FindAsync(id);
            if (dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            _context.ProvatBiologjike.Remove(dbProva);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Prova u fshi me sukses!");
        }

        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> Krahaso(int provaId, int personiId)
        {
            // Merr proven ne baze te provaId
            var dbProva = _mapper.Map<ProvaBiologjikeDTO>(await _context.ProvatBiologjike.FindAsync(provaId));

            if(dbProva == null)
                return new NotFoundObjectResult("Prova nuk ekziston!!");

            // Merr listen e Gjurmeve te nje personi ne baze te personiId
            var result = await _gjurmaBiologjikeService.GetGjurmetEPersonit(personiId);
            var objectList = result.Value;

            List<GjurmaBiologjikeDTO> gjurmet = new List<GjurmaBiologjikeDTO>();
            // Kontrollon nëse prova (dbProva) përshtatet me ndonjë "Lloji" dhe "Specifikimi" nga objektet në listë (objectList)
            foreach (var obj in objectList)
            {
                if (dbProva.Lloji == obj.Lloji && dbProva.Specifikimi == obj.Specifikimi)
                    gjurmet.Add(obj);
            }
            return gjurmet;
        }
    }
}