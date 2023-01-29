using Detecto.API.Data.DTOs.ProvatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.ProvatInterfaces
{
    public interface IProvaService
    {
        public Task<ActionResult<List<ProvaDTO>>> GetProvat();
        public Task<ActionResult> GetProvaById(int id);
    }
}
