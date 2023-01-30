using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.ProvatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.ProvatInterfaces
{
    public interface IProvaBiologjikeService
    {
        public Task<ActionResult<List<ProvaBiologjikeDTO>>> GetProvatBiologjike();
        public Task<ActionResult> GetProvenBiologjikeById(int id);
        public Task<ActionResult> AddProvaBiologjike(ProvaBiologjikeDTO provaDTO);
        public Task<ActionResult> UpdateProvaBiologjike(int id, UpdateProvaBiologjikeDTO updateProvaDTO);
        public Task<ActionResult> DeleteProvaBiologjike(int id);

        public Task<ActionResult<List<GjurmaBiologjikeDTO>>> Krahaso(int provaId, int personiId);
    }
}
