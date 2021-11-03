// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
		private Performer performer;
		private Song song;
		private Stage stage;
		[SetUp]
		public void SetUp()
        {
			performer = new Performer("Stefan", "Spirov", 25);
			song = new Song("Song", new TimeSpan(0,1,30));
			stage = new Stage();
        }
		[Test]
	    public void Add_Throws_Null()
	    {
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
		}
		[Test]
		public void Add_Throws_WrongAge()
		{
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("gosho", "otpochivka", 10)));
		}
		[Test]
		public void Add_Correctly()
		{
			Assert.That(stage.Performers.Count == 0);
			stage.AddPerformer(performer);
			Assert.That(stage.Performers.Count == 1);
		}
		[Test]
		public void AddSong_Throws_Null()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
		}
		[Test]
		public void AddSong_Throws_BadTimeSpan()
		{
			Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("gosho", new TimeSpan(1))));
		}
		[Test]
		public void AddSongToPerformer_Throws_NullPerformer()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Stefan"));
		}
		[Test]
		public void AddSongToPerformer_Throws_NullSong()
		{
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Song", null));
		}

        [Test]
        public void AddSongToPerformer_Correctly()
        {
			var perf = new Performer("stefan", "spirov", 20);

			stage.AddSong(song);
            stage.AddPerformer(perf);

            var result = stage.AddSongToPerformer(song.Name, "stefan spirov");
            var expectedResult = $"{song} will be performed by {perf}";

            Assert.That(result == expectedResult);
        }

        [Test]
        public void Play()
        {
            var performer1 = new Performer("asdasd", "asdasd", 20);
            var performer2 = new Performer("dss", "assdasd", 21);
            var performer3 = new Performer("asdasdddd", "aaaasdasd", 22);
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer3);
			var songg1 = new Song("songi1", new TimeSpan(0, 1, 20));
			var songg2 = new Song("songi12", new TimeSpan(0, 1, 30));
			var songg3 = new Song("songi13", new TimeSpan(0, 1, 40));
			stage.AddSong(songg1);
			stage.AddSong(songg2);
			stage.AddSong(songg3);
			stage.AddSongToPerformer(songg1.Name, performer1.FullName);
			stage.AddSongToPerformer(songg2.Name, performer2.FullName);
			stage.AddSongToPerformer(songg3.Name, performer3.FullName);
			var result = stage.Play();
			var expected = $"{stage.Performers.Count} performers played 3 songs";

			Assert.AreEqual(result, expected);
		}
    }
}