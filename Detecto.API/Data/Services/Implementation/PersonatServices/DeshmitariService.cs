using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
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

        public async Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret()
        {
            var deshmitaret = await _context.Deshmitaret.ToListAsync();
            if (!deshmitaret.Any())
                return new NotFoundObjectResult("Nuk ka Deshmitare te regjistruar!");

            var mappedDeshmitaret = _mapper.Map<List<DeshmitariDTO>>(deshmitaret);

            foreach (var mappedDeshmitari in mappedDeshmitaret)
            {
                var id = mappedDeshmitari.Id;
                var deklaratat = _context.Deklaratat.Where(d => d.PersoniId == id).ToList();
                mappedDeshmitari.Deklaratat = _mapper.Map<List<DeklarataDTO>>(deklaratat);
                var gjurmet = _context.GjurmetBiologjike.Where(g => g.PersoniId == id).ToList();
                mappedDeshmitari.GjurmetBiologjike = _mapper.Map<List<GjurmaBiologjikeDTO>>(gjurmet);
            }

            return new OkObjectResult(mappedDeshmitaret);
        }

        public async Task<ActionResult> GetDeshmitariById(int id)
        {
            var deshmitari = await _context.Deshmitaret.FindAsync(id);
            if (deshmitari == null)
                return new NotFoundObjectResult("Deshmitari nuk ekziston!!");

            var mappedDeshmitari = _mapper.Map<DeshmitariDTO>(deshmitari);
            var deklaratat = _context.Deklaratat.Where(d => d.PersoniId == id).ToList();
            mappedDeshmitari.Deklaratat = _mapper.Map<List<DeklarataDTO>>(deklaratat);
            var gjurmet = _context.GjurmetBiologjike.Where(g => g.PersoniId == id).ToList();
            mappedDeshmitari.GjurmetBiologjike = _mapper.Map<List<GjurmaBiologjikeDTO>>(gjurmet);

            return new OkObjectResult(mappedDeshmitari);
        }

        public async Task<ActionResult<bool>> ADyshohet(int id)
        {
            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            if (dbDeshmitari == null)
                return new NotFoundObjectResult("Dëshmitari nuk ekziston!!");
            return dbDeshmitari.Dyshohet;
        }

        private async Task SetDyshohet(int id)
        {
            var dbDeshmitari = await _context.Deshmitaret.FindAsync(id);
            if (dbDeshmitari == null)
                 return;
            dbDeshmitari.Dyshohet = true;
            await _context.SaveChangesAsync();
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

        /*
         * Strategy Pattern
         * Metoda GetInfo është metodë e interface-it GetInfo. 
         * Përmes kësaj metode arrijmë të implementojmë Strategy Patternin.
         */
        public async Task<ActionResult<string>> GetInfo(int id)
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
            await SetDyshohet(id);
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
            iDyshuariDTO dyshuari = new ()
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
            iDyshuariService d = new(_context, _mapper);
            await d.AddTeDyshuarin(dyshuari);
        }
    }
}