using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CheckpointTomtar
{
    public class DataAccess
    {
        private const string conString =
            "Server = (localdb)\\mssqllocaldb; Database = GnomeDb; Trusted_Connection = True;";

        public List<Gnome> GetGnomesFromDatabase()
        {

            var sql = @"SELECT Gnome.Name, HasBeard, IsEvil, Temperament, GnomeRace.Name
                        FROM Gnome
                        LEFT JOIN GnomeRace on RaceId=GnomeRace.Id";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                var list = new List<Gnome>();

                while (reader.Read())
                {
                    var bp = new Gnome()
                    {
                        Name = reader.GetString(0),
                        HasBeard = reader.GetBoolean(1),
                        IsEvil = reader.GetBoolean(2),
                        Temperament = reader.GetInt16(3),
                        Race = reader.GetString(4)
                    };

                    list.Add(bp);
                }

                return list;
            }

        }

        public void AddGnome_Vulnerable(string gnomeName)
        {
            var sql = @"INSERT INTO Gnome(Name) VALUES('" + gnomeName + "')";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        
    }
}
