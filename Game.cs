namespace NumberGuessingGame;

public class Game
{
    private int _number;
    private int _availableGuesses;
    private int _attempts;
    private GameState _state;
    
    public void Start()
    {
        Setup();
        Run();
    }

    private void Setup()
    {
        // Reset
        Console.Clear();
        _number = 0;
        _availableGuesses = 0;
        _state = GameState.Running;
        _attempts = 0;
        
        // Display welcome message
        Console.WriteLine(Messages.WelcomeMessage);
        
        // Set number
        var random = new Random();
        _number = random.Next(1, 101);
        
        // Set difficulty
        Console.Write(Messages.DifficultyMessage);
        var difficulty = Difficulty.Unknown;
        while (_availableGuesses == 0)
            if (InputUtility.TryReadInt(out var input) && ValidateUtility.ValidateForRange(input, 1, 3))
            {
                switch (input)
                {
                    case 1:
                        _availableGuesses = 10;
                        difficulty = Difficulty.Easy;
                        break;
                    case 2:
                        _availableGuesses = 5;
                        difficulty = Difficulty.Medium;
                        break;
                    case 3:
                        _availableGuesses = 3;
                        difficulty = Difficulty.Hard;
                        break;
                }
            }
        Console.WriteLine(Messages.SuccessfulDifficultySelectionMessage(difficulty));
    }

    private void Run()
    {
        // Game start
        Console.WriteLine(Messages.GameStartedMessage);
        
        // Game cycle
        while (_state == GameState.Running)
        {
            // Input
            Console.Write(Messages.GuessEnterMessage);
            _attempts++;
            
            // Parse and validate input number
            if (!InputUtility.TryReadInt(out var guessInput))
                throw new ArgumentException(guessInput + " is not a number.");
            if (!ValidateUtility.ValidateForRange(guessInput, 1, 100))
                throw new ArgumentException(guessInput + " is not within range.");

            // Check answer
            var guessAnswer = CheckGuess(guessInput);
            switch (guessAnswer)
            {
                case GuessType.Lesser:
                    _availableGuesses--;
                    Console.WriteLine(Messages.LesserGuessMessage(guessInput));
                    break;
                case GuessType.Greater:
                    _availableGuesses--;
                    Console.WriteLine(Messages.GreaterGuessMessage(guessInput));
                    break;
                case GuessType.Equal:
                    _state = GameState.Win;
                    Console.WriteLine(Messages.ExactGuessMessage(_attempts));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            // Check for lose
            if (_availableGuesses != 0) continue;
            _state = GameState.Lose;
            Console.WriteLine(Messages.GameLostMessage);
        }
        
        Console.Write(Messages.RetryMessage);
        if (InputUtility.ReadYesNo())
            Start();
    }

    private GuessType CheckGuess(int guess)
    {
        if (guess < _number)
            return GuessType.Greater;
        return guess > _number ? GuessType.Lesser : GuessType.Equal;
    }
}