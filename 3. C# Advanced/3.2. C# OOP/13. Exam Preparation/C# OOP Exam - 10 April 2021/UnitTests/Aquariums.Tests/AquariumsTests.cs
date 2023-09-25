namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Reflection;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Initialization()
        {
            aquarium = new Aquarium("Lake", 10);
            fish = new Fish("Nemo");
        }

        [Test]
        public void Ctor_InitializesPropertiesAndCollections()
        {
            List<Fish> fish = (List<Fish>)typeof(Aquarium)
                .GetField("fish", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(aquarium);
            bool fishCollectionInitialized = fish.Count == 0;
            bool nameInitialized = aquarium.Name == "Lake";
            bool capacityInitialized = aquarium.Capacity == 10;

            Assert.That(fishCollectionInitialized && nameInitialized && capacityInitialized);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void set_Name_ThrowsExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.That(() => new Aquarium(name, 10),
                Throws.ArgumentNullException
                .With.Message.EqualTo("Invalid aquarium name! (Parameter 'value')"));
        }

        [Test]
        public void set_Capacity_ThrowsExceptionWhenCapacityIsLessThanZero()
        {
            Assert.That(() => new Aquarium("Lake", -1),
                Throws.ArgumentException
                .With.Message.EqualTo("Invalid aquarium capacity!"));
        }

        [Test]
        public void get_Count_ReturnsCorrectFishCount()
        {
            aquarium.Add(fish);

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsExceptionWhenAquariumIsFull()
        {
            for (int i = 0; i < 10; i++)
            {
                aquarium.Add(fish);
            }

            Assert.That(() => aquarium.Add(fish), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void RemoveFish_RemovesValidFish()
        {
            aquarium.Add(fish);
            aquarium.RemoveFish(fish.Name);

            Assert.That(aquarium.Count == 0);
        }

        [Test]
        public void RemoveFish_ThrowsExceptionWhenFishDoesntExist()
        {
            Assert.That(() => aquarium.RemoveFish(fish.Name), 
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Fish with the name {fish.Name} doesn't exist!"));
        }

        [Test]
        public void SellFish_SellsValidFish()
        {
            aquarium.Add(fish);
            Fish soldFish = aquarium.SellFish(fish.Name);

            Assert.That(fish.Available == false);
            Assert.That(soldFish.Equals(fish));
        }

        [Test]
        public void SellFish_ThrowsExceptionWhenFishDoesntExist()
        {
            Assert.That(() => aquarium.SellFish(fish.Name),
                Throws.InvalidOperationException
                .With.Message.EqualTo($"Fish with the name {fish.Name} doesn't exist!"));
        }

        [Test]
        public void Report_ReturnsCorrectInfo()
        {
            Fish fish2 = new Fish("Dori");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            string output = aquarium.Report();

            Assert.That(output == $"Fish available at {aquarium.Name}: {fish.Name}, {fish2.Name}");
        }
    }
}
