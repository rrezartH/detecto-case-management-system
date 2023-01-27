using Detecto.API.Data.DTOs.ProvatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.ProvatInterfaces
{
    public interface IProvaFizikeService
    {
        public Task<ActionResult<List<ProvaFizikeDTO>>> GetProvatFizike();
        public Task<ActionResult> GetProvenFizikeById(int id);
        public Task<ActionResult> AddProvaFizike(ProvaFizikeDTO provaDTO);
        public Task<ActionResult> UpdateProvaFizike(int id, UpdateProvaFizikeDTO updateProvaDTO);
        public Task<ActionResult> DeleteProvaFizike(int id);
    }
}
