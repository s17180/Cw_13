using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.DTOs.Requests
{
    public class WyrobReq
    {
        [Required]
        public int ilosc { get; set; }
        [Required]
        public string wyrob { get; set; }
        public string uwagi { get; set; }
    }
}
