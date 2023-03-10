using Detecto.API.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces
{
    public interface IDeklarataService
    {
        public Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat();
        public Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id);
        public Task<ActionResult<string>> GetPerbajtjaEDeklarates(int id);
        public Task<ActionResult> DeleteDeklarata(int id);
        public Task<string> Compare(int d1Id, int d2Id);
    }
}
