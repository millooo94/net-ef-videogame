using net_ef_videogame.Models;
using Microsoft.EntityFrameworkCore;

using var context = new VideogamesContext();

var softwareHouse = new SoftwareHouse { Name = "Santa Monica Studio", TaxId = 1};

context.SoftwareHouses.Add(softwareHouse);
context.SaveChanges();

var softwareHouseId = softwareHouse.Id;

var videogame1 = new Videogame { Name = "God Of War", SoftwareHouseId = softwareHouseId };
context.Videogames.Add(videogame1);
context.SaveChanges();

var videogame2 = new Videogame { Name = "okokok", SoftwareHouseId = softwareHouseId };
context.Videogames.Add(videogame2);
context.SaveChanges();

var videogames = context.Videogames
                .Where(v => v.SoftwareHouseId == 15)
                .ToList();

foreach (var v in videogames)
{
    Console.WriteLine(v.Name);
}