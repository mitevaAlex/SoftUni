// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using FestivalManager.Entities;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Performer validPerformer;
        private Song validSong;

        [SetUp]
        public void Initialization()
        {
            stage = new Stage();
            validPerformer = new Performer("Pesho", "Peshov", 25);
            validSong = new Song("Endless Summer", new TimeSpan(0, 3, 30));
        }

        [Test]
        public void Ctor_InitializesSongListAndPerformerList()
        {
            List<Song> songs = (List<Song>)stage
                .GetType()
                .GetField("Songs", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(stage);
            bool songListInitialized = songs.Count == 0;
            bool performerListInitialized = stage.Performers.Count == 0;

            Assert.That(songListInitialized && performerListInitialized);
        }

        [Test]
        public void AddPerformer_AddsValidPerformer()
        {
            stage.AddPerformer(validPerformer);

            Assert.That(stage.Performers.Contains(validPerformer));
        }

        [Test]
        public void AddPerformer_ThrowsExceptionWhenNullPerformer()
        {
            Assert.That(() => stage.AddPerformer(null),  
                Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'performer')"));
        }

        [Test]
        public void AddPerformer_ThrowsExceptionWhenUnderagePerformer()
        {
            Performer underagePerformer = new Performer("Pesho", "Peshov", 17);

            Assert.That(() => stage.AddPerformer(underagePerformer), 
                Throws.ArgumentException.With.Message.EqualTo("You can only add performers that are at least 18."));
        }

        [Test]
        public void AddSong_AddsValidSong()
        {
            stage.AddSong(validSong);
            List<Song> songs = (List<Song>)stage
                .GetType()
                .GetField("Songs", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(stage);

            Assert.That(songs.Contains(validSong));
        }

        [Test]
        public void AddSong_ThrowsExceptionWhenNullSong()
        {
            Assert.That(() => stage.AddSong(null),
                Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'song')"));
        }

        [Test]
        public void AddSong_ThrowsExceptionWhenSongDurationIsUnder1Minute()
        {
            Song under1MinuteSong = new Song("Endless Summer", new TimeSpan(0, 0, 30));

            Assert.That(() => stage.AddSong(under1MinuteSong),
                Throws.ArgumentException.With.Message.EqualTo("You can only add songs that are longer than 1 minute."));
        }

        [Test]
        public void AddSongToPerformer_AddsValidSongToValidPerformer()
        {
            stage.AddPerformer(validPerformer);
            stage.AddSong(validSong);
            string output = stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);

            Assert.That(validPerformer.SongList.Contains(validSong));
            Assert.That(output == "Endless Summer (03:30) will be performed by Pesho Peshov");
        }

        [Test]
        public void AddSongToPerformer_ThrowsExceptionWhenNullSong()
        {
            stage.AddPerformer(validPerformer);

            Assert.That(() => stage.AddSongToPerformer(null, validPerformer.FullName),
                Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'songName')"));
        }

        [Test]
        public void AddSongToPerformer_ThrowsExceptionWhenNullPerformer()
        {
            stage.AddSong(validSong);

            Assert.That(() => stage.AddSongToPerformer(validSong.Name, null),
                Throws.ArgumentNullException.With.Message.EqualTo("Can not be null! (Parameter 'performerName')"));
        }

        [Test]
        public void AddSongToPerformer_ThrowsExceptionWhenPerformerNotExisting()
        {
            stage.AddSong(validSong);

            Assert.That(() => stage.AddSongToPerformer(validSong.Name, "non-existent performer"),
                Throws.ArgumentException.With.Message.EqualTo("There is no performer with this name."));
        }

        [Test]
        public void AddSongToPerformer_ThrowsExceptionWhenSongNotExisting()
        {
            stage.AddPerformer(validPerformer);

            Assert.That(() => stage.AddSongToPerformer("non-existent song", validPerformer.FullName),
                Throws.ArgumentException.With.Message.EqualTo("There is no song with this name."));
        }

        [Test]
        public void Play_ReturnsValidSongSumAndPerformerSum()
        {
            stage.AddPerformer(validPerformer);
            stage.AddSong(validSong);
            stage.AddSong(new Song("dhuehf", new TimeSpan(0, 5, 23)));

            stage.AddSongToPerformer(validSong.Name, validPerformer.FullName);

            Assert.That(() => stage.Play(), Is.EqualTo("1 performers played 1 songs"));
        }
    }
}