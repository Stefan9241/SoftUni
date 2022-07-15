namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var allGenres = context.Genres
				.ToArray()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x=> new 
				{
					Id= x.Id,
					Genre = x.Name,
					Games = x.Games
					.Where(x=> x.Purchases.Count != 0)
					.Select(g=> new 
					{
						Id = g.Id,
						Title = g.Name,
						Developer = g.Developer.Name,
						Tags = string.Join(", ",g.GameTags.Select(x=> x.Tag.Name)),
						Players = g.Purchases.Count
					})
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id)
					.ToArray(),
					TotalPlayers = x.Games.Sum(x=> x.Purchases.Count)
				})
				.OrderByDescending(x=> x.TotalPlayers)
				.ThenBy(x=> x.Id)
				.ToArray();


			return JsonConvert.SerializeObject(allGenres,Formatting.Indented);
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users.ToArray()
				.Where(x => x.Cards.Any(c => c.Purchases.Any()))
				.Select(x => new UserExportDto
				{
					Username = x.Username,
					TotalSpent = x.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price)),
					Purchases = x.Cards.SelectMany(c => c.Purchases)
						.Where(x=> x.Type.ToString() == storeType)
						.Select(p => new PurchaseExportDto
						{
						Card = p.Card.Number,
						CVC = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new GameExportDto
						{
							Title = p.Game.Name,
							Price = p.Game.Price,
							Genre = p.Game.Genre.Name,
						},
					})
					.OrderBy(c=> c.Date)
					.ToArray()
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();


			return XmlConverter.Serialize<UserExportDto>(users,"Users");
		}
	}
}