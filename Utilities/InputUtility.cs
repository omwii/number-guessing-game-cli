namespace NumberGuessingGame;

public static class InputUtility
{
    public static bool TryReadInt(out int value)
    {
        var input = Console.ReadLine();

        return int.TryParse(input, out value);
    }

    public static bool ReadYesNo()
    {
        var input = Console.ReadLine();

        return input?.ToLower() == "y";
    }
}