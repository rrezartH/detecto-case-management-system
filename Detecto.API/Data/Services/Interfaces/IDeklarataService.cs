﻿using Detecto.API.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Services.Interfaces
{
    public interface IDeklarataService
    {
        public Task<ActionResult<List<DeklarataDTO>>> GetDeklaratat();
        public Task<ActionResult<DeklarataDTO>> GetDeklarataById(int id);
        public Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO);
        public Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO);
        public Task<ActionResult> DeleteDeklarata(int id);
    }
}
