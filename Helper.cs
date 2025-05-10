namespace FalloutHackingHelper;

internal static class Helper
{
    public static (string word, int matchCount1) InputSelectedWordAndMutchCount()
    {
        Console.Write("Input selected password: ");
        var word = Console.ReadLine()?.Replace(" ", "").ToUpperInvariant() ?? "";

        Console.Write("Input match count: ");
        int matchCount;
        while (!int.TryParse(Console.ReadLine(), out matchCount))
        {
            Console.WriteLine("Wrond input, insert a number!");
            Console.Write("Input match count: ");
        }

        return (word, matchCount);
    }

    public static void InputAndCheckNewPassword(IEnumerable<(string selectedWord, int matchCount)> input)
    {
        Console.Write("Input a password you want to select: ");
        var pass = Console.ReadLine()?.Replace(" ", "").ToUpperInvariant() ?? "";

        if (input.All(i => CheckPasswordCompatibility(i, pass)))
            Console.WriteLine($"{pass} - Can be a right password!");
        else
            Console.WriteLine($"{pass} - Is wrong. Do not select.");
    }

    public static MenuOption MenuDeialogue()
    {
        """            
        input 1 - to Add selected password and match count
        input 2 - check the new password you want to select
        input 3 - to see the list of your inputed passwords and match count
        input 4 - to clear the list of your inputed passwords and match count
        input 5 - to exit the program             
        """.WriteMenuDialogue();

        Console.Write("Enter your choice: ");
        var input = Console.ReadLine();
        Console.Clear();

        switch (input)
        {
            case "1":
                "Option 1 selected: Add selected password and match count.".WriteMenuDialogue();
                return MenuOption.AddPasswordAndMatchCount;
            case "2":
                "Option 2 selected: Check the new password you want to select.".WriteMenuDialogue();
                return MenuOption.CheckNewPassword;
            case "3":
                "Option 3 selected: See the list of your inputted passwords and match count.".WriteMenuDialogue();
                return MenuOption.ViewPasswordsAndMatchCounts;
            case "4":
                "Option 4 selected: Clear the list of your inputted passwords and match count.".WriteMenuDialogue();
                return MenuOption.ClearPasswordsAndMatchCounts;
            case "5":
                "Exiting the program...".WriteMenuDialogue();
                Environment.Exit(0);
                return MenuOption.ExitProgram;
            default:
                "Invalid input. Please try again.".WriteMenuDialogue();
                return MenuOption.InvalidOption;
        }
    }

    public static void PrintSelectedValues(List<(string word, int matchCount)> selectedValues)
    {
        if (selectedValues.Count == 0)
        {
            Console.WriteLine("No values to display.");
            return;
        }

        Console.WriteLine("Selected Values:");
        foreach (var (word, matchCount) in selectedValues)
        {
            Console.WriteLine($"Word: {word}, Match Count: {matchCount}");
        }
        Console.WriteLine();
    }

    public static void WriteMenuDialogue(this string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static bool CheckPasswordCompatibility((string selectedWord, int matchCount) input, string pass)
    {
        var calculatedMatchCount = CalculateMatchingCharCount(pass.ToUpperInvariant(), input.selectedWord.ToUpperInvariant());
        Console.WriteLine($"Match count for '{pass}' and '{input.selectedWord}' is : {calculatedMatchCount}");

        if (calculatedMatchCount == input.matchCount)
            return true;

        return false;
    }

    private static int CalculateMatchingCharCount(string str1, string str2)
    {
        var count = str1.Zip(str2, (c1, c2) => c1 == c2).Count(b => b);

        return count;
    }

    public enum MenuOption
    {
        AddPasswordAndMatchCount = 1,
        CheckNewPassword,
        ViewPasswordsAndMatchCounts,
        ClearPasswordsAndMatchCounts,
        ExitProgram,
        InvalidOption
    }
}
