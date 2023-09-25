namespace AquaShop.Models.Fish
{
    //Can only live in FreshwaterAquarium!
    public class FreshwaterFish : Fish
    {
        private const int size = 3;

        public FreshwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            Size = size;
        }

        public override void Eat()
        {
            Size += 3;
        }
    }
}
