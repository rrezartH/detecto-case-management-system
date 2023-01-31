using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class ViktimaService : PalaService, IViktimaService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public ViktimaService(DetectoDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<ViktimaDTO>>> GetViktimat() =>
            _mapper.Map<List<ViktimaDTO>>(await _context.Viktimat.ToListAsync());

        public async Task<ActionResult> GetViktimaById(int id)
        {
            var mappedViktima = _mapper.Map<ViktimaDTO>(await _context.Viktimat.FindAsync(id));
            return mappedViktima == null 
                ? new NotFoundObjectResult("Viktima nuk ekziston!")
                : new OkObjectResult(mappedViktima);
        }

        public async Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO)
        {
            if (viktimaDTO == null)
                return new BadRequestObjectResult("Viktima nuk mund të jetë null!!");
            var mappedViktima = _mapper.Map<Viktima>(viktimaDTO);
            await _context.Viktimat.AddAsync(mappedViktima);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Viktima u shtua me sukses!");
        }

        public async Task<ActionResult> UpdateViktima(int id, UpdateViktimaDTO updateViktimaDTO)
        {
            if (updateViktimaDTO == null)
                return new BadRequestObjectResult("Viktima nuk mund të jetë null!!");

            var dbViktima = await _context.Viktimat.FindAsync(id);
            if (dbViktima == null)
                return new NotFoundObjectResult("Viktima nuk ekziston!!");

            dbViktima.Emri = updateViktimaDTO.Emri ?? dbViktima.Emri;
            dbViktima.Gjinia = updateViktimaDTO.Gjinia ?? dbViktima.Gjinia;
            dbViktima.Profesioni = updateViktimaDTO.Profesioni ?? dbViktima.Profesioni;
            dbViktima.Statusi = updateViktimaDTO.Statusi ?? dbViktima.Statusi;
            dbViktima.Vendbanimi = updateViktimaDTO.Vendbanimi ?? dbViktima.Vendbanimi;
            dbViktima.GjendjaMendore = updateViktimaDTO.GjendjaMendore ?? dbViktima.GjendjaMendore;
            dbViktima.EKaluara = updateViktimaDTO.EKaluara ?? dbViktima.EKaluara;
            dbViktima.Vendi = updateViktimaDTO.Vendi ?? dbViktima.Vendi;
            dbViktima.Koha = updateViktimaDTO.Koha ?? dbViktima.Koha;
            dbViktima.Menyra = updateViktimaDTO.Menyra ?? dbViktima.Menyra;
            dbViktima.Gjendja = updateViktimaDTO.Gjendja ?? dbViktima.Gjendja;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Viktima u përditësua me sukses!");
        }

        public async Task<ActionResult> DeleteViktima(int id)
        {
            var dbViktima = await _context.Viktimat.FindAsync(id);
            if (dbViktima == null)
                return new NotFoundObjectResult("Viktima nuk ekziston!!");

            _context.Viktimat.Remove(dbViktima);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Viktima u fshi me sukses!");
        }

        //Strategy Pattern
        //Metoda GetInfo është metodë e klasës bazë, vetëm se tek kjo nënklasë bëhet override!
        public async override Task<ActionResult<string>> GetInfo(int id)
        {
            var dbViktima = await _context.Viktimat.FindAsync(id);
            return dbViktima == null
                ? "Viktima nuk ekziston!!"
                : $"Viktima: Emri -> " + dbViktima.Emri + ", Profesioni -> " + dbViktima.Profesioni 
                + ", Vendbanimi -> " + dbViktima.Vendbanimi + ", " 
                + "\nKu u gjet? " + dbViktima.Vendi 
                + ",\nKur u gjet? " + dbViktima.Koha 
                + ",\nSi u gjet? " + dbViktima.Menyra 
                + ",\nNë çfarë gjendje u gjet? " + dbViktima.Gjendja + ".";
        }
    }
}