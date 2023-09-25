namespace Tests
{
    using NUnit.Framework;

    using CarManager;

    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Tesla", "Model X", 5, 20);
        }

        [Test]
        public void Ctor_SetsAllPropertiesValues()
        {
            bool FuelAmountIsSet = car.FuelAmount == 0;
            bool MakeIsSet = car.Make == "Tesla";
            bool ModelIsSet = car.Model == "Model X";
            bool FuelConsumptionIsSet = car.FuelConsumption == 5;
            bool FuelCapacityIsSet = car.FuelCapacity == 20;

            Assert.That(FuelAmountIsSet && MakeIsSet && ModelIsSet && FuelConsumptionIsSet && FuelCapacityIsSet);

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Make_ThrowsExceptionWhenValueIsNullOrEmpty(string value)
        {
            Assert.That(() => car = new Car(value, "Model X", 5, 20),
                Throws.ArgumentException.With.Message.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Model_ThrowsExceptionWhenValueIsNullOrEmpty(string value)
        {
            Assert.That(() => car = new Car("Tesla", value, 5, 20),
                Throws.ArgumentException.With.Message.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void FuelConsumption_ThrowsExceptionWhenValueIsLessThanOrEqualToZero(double value)
        {
            Assert.That(() => car = new Car("Tesla", "Model X", value, 20),
                Throws.ArgumentException.With.Message.EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void FuelCapacity_ThrowsExceptionWhenValueIsLessThanOrEqualToZero(double value)
        {
            Assert.That(() => car = new Car("Tesla", "Model X", 5, value),
                Throws.ArgumentException.With.Message.EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        public void Refuel_RefuelsCorrectly()
        {
            car.Refuel(10);

            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void Refuel_RefuelsWithoutExceedingFuelCapacity()
        {
            car.Refuel(30);

            Assert.That(car.FuelAmount, Is.EqualTo(20));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void Refuel_ThrowsExceptionWhenFuelIsEqualToOrLessThanZero(double fuel)
        {
            Assert.That(() => car.Refuel(fuel),
                Throws.ArgumentException.With.Message.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void Drive_ReducesFuelAmount()
        {
            car.Refuel(10);
            car.Drive(100);

            Assert.That(car.FuelAmount, Is.EqualTo(5));
        }

        [Test]
        public void Drive_ThrowsExceptionWhenNotEnoughFuel()
        {
            Assert.That(() => car.Drive(100),
                Throws.InvalidOperationException.With.Message.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}