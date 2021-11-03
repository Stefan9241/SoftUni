using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<Character> characters;
        private Stack<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            var charType = args[0];
            var name = args[1];
            if (charType != "Warrior" && charType != "Priest")
            {
                throw new ArgumentException($"Invalid character type \"{charType}\"!");
            }
            Character charr = null;
            if (charType == "Warrior")
            {
                charr = new Warrior(name);
            }
            else
            {
                charr = new Priest(name);
            }
            characters.Add(charr);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            if (itemName != "FirePotion" && itemName != "HealthPotion")
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            Item item = null;
            if (itemName == "FirePotion")
            {
                item = new FirePotion();
            }
            else
            {
                item = new HealthPotion();
            }
            items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            var charName = args[0];
            var charr = characters.FirstOrDefault(x => x.Name == charName);
            if (charr is null)
            {
                throw new ArgumentException($"Character {charName} not found!");
            }

            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item itemToPick = items.Pop();
            charr.Bag.AddItem(itemToPick);

            return $"{charr.Name} picked up {itemToPick.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            var charrName = args[0];
            var itemName = args[1];

            var charr = characters.FirstOrDefault(x => x.Name == charrName);

            if (charr is null)
            {
                throw new ArgumentException($"Character {charrName} not found!");
            }

            var item = charr.Bag.GetItem(itemName);

            charr.UseItem(item);

            return $"{charrName} used {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            foreach (var charr in characters.OrderByDescending(x=> x.IsAlive).ThenByDescending(x=> x.Health))
            {
                sb.AppendLine($"{charr.Name} - HP: {charr.Health}/{charr.BaseHealth}, AP: {charr.Armor}/{charr.BaseArmor}, Status: {(charr.IsAlive ? "Alive" : "Dead")}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attacker = args[0];
            var receiver = args[1];

            Character attackerReal = characters.FirstOrDefault(x=> x.Name == attacker);
            Character receiverReal = characters.FirstOrDefault(x=> x.Name == receiver);

            if (attackerReal is null)
            {
                throw new ArgumentException($"Character {attacker} not found!");
            }

            if (receiverReal is null)
            {
                throw new ArgumentException($"Character {receiver} not found!");
            }

            if (attackerReal is IHealer)
            {
                throw new ArgumentException($"{attacker} cannot attack!");
            }

            (attackerReal as IAttacker).Attack(receiverReal);
            var sb = new StringBuilder();
            sb.AppendLine($"{attackerReal.Name} attacks {receiverReal.Name} for {attackerReal.AbilityPoints} hit points! {receiverReal.Name} has {receiverReal.Health}/{receiverReal.BaseHealth} HP and {receiverReal.Armor}/{receiverReal.BaseArmor} AP left!");
            if (receiverReal.Health == 0)
            {
                sb.AppendLine($"{receiverReal.Name} is dead!");
                receiverReal.IsAlive = false;
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healerNameReal = characters.FirstOrDefault(x => x.Name == healerName);
            var healingReceiverNameReal = characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healerNameReal is null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (healingReceiverNameReal is null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healerNameReal.GetType().Name != "Priest")
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            (healerNameReal as IHealer).Heal(healingReceiverNameReal);

            var stringbuilder = new StringBuilder();
            stringbuilder.AppendLine($"{healerNameReal.Name} heals {healingReceiverNameReal.Name} for {healerNameReal.AbilityPoints}! {healingReceiverNameReal.Name} has {healingReceiverNameReal.Health} health now!");

            return stringbuilder.ToString().TrimEnd();
        }
    }
}
