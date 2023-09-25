namespace Tests
{
    using NUnit.Framework;

    using FightingArena;

    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Alex", 10, 50);
        }

        [Test]
        public void Ctor_SetsAllPropertiesValues()
        {
            bool NameIsSet = warrior.Name == "Alex";
            bool DamageIsSet = warrior.Damage == 10;
            bool HPIsSet = warrior.HP == 50;

            Assert.That(NameIsSet && DamageIsSet && HPIsSet);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        public void Name_ThrowsExceptionWhenValueIsNullOrWhiteSpace(string value)
        {
            Assert.That(() => new Warrior(value, 10, 50),
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Damage_ThrowsExceptionWhenValueIsEqualToOrLessThanZero(int value)
        {
            Assert.That(() => new Warrior("Alex", value, 50),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void HP_ThrowsExceptionWhenValueIsLessThanZero()
        {
            Assert.That(() => new Warrior("Alex", 10, -1),
                Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void Attack_ThrowsExceptionWhenAttackerHPIsLessThan30()
        {
            warrior = new Warrior("Alex", 10, 25);

            Assert.That(() => warrior.Attack(warrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void Attack_ThrowsExceptionWhenEnemyHPIsLessThan30()
        {
            Warrior enemyWarrior = new Warrior("Pesho", 10, 25);

            Assert.That(() => warrior.Attack(enemyWarrior),
                Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void Attack_ThrowsExceptionWhenEnemyIsTooStrong()
        {
            Warrior enemyWarrior = new Warrior("Pesho", 60, 40);

            Assert.That(() => warrior.Attack(enemyWarrior),
                Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void Attack_ReducesAttackerHP()
        {
            Warrior enemyWarrior = new Warrior("Pesho", 25, 40);
            warrior.Attack(enemyWarrior);

            Assert.That(warrior.HP, Is.EqualTo(50 - enemyWarrior.Damage));
        }

        [Test]
        public void Attack_ReducesEnemyHPByAttackersDamage()
        {
            Warrior enemyWarrior = new Warrior("Pesho", 25, 40);
            warrior.Attack(enemyWarrior);

            Assert.That(enemyWarrior.HP, Is.EqualTo(40 - warrior.Damage));
        }

        [Test]
        public void Attack_MakesEnemyHPZero()
        {
            warrior = new Warrior("Alex", 50, 40);
            Warrior enemyWarrior = new Warrior("Pesho", 25, 40);
            warrior.Attack(enemyWarrior);

            Assert.That(enemyWarrior.HP, Is.EqualTo(0));
        }
    }
}