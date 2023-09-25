using System;
using System.Collections.Generic;
using System.Linq;

using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (!items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item wantedItem = items
                .FirstOrDefault(x => x.GetType().Name == name);
            items
                .Remove(wantedItem);
            return wantedItem;
        }
    }
}
