using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class iDyshuariService : IiDyshuariService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public iDyshuariService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<iDyshuariDTO>>> GetTeDyshuarit()
        {
            return _mapper.Map<List<iDyshuariDTO>>(await _context.TeDyshuarit.ToListAsync());
        }

        public async Task<ActionResult> GetTeDyshuarinById(int id)
        {
            var mappedIDyshuari = _mapper.Map<iDyshuariDTO>(await _context.TeDyshuarit.FindAsync(id));
            if (mappedIDyshuari == null)
                return new NotFoundObjectResult("I dyshuari nuk ekziston!!");
            return new OkObjectResult(mappedIDyshuari);
        }

        public async Task<ActionResult<string>> GetDyshimiMbiTeDyshuarin(int id)
        {
            var dbDyshimi = await _context.TeDyshuarit.FindAsync(id);
            if (dbDyshimi == null)
                return new NotFoundObjectResult("Personi nuk dyshohet!!");

            return dbDyshimi.Dyshimi;
        }

        public async Task<ActionResult> AddTeDyshuarin(iDyshuariDTO iDyshuariDto)
        {
            if (iDyshuariDto == null)
                return new BadRequestObjectResult("I dyshuari can't be null!");
            var mappedIDyshuari = _mapper.Map<iDyshuari>(iDyshuariDto);
            await _context.TeDyshuarit.AddAsync(mappedIDyshuari);
            await _context.SaveChangesAsync();
            return new OkObjectResult("I dyshuari added succesfully!");
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
            dbIDyshuari.EKaluara = updateiDyshuariDto.eKaluara ?? dbIDyshuari.EKaluara;
            dbIDyshuari.Dyshimi = updateiDyshuariDto.Dyshimi ?? dbIDyshuari.Dyshimi;
            await _context.SaveChangesAsync();

            return new OkObjectResult("I dyshuari updated succesfully!");
        }

        public async Task<ActionResult> DeleteTeDyshuarin(int id)
        {
            var dbIDyshuari = await _context.TeDyshuarit.FindAsync(id);
            if (dbIDyshuari == null)
                return new NotFoundObjectResult("I dyshuari nuk ekziston!!");

            _context.TeDyshuarit.Remove(dbIDyshuari);
            await _context.SaveChangesAsync();
            return new OkObjectResult("I dyshuari u fshi me sukses!");
        }
    }
}
