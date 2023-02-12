using Detecto.API.Data.Models;

namespace Detecto.API.Suspicion.Models
{
    public class PersoniDyshimi:Personi
    {
        public int PersoniID { get; set; }
        public string akuzat { get; set; }
        public bool pafajsia { get; set; }
        public string roliNeHetim { get; set; }
    }
}
