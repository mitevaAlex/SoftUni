using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Add_Minion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .ToArray();
            string villainName = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .ToArray()[0];
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlCommand townIdCmd = new SqlCommand("SELECT Id FROM Towns WHERE Name = @townName", conn);
                townIdCmd.Parameters.AddWithValue("@townName", minionInfo[2]);
                int? townId = (int)await townIdCmd.ExecuteScalarAsync();
                if (townId == null)
                {
                    SqlCommand insertTownCmd = new SqlCommand("INSERT INTO Towns (Name) VALUES (@townName)", conn);
                    insertTownCmd.Parameters.AddWithValue("@townName", minionInfo[2]);
                    await insertTownCmd.ExecuteNonQueryAsync();
                    Console.WriteLine($"Town {minionInfo[2]} was added to the database.");

                    townId = (int)await townIdCmd.ExecuteScalarAsync();
                }

                SqlCommand villainIdCmd = new SqlCommand("SELECT Id FROM Villains WHERE Name = @Name", conn);
                villainIdCmd.Parameters.AddWithValue("@Name", villainName);
                int? villainId = (int)await villainIdCmd.ExecuteScalarAsync();
                if (villainId == null)
                {
                    SqlCommand insertVillainCmd = new SqlCommand("INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@villainName, 4)", conn);
                    insertVillainCmd.Parameters.AddWithValue("@villainName", villainName);
                    await insertVillainCmd.ExecuteNonQueryAsync();
                    Console.WriteLine($"Villain {villainName} was added to the database.");

                    villainId = (int)await villainIdCmd.ExecuteScalarAsync();
                }

                SqlCommand insertMinionCmd = new SqlCommand("INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)", conn);
                insertMinionCmd.Parameters.AddWithValue("@name", minionInfo[0]);
                insertMinionCmd.Parameters.AddWithValue("@age", int.Parse(minionInfo[1]));
                insertMinionCmd.Parameters.AddWithValue("@townId", townId);
                await insertMinionCmd.ExecuteNonQueryAsync();

                SqlCommand minionIdCmd = new SqlCommand("SELECT Id FROM Minions WHERE Name = @Name AND Age = @Age", conn);
                minionIdCmd.Parameters.AddWithValue("@Name", minionInfo[0]);
                minionIdCmd.Parameters.AddWithValue("@Age", int.Parse(minionInfo[1]));
                int minionId = (int)await minionIdCmd.ExecuteScalarAsync();

                SqlCommand insertMinionsVillainsCmd = new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)", conn);
                insertMinionsVillainsCmd.Parameters.AddWithValue("@minionId", minionId);
                insertMinionsVillainsCmd.Parameters.AddWithValue("@villainId", villainId);
                await insertMinionsVillainsCmd.ExecuteNonQueryAsync();
                Console.WriteLine($"Successfully added {minionInfo[0]} to be minion of {villainName}.");
            }
        }
    }
}
