using Abp.Domain.Uow;
using AutoMapper;
using Detecto.API.Case.DTOs;
using Detecto.API.Configurations;
using Detecto.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Detecto.API.Data
{
    public class ViktimaService
    {
        //public IUnitOfWork _unitOfWork;
        private readonly DetectoDbContext _context;
        private readonly IMapper _mapper;
        public ViktimaService(DetectoDbContext context, IMapper mapper/*, IUnitOfWork _unitOfWork*/)
        {
            _context = context;
            _mapper = mapper;
            /*_unitOfWork = _unitOfWork;*/
        }
                                            //ViktimaDTO
        public async Task<ActionResult<List<Viktima>>> GetViktimat()
        {                           //ViktimaDTO
            return _mapper.Map<List<Viktima>>(await _context.Viktimat.ToListAsync());
        }

        /*public async void AddViktima(ViktimaDTO viktima)
        {
            var _mapped = _mapper.Map<Viktima>(viktima);

            await _unitOfWork.Viktimat.Add(_mapped);
            await _unitOfWork.CompleteAsync();
        }*/
    }
}
