using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation
{
    public class DeklarataService : IDeklarataService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;

        public DeklarataService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat() =>
            _mapper.Map<List<DeklarataDTO>>(await _context.Deklaratat.ToListAsync());

        public async Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id)
        {
            var mappedDeklarata = _mapper.Map<DeklarataDTO>(await _context.Deklaratat.FindAsync(id));
            return mappedDeklarata == null 
                ? new NotFoundObjectResult("Deklarata nuk ekziston!!")
                : new OkObjectResult(mappedDeklarata);
        }

        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id)
        {
            var dbPersoni = await _context.Personat.FindAsync(id);
            return dbPersoni == null 
                ? new NotFoundObjectResult("Personi nuk ekziston!!")
                : _mapper.Map<List<DeklarataDTO>>(await _context.Deklaratat
                                .Where(p => p.PersoniId == id)
                                .ToListAsync());
        }

        public async Task<ActionResult<string>> GetPerbajtjaEDeklarates(int id)
        {
            var dbPermbajtja = await _context.Deklaratat.FindAsync(id);
            return dbPermbajtja == null
                ? new NotFoundObjectResult("Deklarata nuk ekziston!!")
                : dbPermbajtja.Permbajtja;
        }

        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            if (deklarataDTO == null)
                return new BadRequestObjectResult("Deklarata nuk mund të jetë null!!");
            var mappedDeklarata = _mapper.Map<Deklarata>(deklarataDTO);
            await _context.Deklaratat.AddAsync(mappedDeklarata);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deklarata u shtua me sukses!");
        }

        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO)
        {
            if (updateDeklarataDTO == null)
                return new BadRequestObjectResult("Deklarata nuk mund të jetë null!!");

            var dbDeklarata = await _context.Deklaratat.FindAsync(id);
            if (dbDeklarata == null)
                return new NotFoundObjectResult("Deklarata nuk ekziston!!");

            dbDeklarata.KohaEMarrjes = updateDeklarataDTO.KohaEMarrjes ?? dbDeklarata.KohaEMarrjes;
            dbDeklarata.Permbajtja = updateDeklarataDTO.Permbajtja ?? dbDeklarata.Permbajtja;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Deklarata u përditësua me sukses!");
        }

        public async Task<ActionResult> DeleteDeklarata(int id)
        {
            var dbDeklarata = await _context.Deklaratat.FindAsync(id);
            if (dbDeklarata == null)
                return new NotFoundObjectResult("Deklarata nuk ekziston!!");

            _context.Deklaratat.Remove(dbDeklarata);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Deklarata u fshi me sukses!");
        }

        /*public string Compare(string deklarata1, string deklarata2)
        {
            KrahasoTekst kT = new KrahasoTekst();
            return kT.Compare(deklarata1, deklarata2);
        }*/
    }
}
