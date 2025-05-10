using static FalloutHackingHelper.Helper;

var selectedValues = new List<(string word, int matchCount)>
{
    InputSelectedWordAndMutchCount()
};
PrintSelectedValues(selectedValues);

MenuOption option;
while ((option = MenuDeialogue()) != MenuOption.ExitProgram)
{
    switch (option)
    {
        case MenuOption.AddPasswordAndMatchCount:
            selectedValues.Add(InputSelectedWordAndMutchCount());
            PrintSelectedValues(selectedValues);
            break;
        case MenuOption.CheckNewPassword:
            InputAndCheckNewPassword(selectedValues);
            break;
        case MenuOption.ViewPasswordsAndMatchCounts:
            PrintSelectedValues(selectedValues);
            break;
        case MenuOption.ClearPasswordsAndMatchCounts:
            selectedValues.Clear();
            break;
        case MenuOption.InvalidOption:
            Console.WriteLine("Invalid option selected. Please try again.");
            break;
    }
}