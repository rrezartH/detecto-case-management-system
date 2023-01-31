using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface GetInfo
    {
        //Strategy Pattern
        public Task<ActionResult<string>> GetInfo(int id);
    }
}
