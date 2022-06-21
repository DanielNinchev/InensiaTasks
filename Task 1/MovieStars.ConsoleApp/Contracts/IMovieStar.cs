namespace MovieStars.ConsoleApp.Contracts
{
    public interface IMovieStar
    {
        string Name { get; set; }

        string Surname { get; set; }

        DateTime DateOfBirth { get; set; }

        string Sex { get; set; }

        string Nationality { get; set; }
    }
}
