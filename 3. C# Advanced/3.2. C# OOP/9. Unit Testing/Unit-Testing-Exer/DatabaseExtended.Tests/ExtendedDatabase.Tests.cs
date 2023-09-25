namespace Tests
{
    using NUnit.Framework;
    using System.Linq;
    using System;

    using ExtendedDatabase;

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;
        private Person person;

        [SetUp]
        public void Setup()
        {
            extendedDatabase = new ExtendedDatabase();
            person = new Person(1, "Alex");
        }

        [Test]
        public void Ctor_AddsValidPeopleToDb()
        {
            extendedDatabase = new ExtendedDatabase(person);

            Assert.That(extendedDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenDbCountIsExceeded()
        {
            Assert.That(() => extendedDatabase = new ExtendedDatabase(Enumerable.Repeat(person, 17).ToArray()),
               Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenUserNameAlreadyExists()
        {
            Assert.That(() => extendedDatabase = new ExtendedDatabase(person, person),
               Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenIdAlreadyExists()
        {
            Assert.That(() => extendedDatabase = new ExtendedDatabase(person, new Person(1, "Pesho")),
               Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Add_ThrowsExceptionWhenDbCountIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDatabase.Add(new Person(i + 1, $"person{i + 1}"));
            }

            Assert.That(() => extendedDatabase.Add(new Person(17, "person17")),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_RemovesFromDb()
        {
            extendedDatabase.Add(person);
            extendedDatabase.Remove();

            Assert.That(() => extendedDatabase.FindByUsername(person.UserName),
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void Remove_DecreasesCount()
        {
            extendedDatabase.Add(person);
            extendedDatabase.Remove();

            Assert.That(extendedDatabase.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        public void FindByUsername_FindsCorrectPersonWithWantedUsername()
        {
            extendedDatabase.Add(person);
            Person wantedPerson = extendedDatabase.FindByUsername(person.UserName);

            Assert.That(wantedPerson.UserName, Is.EqualTo(person.UserName));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsername_ThrowsExceptionWhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void FindById_FindsCorrectPersonWithWantedId()
        {
            extendedDatabase.Add(person);
            Person wantedPerson = extendedDatabase.FindById(person.Id);

            Assert.That(wantedPerson.Id, Is.EqualTo(person.Id));
        }

        [Test]
        public void FindByUsername_ThrowsExceptionWhenIdIsLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(-1));
        }

        [Test]
        public void FindByUsername_ThrowsExceptionIfIdDoesntExist()
        {
            Assert.That(() => extendedDatabase.FindById(1),
                Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }
    }
}