namespace MovieStars.Tests
{
    using MovieStars.Common;
    using MovieStars.ConsoleApp.Services;
    using NUnit.Framework;

    public class MovieStarsServiceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldDisplayMovieStarsDataFromFileWhenGivenCorrectFileName()
        {
            // arrange
            var expectedResult = GlobalConstants.FileTestInput;
            var service = new MovieStarsService();

            // act
            var actualResult = service.GetMovieStarsInfoFromFile(GlobalConstants.MovieStarsTestFilePath);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ShouldReturnInvalidPathDirectoryMessageIfIncorrectPathIsGiven()
        {
            var service = new MovieStarsService();
            var message = service.GetMovieStarsInfoFromFile(GlobalConstants.InvalidFilePath);

            Assert.AreEqual(GlobalConstants.InvalidPathDirectory, message);
        }

        [Test]
        public void ShouldReturnFileNotFoundExceptionMessageIfInvalidFileNameIsGiven()
        {
            var service = new MovieStarsService();
            var expectedMessage = string.Format(GlobalConstants.FileNotFound, GlobalConstants.InvalidFileName);
            var actualMessage = service.GetMovieStarsInfoFromFile(GlobalConstants.InvalidFileName);

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}