namespace Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    using FightingArena;

    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Alex", 50, 40);
        }

        [Test]
        public void Ctor_InitializesAListOfWarriors()
        {
            Assert.That(arena.Warriors, Is.EqualTo(new List<Warrior>()));
        }

        [Test]
        public void Enroll_AddsNewWarrior()
        {
            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Does.Contain(warrior));
        }

        [Test]
        public void Enroll_ThrowsExceptionWhenWarriorAlreadyExists()
        {
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        [TestCase("Pesho", "Alex")]
        [TestCase("Alex", "Pesho")]
        public void Fight_ThrowsExceptionWhenNamesDontExist(string attackerName, string deffenderName)
        {
            arena.Enroll(warrior);

            Assert.That(() => arena.Fight(attackerName, deffenderName),
                Throws.InvalidOperationException.With.Message.EqualTo("There is no fighter with name Pesho enrolled for the fights!"));
        }

        [Test]
        public void Fight_AttackerAttacksDeffender()
        {
            Warrior deffenderWarrior = new Warrior("Pesho", 25, 40);

            arena.Enroll(warrior);
            arena.Enroll(deffenderWarrior);
            arena.Fight(warrior.Name, deffenderWarrior.Name);

            Assert.That(deffenderWarrior.HP, Is.EqualTo(0));
        }
    }
}
