using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private const string characterNamespaceTemplate = "WarCroft.Entities.Characters.Contracts.{0}";
        private const string itemNamespaceTemplate = "WarCroft.Entities.Items.{0}";

        private List<Character> characterParty;
        private List<Item> itemPool;

        public WarController()
        {
            characterParty = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            Type characterType = Type.GetType(string.Format(characterNamespaceTemplate, args[0]));
            string name = args[1];

            if (characterType == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            characterParty.Add((Character)Activator
                .CreateInstance(characterType, new object[] { name }));
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            Type itemType = Type.GetType(string.Format(itemNamespaceTemplate, args[0]));
            if (itemType == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, args[0]));
            }

            itemPool.Add((Item)Activator.CreateInstance(itemType));
            return string.Format(SuccessMessages.AddItemToPool, args[0]);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            if (!characterParty.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
                throw new ArgumentException(ExceptionMessages.ItemPoolEmpty);
            }

            characterParty
                .FirstOrDefault(x => x.Name == characterName)
                .Bag
                    .AddItem(itemPool.Last());
            return string.Format(SuccessMessages.PickUpItem,
                characterName,
                itemPool.Last().GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            if (!characterParty.Any(x => x.Name == characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Character character = characterParty
                .FirstOrDefault(x => x.Name == characterName);
            character.UseItem(character.Bag.GetItem(itemName));

            return string.Format(SuccessMessages.UsedItem,
                characterName, itemName);
        }

        public string GetStats()
        {
            var characters = characterParty
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(x => x.Health);
            return string.Join(Environment.NewLine,
                characters
                .Select(x => string.Format(
                    SuccessMessages.CharacterStats,
                    x.Name,
                    x.Health,
                    x.BaseHealth,
                    x.Armor,
                    x.BaseArmor,
                    x.IsAlive ? "Alive" : "Dead")));
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            if (!characterParty.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (!characterParty.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            Warrior attacker = characterParty.FirstOrDefault(x => x.Name == attackerName) as Warrior;
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Character receiver = characterParty.FirstOrDefault(x => x.Name == receiverName);
            attacker.Attack(receiver);
            StringBuilder output = new StringBuilder()
                .AppendLine(string.Format(SuccessMessages.AttackCharacter,
                                    attackerName,
                                    receiverName,
                                    attacker.AbilityPoints,
                                    receiverName,
                                    receiver.Health,
                                    receiver.BaseHealth,
                                    receiver.Armor,
                                    receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
                output.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

            return output.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];
            if (!characterParty.Any(x => x.Name == healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (!characterParty.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            Priest healer = characterParty.FirstOrDefault(x => x.Name == healerName) as Priest;
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Character receiver = characterParty.FirstOrDefault(x => x.Name == receiverName);
            healer.Heal(receiver);
            return string.Format(SuccessMessages.HealCharacter,
                                    healerName,
                                    receiverName,
                                    healer.AbilityPoints,
                                    receiverName,
                                    receiver.Health);
        }
    }
}
