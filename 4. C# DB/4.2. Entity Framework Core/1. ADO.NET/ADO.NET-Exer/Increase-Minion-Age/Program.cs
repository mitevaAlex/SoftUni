using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Increase_Minion_Age
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] minionIds = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlTransaction transaction = (SqlTransaction)await conn.BeginTransactionAsync();
                try
                {
                    SqlCommand increaseAgeCmd = new SqlCommand(@" UPDATE Minions
                                     SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                     WHERE Id = @Id", conn);
                    increaseAgeCmd.Transaction = transaction;
                    foreach (int id in minionIds)
                    {
                        increaseAgeCmd.Parameters.Clear();
                        increaseAgeCmd.Parameters.AddWithValue("@Id", id);
                        await increaseAgeCmd.ExecuteNonQueryAsync();
                    }

                    await transaction.CommitAsync();

                    SqlCommand selectNameAgeCmd = new SqlCommand("SELECT Name, Age FROM Minions", conn);
                    SqlDataReader data = await selectNameAgeCmd.ExecuteReaderAsync();
                    while (await data.ReadAsync())
                    {
                        Console.WriteLine($"{data["Name"]} {data["Age"]}");
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                }
            }
        }
    }
}
