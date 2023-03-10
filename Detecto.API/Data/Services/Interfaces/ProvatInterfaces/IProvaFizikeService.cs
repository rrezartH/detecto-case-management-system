using Detecto.API.Data.DTOs.ProvatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.ProvatInterfaces
{
    public interface IProvaFizikeService
    {
        public Task<ActionResult<List<ProvaFizikeDTO>>> GetProvatFizike();
        public Task<ActionResult> GetProvenFizikeById(int id);
        public Task<ActionResult<List<ProvaFizikeDTO>>> GetPerEkzaminim(bool b);
        public Task<ActionResult<List<ProvaFizikeDTO>>> GetMeGjurmeBiologjike(bool b);
        public Task<ActionResult<List<ProvaFizikeDTO>>> GetSipasRrezikut(string str);
        public Task<ActionResult> AddProvaFizike(ProvaFizikeDTO provaDTO);
        public Task<ActionResult> UpdateProvaFizike(int id, UpdateProvaFizikeDTO updateProvaDTO);
    }
}
