﻿using AutoMapper;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation
{
    public class GjurmaBiologjikeService : IGjurmaBiologjikeService
    {
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;

        public GjurmaBiologjikeService(DetectoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> GetGjurmetBiologjike()
        {
            return _mapper.Map<List<GjurmaBiologjikeDTO>>(await _context.GjurmetBiologjike.ToListAsync());
        }

        public async Task<ActionResult<GjurmaBiologjikeDTO>> GetGjurmaBiologjikeById(int id)
        {
            var mappedGjurma = _mapper.Map<GjurmaBiologjikeDTO>(await _context.GjurmetBiologjike.FindAsync(id));
            if (mappedGjurma == null)
                return new NotFoundObjectResult("Gjurma nuk ekziston.");
            return new OkObjectResult(mappedGjurma);
        }

        public async Task<ActionResult<List<GjurmaBiologjikeDTO>>> GetGjurmetEPersonit(int id)
        {
            var dbPersoni = await _context.Personat.FindAsync(id);
            if (dbPersoni == null)
                return new NotFoundObjectResult("Personi nuk ekziston!!");

            return _mapper.Map<List<GjurmaBiologjikeDTO>>(await _context.GjurmetBiologjike
                                .Where(p => p.PersoniId == id)
                                .ToListAsync());
        }

        public async Task<ActionResult> AddGjurmaBiologjike(GjurmaBiologjikeDTO gjurmaBiologjikeDTO)
        {
            if (gjurmaBiologjikeDTO == null)
                return new BadRequestObjectResult("Gjurma can't be null!");
            var mappedGjurma = _mapper.Map<ProvaBiologjike>(gjurmaBiologjikeDTO);
            await _context.ProvatBiologjike.AddAsync(mappedGjurma);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Gjurma added succesfully!");
        }

        public async Task<ActionResult> UpdateGjurmaBiologjike(int id, UpdateGjurmaBiologjikeDTO updateGjurmaBiologjikeDTO)
        {
            if (updateGjurmaBiologjikeDTO == null)
                return new BadRequestObjectResult("Gjurma nuk mund të jetë null!!");

            var dbGjurma = await _context.GjurmetBiologjike.FindAsync(id);
            if (dbGjurma == null)
                return new NotFoundObjectResult("Gjurma nuk ekziston!!");

            dbGjurma.Emertimi = updateGjurmaBiologjikeDTO.Emertimi ?? dbGjurma.Emertimi;
            dbGjurma.Lloji = updateGjurmaBiologjikeDTO.Lloji ?? dbGjurma.Lloji;
            await _context.SaveChangesAsync();

            return new OkObjectResult("Gjurma updated succesfully!");
        }

        public async Task<ActionResult> DeleteGjurmenBiologjike(int id)
        {
            var dbGjurma = await _context.GjurmetBiologjike.FindAsync(id);
            if (dbGjurma == null)
                return new NotFoundObjectResult("Gjurma nuk ekziston!!");

            _context.GjurmetBiologjike.Remove(dbGjurma);
            await _context.SaveChangesAsync();
            return new OkObjectResult("Gjurma deleted succesfully!");
        }
    }
}
