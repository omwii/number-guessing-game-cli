namespace NumberGuessingGame;

public static class ValidateUtility
{
    public static bool ValidateForRange(int value, int min, int max) => value >= min && value <= max;
}