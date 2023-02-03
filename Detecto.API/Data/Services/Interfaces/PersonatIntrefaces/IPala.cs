using Detecto.API.Data.DTOs;
using Detecto.API.Data.DTOs.PersonatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface IPala
    {
        public Task<ICollection<ViktimaDTO>> GetViktimat(int caseId);
        public Task<ICollection<DeshmitariDTO>> GetDeshmitaret(int caseId);
        public Task<ICollection<iDyshuariDTO>> GetTeDyshuarit(int caseId);
        public Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id);
        public Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO);
        public Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO);
        public Task<string> Compare(int d1Id, int d2Id);
    }
}
