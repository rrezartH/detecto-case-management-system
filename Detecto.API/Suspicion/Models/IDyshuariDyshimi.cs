using Detecto.API.Data.DTOs.PersonatDTOs;
using Detecto.API.Data.Models;
using Detecto.API.Data.Services.Interfaces.PersonatIntrefaces;
using Microsoft.AspNetCore.Mvc;

namespace Detecto.API.Suspicion.Models
{
    public class IDyshuariDyshimi : iDyshuari
    {
        //public int Id { get; set; }
        public int PersoniID { get; set; }
        public int CaseID { get; set; }
        public bool DyshimIAutomatizuar { get; set; }
        public string Arsyeja { get; set; }
        public int Propabiliteti { get; set; }

       
    }

}
