using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    public record VideogameManagerEF : VideogameManager
    {
        private readonly VideogamesContext? context;

        public VideogameManagerEF()
        {
            context = new VideogamesContext();
        }

        public override void AddSoftwareHouse(SoftwareHouse softwareHouse)
        {
            context.SoftwareHouses.Add(softwareHouse);
            context.SaveChanges();
        }
        public override void AddVideogame(Videogame videogame)
        {
            context.Videogames.Add(videogame);
            context.SaveChanges();
        }
        public override List<Videogame> GetVideogameById(int id)
        {
            var videogameSearchedById = context.Videogames.Where(v => v.Id == id);
            return videogameSearchedById.ToList();
        }
        public override List<Videogame> GetVideogameByNameLike(string nameQuery)
        {
            var videogamesSearchedByName = context.Videogames.Where(item => item.Name.Contains(nameQuery));
            return videogamesSearchedByName.ToList();
        }
        public override List<Videogame> GetVideogameBySoftwareHouseId(int id)
        {
            var videogamesSearchedSh = context.Videogames.Include(v => v.SoftwareHouse).Where(v => v.SoftwareHouseId == id);
            return videogamesSearchedSh.ToList();
        }
        public override void deleteVideogameById(int id)
        {
            var videogamesToDelete = context.Videogames.Where(v => v.Id == id).ToList();
            context.Videogames.RemoveRange(videogamesToDelete);
            context.SaveChanges();
        }
    }
}
