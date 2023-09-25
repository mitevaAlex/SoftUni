namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            IEnumerable<ImportGameDto> games = JsonConvert.DeserializeObject<IEnumerable<ImportGameDto>>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (ImportGameDto gameDTO in games)
            {
                if (!IsValid(gameDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Game game = new Game
                {
                    Name = gameDTO.Name,
                    Price = gameDTO.Price,
                    ReleaseDate = DateTime.ParseExact(gameDTO.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                };

                Developer developer = null;
                if (context.Developers.FirstOrDefault(x => x.Name == gameDTO.Developer) == null)
                {
                     developer = new Developer { Name = gameDTO.Developer };
                }
                else
                {
                    developer = context.Developers.FirstOrDefault(x => x.Name == gameDTO.Developer);
                }

                game.Developer = developer;

                Genre genre = null;
                if (context.Genres.FirstOrDefault(x => x.Name == gameDTO.Genre) == null)
                {
                    genre = new Genre { Name = gameDTO.Genre };
                }
                else
                {
                    genre = context.Genres.FirstOrDefault(x => x.Name == gameDTO.Genre);
                }

                game.Genre = genre;

                if (gameDTO.Tags.Where(x => string.IsNullOrEmpty(x)).Count() >= 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                context.Games.Add(game);
                context.SaveChanges();

                foreach (string gameTagDTO in gameDTO.Tags)
                {
                    Tag tag = new Tag { Name = gameTagDTO };

                    if (context.Tags.FirstOrDefault(t => t.Name == tag.Name) == null)
                    {
                        context.Tags.Add(tag);
                        context.SaveChanges();
                    }

                    tag = context.Tags.FirstOrDefault(t => t.Name == tag.Name);
                    GameTag gameTag = new GameTag { GameId = game.Id, TagId = tag.Id };
                    context.GameTags.Add(gameTag);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedGame, game.Name, game.Genre.Name, game.GameTags.Count));
            }

            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            IEnumerable<ImportUserDto> users = JsonConvert.DeserializeObject<IEnumerable<ImportUserDto>>(jsonString);

            StringBuilder sb = new StringBuilder();
            foreach (ImportUserDto userDTO in users)
            {
                if (!IsValid(userDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User user = new User
                {
                    FullName = userDTO.FullName,
                    Username = userDTO.Username,
                    Email = userDTO.Email,
                    Age = userDTO.Age
                };

                bool invalidCards = false;
                foreach (ImportCardDto cardDTO in userDTO.Cards)
                {
                    if (!IsValid(cardDTO))
                    {
                        invalidCards = true;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    bool isTypeValid = Enum.TryParse(typeof(CardType), cardDTO.Type, out object cardType);
                    if (!isTypeValid)
                    {
                        invalidCards = true;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    user.Cards.Add(new Card
                    {
                        Number = cardDTO.Number,
                        Cvc = cardDTO.CVC,
                        Type = (CardType)cardType
                    });
                }

                if (invalidCards)
                {
                    continue;
                }

                context.Users.Add(user);

                sb.AppendLine(string.Format(SuccessfullyImportedUser, user.Username, user.Cards.Count));
            }

            context.SaveChanges();
            return sb.ToString().Trim();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));
            ImportPurchaseDto[] purchaseDtos = (ImportPurchaseDto[])serializer.Deserialize(new StringReader(xmlString));

            StringBuilder sb = new StringBuilder();
            foreach (ImportPurchaseDto purchaseDto in purchaseDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Games.FirstOrDefault(x => x.Name == purchaseDto.Game) == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isTypeValid = Enum.TryParse(typeof(PurchaseType), purchaseDto.Type, out object purchaseType);
                if (!isTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card) == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool IsDateValid = DateTime.TryParseExact(purchaseDto.Date,
                    "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime date);
                if (!IsDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Purchase purchase = new Purchase
                {
                    Type = (PurchaseType)purchaseType,
                    ProductKey = purchaseDto.ProductKey,
                    Card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card),
                    Date = date,
                    Game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Game)
                };

                context.Purchases.Add(purchase);
                context.SaveChanges();
                sb.AppendLine(string.Format(SuccessfullyImportedPurchase, purchase.Game.Name, purchase.Card.User.Username));
            }

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}