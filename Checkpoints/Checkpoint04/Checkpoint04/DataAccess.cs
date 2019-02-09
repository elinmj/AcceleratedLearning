using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Checkpoint04
{
    class DataAccess
    {
        string conString = "Server = (localdb)\\mssqllocaldb; Database = GnomeDb";
        
        internal List<Gnome> GetGnomesFromDatabase()
        {
            //Level1 - fungerar nu endast om metoden istället returnerar en lista av strängar
            //var sql = "SELECT Name FROM Gnome";

            //using (SqlConnection connection = new SqlConnection(conString))
            //using (SqlCommand command = new SqlCommand(sql, connection))
            //{
            //    connection.Open();

            //    SqlDataReader reader = command.ExecuteReader();

            //    var list = new List<string>();

            //    while (reader.Read())
            //    {
            //        list.Add(reader.GetSqlString(0).Value);
            //    }
            //    return list;

            //}

            //Level2
            var sql = @"SELECT Name, Beard, Evil, Temperament, Race
                        FROM Gnome
                        JOIN Attributes ON Attributes.NameId=Gnome.NameId";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                var list = new List<Gnome>();

                while (reader.Read())
                {
                    var gnome = new Gnome
                    {
                        Name = reader.GetSqlString(0).Value,
                        Beard = reader.GetSqlString(1).Value,
                        Evil = reader.GetSqlString(2).Value,
                        Temperament = reader.GetSqlInt32(3).Value,
                        Race = reader.GetSqlString(4).Value
                    };

                    list.Add(gnome);
                }

                return list;
            }


        }
    }
}
