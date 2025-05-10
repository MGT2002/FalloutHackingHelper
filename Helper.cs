namespace FalloutHackingHelper;

internal static class Helper
{
    public static int CalculateMatchingCharCount(string str1, string str2)
    {
        var count = str1.Zip(str2, (c1, c2) => c1 == c2).Count();

        return count;
    }

    public static (string word, int matchCount1) InputSelectedWordAndMutchCount()
    {
        Console.Write("Input selected password: ");
        var word = Console.ReadLine() ?? "";

        Console.Write("Input match count: ");
        int matchCount;
        while (!int.TryParse(Console.ReadLine(), out matchCount))
        {
            Console.WriteLine("Wrond input, insert a number!");
            Console.Write("Input match count: ");
        }

        return (word, matchCount);
    }

    public static void MenuDeialogue()
    {
        Console.WriteLine(@"
               input 1 - to Add selected password and match count
               input 2 - check the new password you want to select
               input 3 - to see the list of your inputed passwords and match count
               input 4 - to clear the list of your inputed passwords and match count
               input 5 - to exit the program");

        Console.Write("Enter your choice: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("Option 1 selected: Add selected password and match count.");
                // Add logic for option 1
                break;
            case "2":
                Console.WriteLine("Option 2 selected: Check the new password you want to select.");
                // Add logic for option 2
                break;
            case "3":
                Console.WriteLine("Option 3 selected: See the list of your inputted passwords and match count.");
                // Add logic for option 3
                break;
            case "4":
                Console.WriteLine("Option 4 selected: Clear the list of your inputted passwords and match count.");
                // Add logic for option 4
                break;
            case "5":
                Console.WriteLine("Exiting the program...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input. Please try again.");
                break;
        }
    }
}
