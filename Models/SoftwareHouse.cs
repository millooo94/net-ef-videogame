using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace net_ef_videogame.Models
{
    public class SoftwareHouse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? TaxId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Videogame>? Videogames { get; set; }
    }
}
