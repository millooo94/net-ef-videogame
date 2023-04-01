using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Manager
{
    public abstract record VideogameManager
    {
        public abstract void AddSoftwareHouse(SoftwareHouse softwareHouse);
        public abstract void AddVideogame(Videogame videogame);
        public abstract Videogame GetVideogameById(int id);
        public abstract List<Videogame> GetVideogameByNameLike(string nameQuery);
        public abstract List<Videogame> GetVideogameBySoftwareHouseId(int id);
        public abstract void DeleteVideogameById(int id);
    }
}
