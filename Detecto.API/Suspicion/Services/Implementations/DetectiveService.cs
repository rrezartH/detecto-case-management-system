using Detecto.API.Configurations;
using Detecto.API.Suspicion.DTOs;
using Detecto.API.Suspicion.Models;
using Detecto.API.Suspicion.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Suspicion.Services.Implementations
{
    public class DetectiveService : IDetektiviService
    {
        private readonly DetectoDbContext _context;
        public DetectiveService(DetectoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DetektiviDTO>> GetDetektivet()
        {
            var detektivet = await _context.Detektivet.ToListAsync();
            return detektivet.Select(detektivi => new DetektiviDTO
            {
                Id = detektivi.Id,
                Name= detektivi.Name,
                Surname= detektivi.Surname,
                Hulumtimi= detektivi.Hulumtimi,

            });
        }

        public async Task<ActionResult<DetektiviDTO>> GetDetektiviByID(int id)
        {
            var detektivi = await _context.Detektivet.FindAsync(id);

            if (detektivi == null)
            {
                throw new ArgumentException("Detektivi not found");
            }

            return new DetektiviDTO
            {
                Id = detektivi.Id,
                Name = detektivi.Name,
                Surname = detektivi.Surname,
                Hulumtimi = detektivi.Hulumtimi,
            };
        }

        public async Task<ActionResult<DetektiviDTO>> UpdateHulumtimi(UpdateHulumtimiDTO hulumtimi, int id)
       {
            var originalDetektivi = await _context.Detektivet.FindAsync(id);

            if (originalDetektivi == null)
            {
                throw new ArgumentException("Detektivi not found");
            }

            originalDetektivi.Hulumtimi = hulumtimi.Hulumtimi;
           
            _context.Detektivet.Update(originalDetektivi);
            await _context.SaveChangesAsync();
            return new OkObjectResult("detektivi updated succesfully!");
        }
    }
}
