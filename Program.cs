using net_ef_videogame;
using net_ef_videogame.Models;
using net_ef_videogame.Manager;
using Microsoft.EntityFrameworkCore;

var manager = new VideogameManagerEF();

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
                manager.AddSoftwareHouse(software_house);
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
                manager.AddVideogame(videogame);
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
            var id = Convert.ToInt32(Console.ReadLine());
            var videogameSearchedById = manager.GetVideogameById(id);
            Console.WriteLine(videogameSearchedById);
            break;

        case "4":
            Console.WriteLine("Search a videogame by name:");
            var nameQuery = Console.ReadLine();
            var videogamesSearchedByName = manager.GetVideogameByNameLike(nameQuery);
            foreach (Videogame searchedVideogame in videogamesSearchedByName)
            {
                Console.WriteLine(searchedVideogame);
            }
            break;

        case "5":
            Console.WriteLine("Search a videogame by software house's ID:");
            var idSh = Convert.ToInt32(Console.ReadLine());
            var videogamesSearchedBySHId = manager.GetVideogameBySoftwareHouseId(idSh);


            foreach (Videogame searchedVideogame in videogamesSearchedBySHId)
            {
                Console.WriteLine(searchedVideogame);
            }
            break;

        case "6":
            Console.WriteLine("Delete a videogame by Id:");
            var IdForDelete = Convert.ToInt32(Console.ReadLine());

            try
            {
                manager.DeleteVideogameById(IdForDelete);
                Console.WriteLine("Videogame successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            break;

        default:
            Console.WriteLine("Invalid choice, please try again.");
            break;
    }
}