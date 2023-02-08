using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Detecto.API.Data.DTOs;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class iDyshuariService : PalaService, IiDyshuariService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public iDyshuariService(DetectoDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<iDyshuariDTO>>> GetTeDyshuarit()
        {
            var teDyshuarit = await _context.TeDyshuarit.ToListAsync();
            if (!teDyshuarit.Any())
                return new NotFoundObjectResult("Nuk ka te dyshuar te regjistruar!");

            var mappedTeDyshuarit = _mapper.Map<List<iDyshuariDTO>>(teDyshuarit);

            foreach (var mappedIDyshuari in mappedTeDyshuarit)
            {
                var id = mappedIDyshuari.Id;
                var deklaratat = _context.Deklaratat.Where(d => d.PersoniId == id).ToList();
                mappedIDyshuari.Deklaratat = _mapper.Map<List<DeklarataDTO>>(deklaratat);
                var gjurmet = _context.GjurmetBiologjike.Where(g => g.PersoniId == id).ToList();
                mappedIDyshuari.GjurmetBiologjike = _mapper.Map<List<GjurmaBiologjikeDTO>>(gjurmet);
            }

            return new OkObjectResult(mappedTeDyshuarit);
        }

        public async Task<ActionResult> GetTeDyshuarinById(int id)
        {
            var iDyshuari = await _context.TeDyshuarit.FindAsync(id);
            if (iDyshuari == null)
                return new NotFoundObjectResult("I dyshuari nuk ekziston!!");

            var mappediDyshuari = _mapper.Map<iDyshuariDTO>(iDyshuari);
            var deklaratat = _context.Deklaratat.Where(d => d.PersoniId == id).ToList();
            mappediDyshuari.Deklaratat = _mapper.Map<List<DeklarataDTO>>(deklaratat);
            var gjurmet = _context.GjurmetBiologjike.Where(g => g.PersoniId == id).ToList();
            mappediDyshuari.GjurmetBiologjike = _mapper.Map<List<GjurmaBiologjikeDTO>>(gjurmet);

            return new OkObjectResult(mappediDyshuari);
        }

        public async Task<ActionResult<string>> GetDyshimiMbiTeDyshuarin(int id)
        {
            var dbDyshimi = await _context.TeDyshuarit.FindAsync(id);
            return dbDyshimi == null 
                ? new NotFoundObjectResult("Personi nuk dyshohet!!")
                : dbDyshimi.Dyshimi;
        }

        public async Task<ActionResult> AddTeDyshuarin(iDyshuariDTO iDyshuariDto)
        {
            if (iDyshuariDto == null)
                return new BadRequestObjectResult("I dyshuari nuk mund të jetë null!!");
            var mappedIDyshuari = _mapper.Map<iDyshuari>(iDyshuariDto);
            await _context.TeDyshuarit.AddAsync(mappedIDyshuari);
            await _context.SaveChangesAsync();
            return new OkObjectResult("I dyshuari u shtua me sukses!");
        }

        public async Task<ActionResult> UpdateTeDyshuarin(int id, UpdateiDyshuariDTO updateiDyshuariDto)
        {
            if (updateiDyshuariDto == null)
                return new BadRequestObjectResult("I dyshuari nuk mund të jetë null!!");

            var dbIDyshuari = await _context.TeDyshuarit.FindAsync(id);
            if (dbIDyshuari == null)
                return new NotFoundObjectResult("Dëshmitari nuk ekziston!!");

            dbIDyshuari.Emri = updateiDyshuariDto.Emri ?? dbIDyshuari.Emri;
            dbIDyshuari.Gjinia = updateiDyshuariDto.Gjinia ?? dbIDyshuari.Gjinia;
            dbIDyshuari.Profesioni = updateiDyshuariDto.Profesioni ?? dbIDyshuari.Profesioni;
            dbIDyshuari.Statusi = updateiDyshuariDto.Statusi ?? dbIDyshuari.Statusi;
            dbIDyshuari.Vendbanimi = updateiDyshuariDto.Vendbanimi ?? dbIDyshuari.Vendbanimi;
            dbIDyshuari.GjendjaMendore = updateiDyshuariDto.GjendjaMendore ?? dbIDyshuari.GjendjaMendore;
            dbIDyshuari.EKaluara = updateiDyshuariDto.EKaluara ?? dbIDyshuari.EKaluara;
            dbIDyshuari.Dyshimi = updateiDyshuariDto.Dyshimi ?? dbIDyshuari.Dyshimi;
            await _context.SaveChangesAsync();

            return new OkObjectResult("I dyshuari u përditësua me sukses!");
        }

        public async Task<ActionResult<string>> GetInfo(int id)
        {
            var dbIDyshuari = await _context.TeDyshuarit.FindAsync(id);
            return dbIDyshuari == null
                ? "I dyshuari nuk ekziston!!"
                : $"I dyshuari: Emri -> " + dbIDyshuari.Emri + ", Profesioni -> " + dbIDyshuari.Profesioni 
                + ", Vendbanimi -> " + dbIDyshuari.Vendbanimi + ", " 
                + "\nPse dyshohet? " + dbIDyshuari.Dyshimi + ".";
        }
    }
}
