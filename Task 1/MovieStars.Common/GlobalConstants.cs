namespace MovieStars.Common
{
    public static class GlobalConstants
    {
        public const string MovieStarsFilePath = @"..\..\..\input.txt";
        public const string MovieStarsTestFilePath = @"..\..\..\testInput.txt";

        // Error messages
        public const string CannotOpenFile = "Error! Cannot open the file {0}.";
        public const string CouldNotFindRequiredServices = "Error! Could not find required services to run the engine.";
        public const string FileNotFound = "Error! Could not find file {0}.";
        public const string InvalidPathDirectory = "Error! Invalid directory in the file path.";
        public const string NoMovieStarsFoundInThisFile = "There is no movie stars data in this file.";

        // Tests
        public const string FileTestInput = "Katherine Langford\r\nFemale\r\naustralian\r\n26 years old\r\n\r\nMiles Heizer\r\nMale\r\namerican\r\n25 years old\r\n\r\n";
        public const string InvalidFilePath = @"\MovieStars.Tests\NonExistingFolder\incorrectPath";
        public const string InvalidFileName = "invalidFileName";
    }
}