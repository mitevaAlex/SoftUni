namespace Tests
{
    using NUnit.Framework;

    using Database;//MUST remove this using before submitting to Judge

    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            this.database = new Database(1);
        }

        [Test]
        public void Ctor_AddsValidItemsIntoDb()
        {
            Assert.That(database.Count, Is.EqualTo(1));
        }

        [Test]
        public void Ctor_ThrowsExceptionWhenDbCountIsExceeded()
        {
            Assert.That(() => database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_IncrementsCount()
        {
            database.Add(2);

            Assert.That(database.Count, Is.EqualTo(2));
        }

        public void Add_AddsElementToDb()
        {
            database.Add(2);
            int[] dataCopy = database.Fetch();

            Assert.That(dataCopy, Does.Contain(2));
        }

        [Test]
        public void Add_ThrowsExceptionWhenDbCountIsExceeded()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(i + 2);
            }

            Assert.That(() => database.Add(17),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_DecreasesCount()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_RemovesElementFromDb()
        {
            database.Remove();
            int[] dataCopy = database.Fetch();

            Assert.That(dataCopy, Does.Not.Contain(1));
        }

        [Test]
        public void Remove_ThrowsExceptionWhenDbIsEmpty()
        {
            database.Remove();

            Assert.That(() => database.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }


        [Test]
        public void Fetch_ReturnsDbExactData()
        {
            int[] dataCopy = database.Fetch();

            Assert.That(dataCopy, Is.EqualTo(new int[] { 1 }));
        }

        [Test]
        public void Fetch_ReturnsDbCopyNotReference()
        {
            int[] firstDataCopy = database.Fetch();
            database.Add(2);
            int[] secondDataCopy = database.Fetch();

            Assert.That(firstDataCopy, Is.Not.EqualTo(secondDataCopy));
        }

        [Test]
        public void Count_ReturnsZeroWhenDbIsEmpty()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(0));
        }
    }
}