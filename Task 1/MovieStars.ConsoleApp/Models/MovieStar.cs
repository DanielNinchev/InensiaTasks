using MovieStars.ConsoleApp.Contracts;

namespace MovieStars.ConsoleApp.Models
{
    public class MovieStar : IMovieStar
    {
        public MovieStar(string name, string surname, DateTime dateOfBirth, string sex, string nationality)
        {
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Sex = sex;
            this.Nationality = nationality;
        }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Sex { get; set; }

        public string Nationality { get; set; }
    }
}
