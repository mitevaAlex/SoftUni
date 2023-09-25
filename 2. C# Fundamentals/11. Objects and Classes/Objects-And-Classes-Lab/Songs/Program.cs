using System;
using System.Collections.Generic;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                //"{typeList}_{name}_{time}"
                string[] currentSongData = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);

                string type = currentSongData[0];
                string name = currentSongData[1];
                string time = currentSongData[2];

                Song currentSong = new Song();
                currentSong.TypeList = type;
                currentSong.Name = name;
                currentSong.Time = time;

                songs.Add(currentSong);
            }
            string requiredListType = Console.ReadLine();//Type List or "all"
            if (requiredListType == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == requiredListType)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
