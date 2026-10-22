namespace NumberGuessingGame;

public static class Messages
{
    public const string WelcomeMessage = "Welcome to Number Guess Game!\n";

    public const string DifficultyMessage = "Please select the difficulty level:\n" +
                                            "1. Easy (10 chances)\n" +
                                            "2. Medium (5 chances)\n" +
                                            "3. Hard (3 chances)\n" +
                                            "\n" +
                                            "Enter your choice: ";
    
    public const string GameStartedMessage = "Let's start the game!";

    public const string GuessEnterMessage = "\nEnter your guess: ";

    public const string GameLostMessage = "You lost.";

    public const string RetryMessage = "Retry? Y/N: ";
    
    public static string SuccessfulDifficultySelectionMessage(Difficulty difficulty) => 
        $"\nGreat! You have selected the {difficulty} difficulty level.\n";
    
    public static string LesserGuessMessage(int guess) => $"Incorrect! The number is less than {guess}.";
    
    public static string GreaterGuessMessage(int guess) => $"Incorrect! The number is more than {guess}.";
    
    public static string ExactGuessMessage(int attempts) => 
        $"Congratulations! You guessed the correct number in {attempts} attempts.\n";
}