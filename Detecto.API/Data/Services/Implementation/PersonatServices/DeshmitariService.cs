using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class DeshmitariService : PalaService, IDeshmitariService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public DeshmitariService(DetectoDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret() => 
            _mapper.Map<List<DeshmitariDTO>>(await _context.Deshmitaret.ToListAsync());

        public async Task<ActionResult> GetDeshmitariById(int id)
        {
            var mappedDeshmitari = _mapper.Map<DeshmitariDTO>(await _context.Deshmitaret.FindAsync(id));
            return mappedDeshmitari == null 
                ? new NotFoundObjectResult("Deshmitari nuk ekziston!!")
                : new OkObjectResult(mappedDeshmitari);
        }

        public async Task<ActionResult<bool>> ADyshohet(int id)
        {
            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            if (dbDeshmitari == null)
                return new NotFoundObjectResult("Dëshmitari nuk ekziston!!");
            return dbDeshmitari.Dyshohet;
        }

        public async Task<ActionResult<bool>> AVezhgohet(int id)
        {
            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            if (dbDeshmitari == null)
                return new NotFoundObjectResult("Dëshmitari nuk ekziston!!");
            return dbDeshmitari.Vezhgohet;
        }

        public async Task<ActionResult> AddDeshmitari(DeshmitariDTO deshmitariDTO)
        {
            if (deshmitariDTO == null)
                return new BadRequestObjectResult("Deshmitari nuk mund të jetë null!!");
            var mappedDeshmitari = _mapper.Map<Deshmitari>(deshmitariDTO);
            await _context.Deshmitaret.AddAsync(mappedDeshmitari);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deshmitari u shtua me sukses!");
        }

        public async Task<ActionResult> UpdateDeshmitari(int id, UpdateDeshmitariDTO updateDeshmitariDTO)
        {
            if (updateDeshmitariDTO == null)
                return new BadRequestObjectResult("Deshmitari nuk mund të jetë null!!");

            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            if (dbDeshmitari == null)
                return new NotFoundObjectResult("Dëshmitari nuk ekziston!!");

            dbDeshmitari.Emri = updateDeshmitariDTO.Emri ?? dbDeshmitari.Emri;
            dbDeshmitari.Gjinia = updateDeshmitariDTO.Gjinia ?? dbDeshmitari.Gjinia;
            dbDeshmitari.Profesioni = updateDeshmitariDTO.Profesioni ?? dbDeshmitari.Profesioni;
            dbDeshmitari.Statusi = updateDeshmitariDTO.Statusi ?? dbDeshmitari.Statusi;
            dbDeshmitari.Vendbanimi = updateDeshmitariDTO.Vendbanimi ?? dbDeshmitari.Vendbanimi;
            dbDeshmitari.GjendjaMendore = updateDeshmitariDTO.GjendjaMendore ?? dbDeshmitari.GjendjaMendore;
            dbDeshmitari.EKaluara = updateDeshmitariDTO.EKaluara ?? dbDeshmitari.EKaluara;
            dbDeshmitari.RaportiMeViktimen = updateDeshmitariDTO.RaportiMeViktimen ?? dbDeshmitari.RaportiMeViktimen;
            dbDeshmitari.Vezhgohet = updateDeshmitariDTO.Vezhgohet ?? dbDeshmitari.Vezhgohet;
            dbDeshmitari.Dyshohet = updateDeshmitariDTO.Dyshohet ?? dbDeshmitari.Dyshohet;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dëshmitari u përditësua me sukses!");
        }

        public async Task<ActionResult> DeleteDeshmitari(int id)
        {
            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            if (dbDeshmitari == null)
                return new NotFoundObjectResult("Dëshmitari nuk ekziston!!");

            _context.Deshmitaret.Remove(dbDeshmitari);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Dëshmitari u fshi me sukses!");
        }

        //Strategy Pattern
        //Metoda GetInfo është metodë e klasës bazë, vetëm se tek kjo nënklasë bëhet override!
        public async override Task<ActionResult<string>> GetInfo(int id)
        {
            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            return dbDeshmitari == null 
                ? "Dëshmitari nuk ekziston!!"
                : $"Deshmitari: Emri -> " +
                dbDeshmitari.Emri + ", Profesioni -> " + dbDeshmitari.Profesioni + ", Vendbanimi -> " + dbDeshmitari.Vendbanimi 
                + ", " + "\nRaporti me viktimen -> " + dbDeshmitari.RaportiMeViktimen + ", A vëzhgohet? " 
                + dbDeshmitari.Vezhgohet + ", A dyshohet? " + dbDeshmitari.Dyshohet + ".";
        }


        //Kjo metodë e bën zhvendosjen e një personi nga Dëshmitar në të dyshuar.
        public async Task<ActionResult> RuajSiIDyshuar(int id)
        {
            var d = await GetDeshmitariById(id);
            if (d is NotFoundObjectResult)
                return d;

            DeshmitariDTO? deshmitari = ((OkObjectResult)d).Value as DeshmitariDTO;
            await DeleteDeshmitari(id);
            iDyshuariDTO dyshuari = ConvertToiDyshuari(deshmitari);
            await AddTeDyshuarin(dyshuari);
            return new OkObjectResult(dyshuari);
        }


        //Kjo metodë thirret nga metoda RuajSiIDyshuar për të konvertuar një dëshmitar në të dyshuar.
        public iDyshuariDTO ConvertToiDyshuari(DeshmitariDTO deshmitari)
        {
            /*Krijohet një objekt i tipit iDyshuariDTO 
             * dhe inicializohet menjëher ashtu që të marr të njëjtat të dhëna si dëshmitari
             * vetëm se Dyshimi duhet të ndryshohet më vonë.             
             */
            iDyshuariDTO dyshuari = new iDyshuariDTO
            {
                Emri = deshmitari.Emri,
                Gjinia = deshmitari.Gjinia,
                Profesioni = deshmitari.Profesioni,
                Statusi = deshmitari.Statusi,
                Vendbanimi = deshmitari.Vendbanimi,
                GjendjaMendore = deshmitari.GjendjaMendore,
                EKaluara = deshmitari.EKaluara,
                Dyshimi = "Dyshimi formulohet ndërkohë..."
            };

            return dyshuari;
        }


        //Kjo metodë thirret nga metoda RuajSiIDyshuar për të shtyar një të dyshuar.
        public async Task AddTeDyshuarin(iDyshuariDTO dyshuari)
        {
            /*
             * Krijohet instancë e klasës iDyshuariService për ta përdorur metoden AddTeDyshuarin
             * ashtu që të mos implementohet logjika e njejt në dy klasa të ndryshme!
             */
            iDyshuariService d = new iDyshuariService(_context, _mapper);
            await d.AddTeDyshuarin(dyshuari);
        }
    }
}