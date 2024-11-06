class FizzBuzz
{
    private static void mapOverIntegerRange(int startInclusive, int endInclusive, Action<int> action)
    {
        for (int index = startInclusive; index <= endInclusive; index++)
        {
            action(index);
        }
    }

    private static bool isDivisibleBy(int number, int divisior)
    {
        return number % divisior == 0;
    }

    private enum CompositionActions
    { // order of the action matters, they must be applied in this order
        AppendFizz,
        AppendBuzz,
        AppendBang,
        ReplaceEverythingWithBong,
        SuffixWithFezz,
        ReverseAll
    }

    private static void responseToNumber(int number)
    {
        var divisorsAndNames = new Dictionary<int, CompositionActions>
        {
            { 3, CompositionActions.AppendFizz },
            { 5, CompositionActions.AppendBuzz },
            { 7, CompositionActions.AppendBang },
            { 11, CompositionActions.ReplaceEverythingWithBong },
            { 13, CompositionActions.SuffixWithFezz },
            { 17, CompositionActions.ReverseAll }
        };

        List<CompositionActions> answerComponents = new List<CompositionActions> { };

        foreach (var divisor in divisorsAndNames.Keys)
            if (isDivisibleBy(number, divisor))
            {
                answerComponents.Add(divisorsAndNames[divisor]);
            }

        if (answerComponents.Count > 0)
            Console.WriteLine(composeString(answerComponents.ToArray()));
        else
            Console.WriteLine(number.ToString());
    }

    private static string composeString(CompositionActions[] list)
    {
        List<string> output = new List<string>();
        int indexOfFirstB = -1; // initial set to negative to note that no Bs have been found. 

        foreach (var action in list)
        {
            switch (action)
            {
                case CompositionActions.AppendFizz:
                    {
                        output.Add("Fizz");
                        break;
                    }
                case CompositionActions.AppendBuzz:
                case CompositionActions.AppendBang:
                    {
                        // simply convert to string and remove the Append suffix
                        string name = action.ToString().Replace("Append", "");

                        if (indexOfFirstB < 0)
                        { // i.e. B not yet added
                            indexOfFirstB = output.Count;
                        }

                        output.Add(name);
                        break;
                    }
                case CompositionActions.ReplaceEverythingWithBong:
                    {
                        output = new List<string> { "Bong" };
                        break;
                    }
                case CompositionActions.SuffixWithFezz:
                    {
                        int insertFezzAtIndex = output.Count; // assume no B found initally, set the index to the end

                        if (indexOfFirstB > 0)
                        { // i.e. B was added, overwrite with it's index
                            insertFezzAtIndex = indexOfFirstB;
                        }

                        output.Insert(insertFezzAtIndex, "Fezz");
                        break;
                    }
                case CompositionActions.ReverseAll:
                    {
                        output.Reverse(); 
                        break;
                    }
            }
        }
        return String.Join("", output.ToArray());
    }

    public static void Main(string[] args)
    {
        int startInclusive = 1;
        int endInclusive = 100;

        mapOverIntegerRange(startInclusive, endInclusive, responseToNumber);
    }
}
