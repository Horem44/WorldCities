using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCities.Core.DTO.Cities.Requests
{
    public class CityAddRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Lat { get; set; }

        [Required]
        public decimal Lon { get; set; }

        [Required]
        public Guid CountryGuid {  get; set; }
    }
}
