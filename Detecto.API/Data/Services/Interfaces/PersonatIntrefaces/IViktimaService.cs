using Detecto.API.Data.DTOs.PersonatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface IViktimaService
    {
        public Task<ActionResult<List<ViktimaDTO>>> GetViktimat();
        public Task<ActionResult> GetViktimaById(int id);
        public Task<ActionResult> AddViktima(ViktimaDTO viktimaDTO);
        public Task<ActionResult> UpdateViktima(int id, UpdateViktimaDTO updateViktimaDTO);
        public Task<ActionResult> DeleteViktima(int id);
        public Task<ActionResult<string>> GetInfo(int id);
    }
}
