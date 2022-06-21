namespace MovieStars.ConsoleApp.Services
{
    using MovieStars.Common;
    using MovieStars.ConsoleApp.Contracts;
    using MovieStars.ConsoleApp.Models;
    using Newtonsoft.Json;
    using System.Text;

    public class MovieStarsService : IMovieStarsService
    {
        public MovieStarsService()
        {
        }

        public string GetMovieStarsInfoFromFile(string filePath)
        {
            try
            {
                StreamReader reader = new(filePath);
                string result;

                using (reader)
                {
                    var json = reader.ReadToEnd();
                    var movieStars = JsonConvert.DeserializeObject<List<MovieStar>>(json);
                    var stringBuilder = new StringBuilder();

                    if (movieStars != null)
                    {
                        foreach (var movieStar in movieStars)
                        {
                            var age = this.CalculateMovieStarAge(movieStar);

                            stringBuilder.AppendLine($"{movieStar.Name} {movieStar.Surname}");
                            stringBuilder.AppendLine($"{movieStar.Sex}");
                            stringBuilder.AppendLine(movieStar.Nationality);
                            stringBuilder.AppendLine($"{age} years old");
                            stringBuilder.AppendLine(string.Empty);
                        }

                        result = stringBuilder.ToString();
                    }
                    else
                    {
                        result = stringBuilder.AppendLine(GlobalConstants.NoMovieStarsFoundInThisFile).ToString();
                    }
                }

                return result;
            }
            catch (FileNotFoundException)
            {
                string message = string.Format(GlobalConstants.FileNotFound, filePath);
                return message;
            }
            catch (DirectoryNotFoundException)
            {
                return GlobalConstants.InvalidPathDirectory;
            }
            catch(IOException) 
            {
                string message = string.Format(GlobalConstants.CannotOpenFile, filePath);
                return message;
            }
        }

        private int CalculateMovieStarAge(IMovieStar movieStar)
        {
            var age = DateTime.Now.Year - movieStar.DateOfBirth.Year;

            if (DateTime.Now.DayOfYear >= movieStar.DateOfBirth.DayOfYear)
            {
                return age;
            }
            else
            {
                return age - 1;
            }
        }
    }
}
