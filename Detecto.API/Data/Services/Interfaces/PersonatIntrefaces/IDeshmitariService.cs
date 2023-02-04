using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface IDeshmitariService : IGetInfo
    {
        public Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret();
        public Task<ActionResult> GetDeshmitariById(int id);
        public Task<ActionResult<bool>> ADyshohet(int id);
        public Task<ActionResult<bool>> AVezhgohet(int id);
        public Task<ActionResult> AddDeshmitari(DeshmitariDTO deshmitariDTO);
        public Task<ActionResult> UpdateDeshmitari(int id, UpdateDeshmitariDTO updateDeshmitariDTO);

        public Task<ActionResult> RuajSiIDyshuar(int id);
    }
}