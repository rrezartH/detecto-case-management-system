﻿using Detecto.API.Data.DTOs;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Data.Controllers.PersonatControllers
{
    [Route("api/Data/[controller]")]
    [ApiController]
    public class PersoniController
    {
        private readonly IPala _pala;

        public PersoniController(IPala pala)
        {
            _pala = pala;
        }

        [HttpGet("deklaratat-e-personit/{id}")]
        public async Task<ActionResult<List<DeklarataDTO>>> GetDeklaratatEPersonit(int id)
        {
            return await _pala.GetDeklaratatEPersonit(id);
        }

        [HttpPost("deklaraten")]
        public async Task<ActionResult> AddDeklarata(DeklarataDTO deklarataDTO)
        {
            return await _pala.AddDeklarata(deklarataDTO);
        }

        [HttpPut("deklaraten/{id}")]
        public async Task<ActionResult> UpdateDeklarata(int id, UpdateDeklarataDTO updateDeklarataDTO)
        {
            return await _pala.UpdateDeklarata(id, updateDeklarataDTO);
        }

        [HttpOptions("KrahasoDeklaratat")]
        public async Task<string> Compare(int d1Id, int d2Id)
        {
            return await _pala.Compare(d1Id, d2Id);
        }
    }
}
