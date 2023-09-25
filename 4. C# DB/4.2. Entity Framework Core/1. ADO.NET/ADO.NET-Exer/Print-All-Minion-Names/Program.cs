using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Print_All_Minion_Names
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Server=DESKTOP-NQ0DDAV\\SQLEXPRESS;Database=MinionsDB;Trusted_Connection=True;");
            await conn.OpenAsync();
            await using (conn)
            {
                SqlCommand namesCommand = new SqlCommand("SELECT Name FROM Minions", conn);
                SqlDataReader namesReader = await namesCommand.ExecuteReaderAsync();
                List<string> names = new List<string>();
                while (await namesReader.ReadAsync())
                {
                    names.Add((string)namesReader["Name"]);
                }

                for (int i = 0; i < names.Count / 2; i++)
                {
                    Console.WriteLine(names[i]);
                    Console.WriteLine(names[names.Count - i - 1]);
                }

                if (names.Count % 2 != 0)
                {
                    Console.WriteLine(names[names.Count / 2]);
                }
            }
        }
    }
}
