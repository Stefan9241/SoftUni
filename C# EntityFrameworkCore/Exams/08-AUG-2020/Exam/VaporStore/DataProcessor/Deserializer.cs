namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var gamesDtos = JsonConvert.DeserializeObject<ImportGamesDto[]>(jsonString);

			var sb = new StringBuilder();
            foreach (var game in gamesDtos)
            {
                if (!IsValid(game) || game.Tags.Length == 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var genre = context.Genres.FirstOrDefault(x => x.Name == game.Genre);
				if(genre == null)
                {
					genre = new Genre()
					{
						Name = game.Genre
					};
                }

				var developer = context.Developers
					.FirstOrDefault(x => x.Name == game.Developer) ?? new Developer() { Name = game.Developer };

				var newGame = new Game()
				{
					Name = game.Name,
					Genre = genre,
					Developer = developer,
					Price = game.Price,
					ReleaseDate = game.ReleaseDate.Value,
				};

                foreach (var tag in game.Tags)
                {
					var currTag = context.Tags.FirstOrDefault(x => x.Name == tag) ?? new Tag() { Name = tag };

					newGame.GameTags.Add(new GameTag() {Tag = currTag });
                }

				context.Games.Add(newGame);
				context.SaveChanges();

				sb.AppendLine($"Added {newGame.Name} ({newGame.Genre.Name}) with {newGame.GameTags.Count} tags"!);
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
			var sb = new StringBuilder();
            foreach (var userDto in usersDtos)
            {
				if(!IsValid(userDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var user = new User()
				{
					Age = userDto.Age,
					Email = userDto.Email,
					FullName = userDto.FullName,
					Username = userDto.Username,
					Cards = userDto.Cards.Select(x => new Card()
					{
						Cvc = x.Cvc,
						Number = x.Number,
						Type = x.Type.Value
					}).ToArray(),
				};

				context.Users.Add(user);
				context.SaveChanges();

				sb.AppendLine($"Imported {userDto.Username} with {userDto.Cards.Length} cards");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var purchasesDtos = XmlConverter.Deserializer<ImportPurchaseDto>(xmlString,"Purchases");
			var sb = new StringBuilder();
            foreach (var purchDto in purchasesDtos)
            {
				if(!IsValid(purchDto))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var parsedDate = DateTime.TryParseExact(purchDto.Date, 
					"dd/MM/yyyy HH:mm", 
					CultureInfo.InvariantCulture,
					DateTimeStyles.None, 
					out var date);

                if (!parsedDate)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}
				var card = context.Cards.FirstOrDefault(x => x.Number == purchDto.Card);
				var game = context.Games.First(x => x.Name == purchDto.Title);
				
				var purch = new Purchase
				{
					Date = date,
					Type = purchDto.Type.Value,
					Card = card,
					ProductKey = purchDto.Key,
					Game = game
				};

				context.Purchases.Add(purch);
				context.SaveChanges();


				var username = context.Users
					.Where(x => x.Id == purch.Card.UserId)
					.Select(x => x.Username)
					.FirstOrDefault();
				sb.AppendLine($"Imported {purchDto.Title} for {username}");
            }

			return sb.ToString().TrimEnd();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}