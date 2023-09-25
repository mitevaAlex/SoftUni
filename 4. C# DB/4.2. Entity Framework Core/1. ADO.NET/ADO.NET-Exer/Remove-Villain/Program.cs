using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace Remove_Villain
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
                SqlCommand villainNameCmd = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villainId", conn);
                villainNameCmd.Parameters.AddWithValue("@villainId", villainId);
                string villainName = (string)await villainNameCmd.ExecuteScalarAsync();
                if (villainName == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                SqlCommand deleteFromMinionsVillainsCmd = new SqlCommand(@"DELETE FROM MinionsVillains 
                                                                           WHERE VillainId = @villainId", conn);
                deleteFromMinionsVillainsCmd.Parameters.AddWithValue("@villainId", villainId);
                int releasedMinions = await deleteFromMinionsVillainsCmd.ExecuteNonQueryAsync();

                SqlCommand deleteFromVillainsCmd = new SqlCommand(@"DELETE FROM Villains
                                                                    WHERE Id = @villainId", conn);
                deleteFromVillainsCmd.Parameters.AddWithValue("@villainId", villainId);
                await deleteFromVillainsCmd.ExecuteNonQueryAsync();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{releasedMinions} minions were released.");
            }
        }
    }
}
