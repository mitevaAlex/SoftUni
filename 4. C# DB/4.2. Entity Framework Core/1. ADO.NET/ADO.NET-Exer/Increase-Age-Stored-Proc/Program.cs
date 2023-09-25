using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace Increase_Age_Stored_Proc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlCommand increaseAgeStoredProc = new SqlCommand("usp_GetOlder", conn);
                increaseAgeStoredProc.CommandType = System.Data.CommandType.StoredProcedure;
                increaseAgeStoredProc.Parameters.AddWithValue("@id", minionId);
                await increaseAgeStoredProc.ExecuteNonQueryAsync();

                SqlCommand selectMinionCmd = new SqlCommand("SELECT Name, Age FROM Minions WHERE Id = @Id", conn);
                selectMinionCmd.Parameters.AddWithValue("@Id", minionId);
                SqlDataReader minion = await selectMinionCmd.ExecuteReaderAsync();
                await minion.ReadAsync();
                Console.WriteLine($"{minion["Name"]} - {minion["Age"]} years old");
            }
        }
    }
}
