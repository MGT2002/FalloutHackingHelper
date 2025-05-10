using FalloutHackingHelper;

while (true)
{
    Helper.MenuDeialogue();
}

var (selectedWord, matchCount) = Helper.InputSelectedWordAndMutchCount();

Console.Write("Input a password you want to select: ");
var pass = Console.ReadLine() ?? "";

var calculatedMatchCount = Helper.CalculateMatchingCharCount(pass.ToUpperInvariant(), selectedWord.ToUpperInvariant());
Console.WriteLine($"Match count for '{pass}' and '{selectedWord}' is : {calculatedMatchCount}");
if (calculatedMatchCount == matchCount)
    Console.WriteLine($"{pass} - Can be a right password!");
else
    Console.WriteLine($"{pass} - Is wrong. Do not select.");