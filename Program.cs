using net_ef_videogame.Models;
using Microsoft.EntityFrameworkCore;

using var context = new VideogamesContext();

while (true)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Insert a new software house");
    Console.WriteLine("2. Insert a new videogame");
    Console.WriteLine("3. Search a videogame by ID");
    Console.WriteLine("4. Videogame advanced research");
    Console.WriteLine("5. Search a videogame by software house's ID");
    Console.WriteLine("6. Delete a videogame by ID");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter the name of the software house: ");
            var nameSh = Console.ReadLine();
            Console.Write("Enter the city of the software house: ");
            var city = Console.ReadLine();
            Console.Write("Enter the country of the software house: ");
            var country = Console.ReadLine();
            Console.Write("Enter the tax ID of the software house: ");
            var taxId = Convert.ToInt32(Console.ReadLine());
            var software_house = new SoftwareHouse { Name = nameSh, City = city, Country = country, TaxId = taxId };

            try
            {
                context.SoftwareHouses.Add(software_house);
                context.SaveChanges();
                Console.WriteLine("Software house inserita con successo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(software_house);
            break;

        case "2":
            Console.Write("Enter the name of the videogame: ");
            var nameVg = Console.ReadLine();
            Console.Write("Enter the overview of the videogame: ");
            var overview = Console.ReadLine();
            Console.Write("Enter the release date of the videogame (yyyy-mm-dd): ");
            var releaseDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the software house ID: ");
            var softwareHouseId = Convert.ToInt32(Console.ReadLine());
            var videogame = new Videogame { Name = nameVg, Description = overview, ReleaseDate = releaseDate, SoftwareHouseId = softwareHouseId };

            try
            {
                context.Videogames.Add(videogame);
                context.SaveChanges();
                Console.WriteLine("Videogioco inserito con successo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(videogame);
            break;

        case "3":
            Console.Write("Search a videogame by ID: ");
            var id = Convert.ToInt64(Console.ReadLine());
            var videogameSearchedById = context.Videogames
                .Where(v => v.Id== id)
                .ToList();
            foreach (var item in videogameSearchedById)
            {
                Console.WriteLine(item);
            }
            break;

        case "4":
            Console.WriteLine("Search a videogame by name:");
            var nameQuery = Console.ReadLine();
            var videogamesSearchedByName = context.Videogames.Where(item => item.Name.Contains(nameQuery));
            foreach (Videogame item in videogamesSearchedByName)
            {
                Console.WriteLine(item);
            }
            break;

        case "5":
            Console.WriteLine("Search a videogame by software house's ID:");
            var idSh = Convert.ToInt32(Console.ReadLine());
            var videogamesSearchedSh = context.Videogames.Where(item => item.Id == idSh);
            foreach (Videogame item in videogamesSearchedSh)
            {
                Console.WriteLine(item);
            }
            break;

        case "6":
            Console.WriteLine("Delete a videogame by Id:");
            var IdForDelete = Convert.ToInt32(Console.ReadLine());
            var videogamesToDelete = context.Videogames
                            .Where(v => v.Id == IdForDelete)
                            .ToList();
            try
            {
                context.Videogames.RemoveRange(videogamesToDelete);
                context.SaveChanges();
                Console.WriteLine("Videogame successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;

        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}