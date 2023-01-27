using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation.PersonatServices
{
    public class DeshmitariService : IDeshmitariService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public DeshmitariService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret()
        {
            return _mapper.Map<List<DeshmitariDTO>>(await _context.Deshmitaret.ToListAsync());
        }

        public async Task<ActionResult> GetDeshmitariById(int id)
        {
            var mappedDeshmitari = _mapper.Map<DeshmitariDTO>(await _context.Deshmitaret.FindAsync(id));
            if (mappedDeshmitari == null)
                return new NotFoundObjectResult("Deshmitari nuk ekziston!!");
            return new OkObjectResult(mappedDeshmitari);
        }

        public async Task<ActionResult> AddDeshmitari(DeshmitariDTO deshmitariDTO)
        {
            if (deshmitariDTO == null)
                return new BadRequestObjectResult("Deshmitari can't be null!");
            var mappedDeshmitari = _mapper.Map<Deshmitari>(deshmitariDTO);
            await _context.Deshmitaret.AddAsync(mappedDeshmitari);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deshmitari added succesfully!");
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
            dbDeshmitari.EKaluara = updateDeshmitariDTO.eKaluara ?? dbDeshmitari.EKaluara;
            dbDeshmitari.RaportiMeViktimen = updateDeshmitariDTO.RaportiMeViktimen ?? dbDeshmitari.RaportiMeViktimen;
            dbDeshmitari.Vezhgohet = updateDeshmitariDTO.Vezhgohet ?? dbDeshmitari.Vezhgohet;
            dbDeshmitari.Dyshohet = updateDeshmitariDTO.Dyshohet ?? dbDeshmitari.Dyshohet;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Dëshmitari updated succesfully!");
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
    }
}
