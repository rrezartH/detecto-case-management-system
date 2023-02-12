using Detecto.API.Suspicion.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Suspicion.Services.Interfaces
{
    public interface IDyshimiService
    {
        public Task<IEnumerable<DyshimiDTO>> GetDyshimet();
        public Task<ActionResult<DyshimiDTO>> GetDyshimiByID(int id);
        public Task<ActionResult<DyshimiDTO>> CreateDyshimi(DyshimiDTO dyshimi);
        public Task<ActionResult<DyshimiDTO>> UpdateDyshimi(UpdateDyshimiDTO dyshimi, int id);
        public Task<ActionResult> DeleteDyshimi(int id);
    }
}
