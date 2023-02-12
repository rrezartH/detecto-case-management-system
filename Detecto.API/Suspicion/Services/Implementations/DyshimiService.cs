
using Detecto.API.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Detecto.API.Suspicion.Services.Interfaces;
using Detecto.API.Suspicion.DTOs;
using Detecto.API.Suspicion.Models;

namespace Detecto.API.Suspicion.Services.Implementations
{
    public class DyshimiService : IDyshimiService
   {
    private readonly DetectoDbContext _context;
        public DyshimiService(DetectoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DyshimiDTO>> GetDyshimet()
        {
            var dyshimet = await _context.Dyshimet.ToListAsync();
            return dyshimet.Select(dyshimi => new DyshimiDTO
            {
                Id = dyshimi.Id,
                CaseId = dyshimi.CaseId,
                Title = dyshimi.Title,
                Details = dyshimi.Details,
                DateEqeshtjes = dyshimi.DateEqeshtjes,
                provat = dyshimi.provat,
                personat= dyshimi.personat 

            });
        }

        public async Task<ActionResult<DyshimiDTO>> GetDyshimiByID(int id)
        {
            var dyshimi = await _context.Dyshimet.FindAsync(id);

            if (dyshimi == null)
            {
                throw new ArgumentException("Dyshimi not found");
            }

            return new DyshimiDTO
            {
                Id = dyshimi.Id,
                CaseId = dyshimi.CaseId,
                Title = dyshimi.Title,
                Details = dyshimi.Details,
                DateEqeshtjes = dyshimi.DateEqeshtjes,
                provat = dyshimi.provat,
                personat = dyshimi.personat
            };
        }

        public async Task<ActionResult<DyshimiDTO>> UpdateDyshimi(UpdateDyshimiDTO dyshimi, int id)
        {
            var originalDyshimi = await _context.Dyshimet.FindAsync(id);

            if (originalDyshimi == null)
            {
                throw new ArgumentException("Dyshimi not found");
            }

            originalDyshimi.Title = dyshimi.Title;
            originalDyshimi.Details = dyshimi.Details;
            originalDyshimi.provat = dyshimi.provat;
            originalDyshimi.personat = dyshimi.personat;

            _context.Dyshimet.Update(originalDyshimi);
            await _context.SaveChangesAsync();
            return new OkObjectResult("dyshimi updated succesfully!");

        }

        public async Task<ActionResult> DeleteDyshimi(int id)
        {
            var originalDyshimi = await _context.Dyshimet.FindAsync(id);

            if (originalDyshimi == null)
            {
                throw new ArgumentException("Dyshimi not found");

            }

            _context.Dyshimet.Remove(originalDyshimi);
            await _context.SaveChangesAsync();
            return new OkObjectResult("dyshimi deleted succesfully!");
        }

        public async Task<ActionResult<DyshimiDTO>> CreateDyshimi(DyshimiDTO dyshimi)
        {
            var newDyshimi = new Dyshimi
            {
                CaseId = dyshimi.CaseId,
                Title = dyshimi.Title,
                Details = dyshimi.Details,
                DateEqeshtjes = dyshimi.DateEqeshtjes,
                provat = dyshimi.provat,
                personat= dyshimi.personat 
            };

            _context.Dyshimet.Add(newDyshimi);
            await _context.SaveChangesAsync();
            return new OkObjectResult("dyshimi created succesfully!");

        }
    }
}
