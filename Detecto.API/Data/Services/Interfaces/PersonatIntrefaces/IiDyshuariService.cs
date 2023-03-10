using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface IiDyshuariService : IGetInfo
    {
        public Task<ActionResult<List<iDyshuariDTO>>> GetTeDyshuarit();
        public Task<ActionResult> GetTeDyshuarinById(int id);
        public Task<ActionResult<string>> GetDyshimiMbiTeDyshuarin(int id);
        public Task<ActionResult> AddTeDyshuarin(iDyshuariDTO iDyshuariDto);
        public Task<ActionResult> UpdateTeDyshuarin(int id, UpdateiDyshuariDTO updateiDyshuariDto);
    }
}
