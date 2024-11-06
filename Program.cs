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

        var answerComponents = new List<CompositionActions> {};
        int productiveActionsCount = 0; // i.e. do not lead to empty strings, currently anything but ReverseAll

        foreach (var divisor in divisorsAndNames.Keys)
            if (isDivisibleBy(number, divisor))
            {
                var action = divisorsAndNames[divisor];
                answerComponents.Add(divisorsAndNames[divisor]);
                if (action != CompositionActions.ReverseAll)
                {
                    productiveActionsCount++;
                }
            }

        if (productiveActionsCount > 0)
            Console.WriteLine(composeString(answerComponents.ToArray()));
        else
            Console.WriteLine(number.ToString());
    }

    private static string composeString(CompositionActions[] list)
    {
        var output = new List<string>();
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

    public static void testComposeString()
    {
        // test cases written by ChatGPT, but verfied by me
        var testCases = new Dictionary<int, string> {
            // Basic FizzBuzz Rules
            { 3, "Fizz" },                 // Multiple of 3
            { 5, "Buzz" },                 // Multiple of 5
            { 7, "Bang" },                 // Multiple of 7
            { 11, "Bong" },                // Multiple of 11
            { 13, "Fezz" },                // Multiple of 13
    
            // Combined Cases (Multiples of combinations of rules)
            { 3 * 5, "FizzBuzz" },         // Multiple of both 3 and 5
            { 3 * 7, "FizzBang" },         // Multiple of both 3 and 7
            { 5 * 7, "BuzzBang" },         // Multiple of both 5 and 7
            { 3 * 5 * 7, "FizzBuzzBang" }, // Multiple of 3, 5, and 7
    
            { 11 * 3, "BongFizz" },        // Multiple of both 11 and 3
            { 11 * 5, "BongBuzz" },        // Multiple of both 11 and 5
            { 11 * 7, "BongBang" },        // Multiple of both 11 and 7
            { 11 * 3 * 5, "BongFizzBuzz" },// Multiple of 3, 5, and 11
    
            { 13 * 3, "FezzFizz" },        // Multiple of both 13 and 3
            { 13 * 5, "FezzBuzz" },        // Multiple of both 13 and 5
            { 13 * 7, "FezzBang" },        // Multiple of both 13 and 7
            { 13 * 3 * 5, "FezzFizzBuzz" },// Multiple of 3, 5, and 13
    
            // Multiple of 17, causing reversal
            { 3 * 17, "BuzzFizz" },        // Multiple of 3 and 17
            { 5 * 17, "BuzzFizz" },        // Multiple of 5 and 17
            { 7 * 17, "BangFizz" },        // Multiple of 7 and 17
            { 3 * 5 * 17, "BuzzFizzFizz" }, // Multiple of 3, 5, and 17
            { 7 * 11, "BongBang" },        // Multiple of 7 and 11
            { 7 * 11 * 13, "FezzBongBang" } // Multiple of 7, 11, and 13, Fezz always in front of Bong
        };


    }

    public static void Main(string[] args)
    {
        int startInclusive = 1;
        int endInclusive = 100;

        mapOverIntegerRange(startInclusive, endInclusive, responseToNumber);
    }
}
