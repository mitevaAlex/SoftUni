namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToArray()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count() >= 20)
                .Select(x => new ExportTheatreDto
                 {
                     Name = x.Name,
                     Halls = x.NumberOfHalls,
                     TotalIncome = x.Tickets
                    .Where(y => y.RowNumber >= 1 && y.RowNumber <= 5)
                    .Sum(y => y.Price),
                     Tickets = x.Tickets
                    .Where(y => y.RowNumber >= 1 && y.RowNumber <= 5)
                    .Select(y => new ExportTicketDto
                    {
                        Price = y.Price,
                        RowNumber = y.RowNumber
                    })
                    .OrderByDescending(y => y.Price)
                    .ToArray()
                 })
                .OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name);

            string genresJson = JsonConvert.SerializeObject(theatres);
            return genresJson;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            ExportPlayDto[] plays = context.Plays
                .ToArray()
                .Where(x => x.Rating <= rating)
                .Select(x => new ExportPlayDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts
                    .Where(y => y.IsMainCharacter)
                    .Select(y => new ExportActorDto
                    {
                        FullName = y.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    })
                    .OrderByDescending(y => y.FullName)
                    .ToArray()
                })
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportPlayDto[]), new XmlRootAttribute("Plays"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                serializer.Serialize(sw, plays, namespaces);
            }

            return sb.ToString().Trim();
        }
    }
}
