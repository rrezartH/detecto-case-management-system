using Detecto.API.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces
{
    public interface IGjurmaBiologjikeService
    {
        public Task<ActionResult<List<GjurmaBiologjikeDTO>>> GetGjurmetBiologjike();
        public Task<ActionResult<GjurmaBiologjikeDTO>> GetGjurmaBiologjikeById(int id);
        public Task<ActionResult> AddGjurmaBiologjike(GjurmaBiologjikeDTO gjurmaBiologjikeDTO);
        public Task<ActionResult> UpdateGjurmaBiologjike(int id, UpdateGjurmaBiologjikeDTO updateGjurmaBiologjikeDTO);
        public Task<ActionResult> DeleteGjurmenBiologjike(int id);
    }
}
