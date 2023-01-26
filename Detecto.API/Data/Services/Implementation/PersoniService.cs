using AutoMapper;
using Castle.Core.Internal;
using Castle.Core.Resource;
using Detecto.API.Configurations;
using Detecto.API.Data.DTOs;
using Detecto.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data.Services.Implementation
{
    public class PersoniService
    {
        private static Dictionary<string, Personi> personi =
            new Dictionary<string, Personi>();


        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public PersoniService(DetectoDbContext context, IMapper mapper)
        {
            personi.Add("Viktima", new Viktima());
            personi.Add("Deshmitari", new Deshmitari());

            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<PersoniDTO>>> GetPersonat()
        {
            return _mapper.Map<List<PersoniDTO>>(await _context.Personat.ToListAsync());
        }

        public async Task<ActionResult> AddPersoni(PersoniDTO personiDTO, string typePerson)
        {
            if (personiDTO == null)
                return new BadRequestObjectResult("Personi can't be null!");
            if(typePerson == "Viktima")
            {
                var mappedPersoni = _mapper.Map<Viktima>(personiDTO);
                await _context.Viktimat.AddAsync(mappedPersoni);
            }
            else if(typePerson == "Deshmitari")
            {
                var mappedPersoni = _mapper.Map<Deshmitari>(personiDTO);
                await _context.Deshmitaret.AddAsync(mappedPersoni);
            }
            await _context.SaveChangesAsync();
            return new OkObjectResult("Personi u shtua me sukses!");
        }
    }
}
