using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.DTOs.Requests
{
    public class AddOrderReq
    {
        [Required]
        public DateTime dataPrzyjecia { get; set; }
        [Required]
        public int IdZamowienia { get; set; }
        [Required]
        public DateTime DataRealizacji { get; set; }
        [Required]
        public int IdPracownik { get; set; }

        [Required]
        public ICollection<WyrobReq> wyroby { get; set; }
    }
}
