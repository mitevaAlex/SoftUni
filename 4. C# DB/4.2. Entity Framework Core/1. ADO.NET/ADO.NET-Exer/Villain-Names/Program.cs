using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace Villain_Names
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlCommand command = new SqlCommand(@"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                      FROM Villains AS v 
                                                      JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                      GROUP BY v.Id, v.Name 
                                                      HAVING COUNT(mv.VillainId) > 3 
                                                      ORDER BY COUNT(mv.VillainId)", conn);
                await using (command)
                {
                    SqlDataReader dataReader = await command.ExecuteReaderAsync();
                    await using (dataReader)
                    {
                        while (await dataReader.ReadAsync())
                        {
                            Console.WriteLine($"{dataReader["Name"]} - {dataReader["MinionsCount"]}");
                        }
                    }
                }
            }
        }
    }
}
