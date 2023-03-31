using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public abstract record VideogameManager
    {
        public abstract void AddSoftwareHouse(SoftwareHouse softwareHouse);
        public abstract void AddVideogame(Videogame videogame);
        public abstract List<Videogame> GetVideogameById(int id);
        public abstract List<Videogame> GetVideogameByNameLike(string nameQuery);
        public abstract List<Videogame> GetVideogameBySoftwareHouseId(int id);
        public abstract void deleteVideogameById(int id);
    }
}
