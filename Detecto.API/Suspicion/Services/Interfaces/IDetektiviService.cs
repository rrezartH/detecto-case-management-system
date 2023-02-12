using Detecto.API.Suspicion.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Suspicion.Services.Interfaces
{
    public interface IDetektiviService
    {
        public Task<IEnumerable<DetektiviDTO>> GetDetektivet();
        public Task<ActionResult<DetektiviDTO>> GetDetektiviByID(int id);
        public Task<ActionResult<DetektiviDTO>> UpdateHulumtimi(UpdateHulumtimiDTO hulumtimi, int id);
    }
}
