namespace MusicHub
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //string albums = ExportAlbumsInfo(context, 9);
            //Console.WriteLine(albums);

            string albums = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(albums);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
                .ToArray()
                .Where(x => x.ProducerId == producerId)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    Name = x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs
                    .ToArray()
                    .Select(y => new
                    {
                        Name = y.Name,
                        Price = y.Price.ToString("F2"),
                        WriterName = y.Writer.Name
                    })
                    .OrderByDescending(y => y.Name)
                    .ThenBy(y => y.WriterName)
                    .ToArray(),
                    Price = x.Price.ToString("F2")
                })
                .ToArray();

            StringBuilder result = new StringBuilder();
            foreach (var album in albums)
            {
                result.Append($"-AlbumName: {album.Name}\r\n")
                    .Append($"-ReleaseDate: {album.ReleaseDate}\r\n")
                    .Append($"-ProducerName: {album.ProducerName}\r\n")
                    .Append($"-Songs:\r\n");
                int i = 1;
                foreach (var song in album.Songs)
                {
                    result.Append($"---#{i++}\r\n")
                        .Append($"---SongName: {song.Name}\r\n")
                        .Append($"---Price: {song.Price}\r\n")
                        .Append($"---Writer: {song.WriterName}\r\n");
                }

                result.Append($"-AlbumPrice: {album.Price}\r\n");
            }

            return result.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .ToArray()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
                {
                    Name = x.Name,
                    PerformerName = x.SongPerformers
                    .Select(y => $"{y.Performer.FirstName} {y.Performer.LastName}")
                    .FirstOrDefault(),
                    WriterName = x.Writer.Name,
                    ProducerName = x.Album.Producer.Name,
                    Duration = x.Duration.ToString("c")
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerName)
                .ToArray();

            StringBuilder result = new StringBuilder();
            int i = 1;
            foreach (var song in songs)
            {
                result.Append($"-Song #{i++}\r\n");
                result.Append($"---SongName: {song.Name}\r\n");
                result.Append($"---Writer: {song.WriterName}\r\n");
                result.Append($"---Performer: {song.PerformerName}\r\n");
                result.Append($"---AlbumProducer: {song.ProducerName}\r\n");
                result.Append($"---Duration: {song.Duration}\r\n");
            }

            return result.ToString().Trim();
        }
    }
}
