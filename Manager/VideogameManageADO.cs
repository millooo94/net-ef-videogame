using Microsoft.Data.SqlClient;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace net_ef_videogame.Manager
{
    public record VideogameManagerADO : VideogameManager
    {
        string connStr;

        public VideogameManagerADO(string connStr)
        {
            this.connStr = connStr;
        }

        public override void AddSoftwareHouse(SoftwareHouse softwareHouse)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "INSERT INTO SoftwareHouses (Name, TaxId, City, Country)" +
                            "VALUES (@Name, @TaxId, @City, @Country)";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", softwareHouse.Name);
                cmd.Parameters.AddWithValue("@TaxId", softwareHouse.TaxId);
                cmd.Parameters.AddWithValue("@City", softwareHouse.City);
                cmd.Parameters.AddWithValue("@Country", softwareHouse.Country);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The videogame was successfully stored");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override void AddVideogame(Videogame videogame)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "INSERT INTO Videogames (Videogames.Name, VideoGames.Description, Videogames.ReleaseDate, Videogames.SoftwareHouseId)" +
                            "VALUES (@Name, @Overview, @ReleaseDate, @SoftwareHouseId)";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", videogame.Name);
                cmd.Parameters.AddWithValue("@Overview", videogame.Description);
                cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                cmd.Parameters.AddWithValue("@SoftwareHouseId", videogame.SoftwareHouseId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The videogame was successfully stored");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public override Videogame? GetVideogameById(int id)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "SELECT Videogames.Id, Videogames.Name, Videogames.Description, Videogames.ReleaseDate, Videogames.SoftwareHouseId" +
                            " FROM Videogames" +
                            " WHERE Videogames.Id = @Id";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("Id");
                    var _id = reader.GetInt32(0);
                    var nameIdx = reader.GetOrdinal("Name");
                    var name = reader.GetString(1);
                    var descriptionIdx = reader.GetOrdinal("Description");
                    var description = reader.GetString(2);
                    var releaseDateIdx = reader.GetOrdinal("ReleaseDate");
                    var release_date = reader.GetDateTime(3);
                    var softwareHouseIdIdx = reader.GetOrdinal("SoftwareHouseId");
                    var software_house_id = reader.GetInt32(4);

                    var videogame = new Videogame { Name = name, Description = description, ReleaseDate = release_date, SoftwareHouseId = software_house_id };

                    return videogame;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        public override List<Videogame> GetVideogameByNameLike(string likeString)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();
                var query = "SELECT Videogames.Id, Videogames.Name, Videogames.Description, Videogames.ReleaseDate, Videogames.SoftWareHouseId" +
                            " FROM Videogames" +
                           $" WHERE Videogames.Name = @NameLike";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NameLike", $"%{likeString}%");

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("Id");
                    var id = reader.GetInt32(0);
                    var nameIdx = reader.GetOrdinal("Name");
                    var name = reader.GetString(1);
                    var descriptionIdx = reader.GetOrdinal("Description");
                    var description = reader.GetString(2);
                    var releaseDateIdx = reader.GetOrdinal("ReleaseDate");
                    var release_date = reader.GetDateTime(3);
                    var softwareHouseIdIdx = reader.GetOrdinal("SoftwareHouseId");
                    var software_house_id = reader.GetInt32(4);

                    var videogame = new Videogame { Name = name, Description = description, ReleaseDate = release_date, SoftwareHouseId = software_house_id };
                    videogames.Add(videogame);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return videogames;
        }

        public override List<Videogame> GetVideogameBySoftwareHouseId(int id)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();
                var query = "SELECT Videogames.Id, Videogames.Name, Videogames.Description, Videogames.ReleaseDate, Videogames.SoftwareHouseId" +
                            "FROM Videogames" +
                            "INNER JOIN SoftwareHouse" +
                            "ON Videogames.SoftwareHouseId = SoftwareHouse.Id" +
                            "WHERE SoftwareHouse.Id = @Id";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("Id");
                    var _id = reader.GetInt32(0);
                    var nameIdx = reader.GetOrdinal("Name");
                    var name = reader.GetString(1);
                    var descriptionIdx = reader.GetOrdinal("Description");
                    var description = reader.GetString(2);
                    var releaseDateIdx = reader.GetOrdinal("ReleaseDate");
                    var release_date = reader.GetDateTime(3);
                    var softwareHouseIdIdx = reader.GetOrdinal("SoftwareHouseId");
                    var software_house_id = reader.GetInt32(4);

                    var videogame = new Videogame { Name = name, Description = description, ReleaseDate = release_date, SoftwareHouseId = software_house_id };
                    videogames.Add(videogame);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return videogames;
        }

        public override void DeleteVideogameById(int id)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                var query = "DELETE FROM videogames " +
                            "WHERE videogames.id = @Id";

                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("The videogame was successfully deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
