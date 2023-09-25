namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres
				.ToArray()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					Id = x.Id,
					Genre = x.Name,
					Games = x.Games
					.Where(y => y.Purchases.Any())
					.Select(y => new
					{
						Id = y.Id,
						Title = y.Name,
						Developer = y.Developer.Name,
						Tags = string.Join(", ", y.GameTags.Select(y => y.Tag.Name)),
						Players = y.Purchases.Count()
					})
					.OrderByDescending(y => y.Players)
					.ThenBy(y => y.Id),
					TotalPlayers = x.Games.SelectMany(y => y.Purchases).Count()
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id);

			string genresJson = JsonConvert.SerializeObject(genres);
			return genresJson;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			ExportUserDto[] users = context.Users
				.ToArray()
				.Where(x => x.Cards.Any(c => c.Purchases.Any()))
				.Select(x => new ExportUserDto
				{
					Username = x.Username,
					Purchases = context.Purchases
					.ToArray()
					.Where(y => y.Card.User.Username == x.Username && y.Type.ToString() == storeType)
					.OrderBy(y => y.Date)
					.Select(y => new ExportPurchaseDto
					{
						Card = y.Card.Number,
						Cvc = y.Card.Cvc,
						Date = y.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new ExportGameDto
						{
							Title = y.Game.Name,
							Genre = y.Game.Genre.Name,
							Price = y.Game.Price
						}
					})
					.ToArray()
				})
				.Where(x => x.Purchases.Length > 0)
				.ToArray();

			users.ToList().ForEach(x => x.TotalSpent = x.Purchases.Sum(y => y.Game.Price));
			users = users
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();

			XmlSerializer serializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));
			XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
			namespaces.Add(string.Empty, string.Empty);

			StringBuilder sb = new StringBuilder();
			using (StringWriter sw = new StringWriter(sb))
			{
				serializer.Serialize(sw, users, namespaces);
			}

			return sb.ToString().Trim();
		}
	}
}