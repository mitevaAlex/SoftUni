using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> gifts;

        public CompositeGift(string name, int price) : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift) => gifts.Add(gift);

        public void Remove(GiftBase gift) => gifts.Remove(gift);

        public override int CalculateTotalPrice()
        {
            int total = 0;
            Console.WriteLine($"{base.name} contains the following products with prices:");

            foreach (GiftBase gift in gifts)
            {
                total += gift.CalculateTotalPrice();
            }

            return total;
        }
    }
}
