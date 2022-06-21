namespace MovieStars.ConsoleApp.Core
{
    using MovieStars.Common;
    using MovieStars.ConsoleApp.Contracts;

    public class Engine
    {
        private readonly IMovieStarsService movieStarsService;
        private readonly IOutputWriter outputWriter;

        public Engine(IMovieStarsService movieStarsService, IOutputWriter outputWriter)
        {
            this.movieStarsService = movieStarsService;
            this.outputWriter = outputWriter;
        }

        public void Run()
        {
            var output = this.movieStarsService
                .GetMovieStarsInfoFromFile(GlobalConstants.MovieStarsFilePath)
                .TrimEnd();

            this.outputWriter.WriteLine(output);
        }
    }
}
