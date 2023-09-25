using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Change_Town_Names_Casing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string country = Console.ReadLine();
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlCommand updateTownsInCountryCmd = new SqlCommand(@"UPDATE Towns
                                                                     SET Name = UPPER(Name)
                         WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)", conn);
                updateTownsInCountryCmd.Parameters.AddWithValue("@countryName", country);
                int affectedRows = await updateTownsInCountryCmd.ExecuteNonQueryAsync();
                if (affectedRows == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine($"{affectedRows} town names were affected.");
                    SqlCommand affectedTownsCmd = new SqlCommand(@"SELECT t.Name 
                                                                   FROM Towns as t
                                                                   JOIN Countries AS c ON c.Id = t.CountryCode
                                                                   WHERE c.Name = @countryName", conn);
                    affectedTownsCmd.Parameters.AddWithValue("@countryName", country);
                    SqlDataReader townsReader = await affectedTownsCmd.ExecuteReaderAsync();
                    List<string> townNames = new List<string>();
                    while (await townsReader.ReadAsync())
                    {
                        townNames.Add((string)townsReader["Name"]);
                    }

                    Console.WriteLine($"[{string.Join(", ", townNames)}]");
                }
            }
        }
    }
}
