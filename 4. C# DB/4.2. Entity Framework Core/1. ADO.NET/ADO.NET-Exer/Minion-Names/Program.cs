using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace Minion_Names
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlCommand nameCommand = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", conn);
                await using (nameCommand)
                {
                    nameCommand.Parameters.AddWithValue("@Id", villainId);
                    string villainName = (string)await nameCommand.ExecuteScalarAsync();
                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                SqlCommand minionsCommand = new SqlCommand(@"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                           m.Name, 
                                                           m.Age
                                                           FROM MinionsVillains AS mv
                                                           JOIN Minions As m ON mv.MinionId = m.Id
                                                           WHERE mv.VillainId = @Id
                                                           ORDER BY m.Name", conn);
                await using (minionsCommand)
                {
                    minionsCommand.Parameters.AddWithValue("@Id", villainId);
                    SqlDataReader minions = await minionsCommand.ExecuteReaderAsync();
                    await using (minions)
                    {
                        if (!minions.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                            return;
                        }

                        while (await minions.ReadAsync())
                        {
                            Console.WriteLine($"{minions["RowNum"]}. {minions["Name"]} {minions["Age"]}");
                        }
                    }
                }
            }
        }
    }
}
