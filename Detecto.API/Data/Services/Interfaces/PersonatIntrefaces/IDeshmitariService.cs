﻿using Detecto.API.Data.DTOs.PersonatDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces.PersonatIntrefaces
{
    public interface IDeshmitariService
    {
        public Task<ActionResult<List<DeshmitariDTO>>> GetDeshmitaret();
        public Task<ActionResult> GetDeshmitariById(int id);
        public Task<ActionResult> AddDeshmitari(DeshmitariDTO deshmitariDTO);
        public Task<ActionResult> UpdateDeshmitari(int id, UpdateDeshmitariDTO updateDeshmitariDTO);
        public Task<ActionResult> DeleteDeshmitari(int id);
    }
}