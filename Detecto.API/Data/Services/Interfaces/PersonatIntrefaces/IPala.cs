using Detecto.API.Data.DTOs.PersonatDTOs;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface IPala
    {
        public Task<ICollection<ViktimaDTO>> GetViktimat(int caseId);
        public Task<ICollection<DeshmitariDTO>> GetDeshmitaret(int caseId);
        public Task<ICollection<iDyshuariDTO>> GetTeDyshuarit(int caseId);
    }
}
