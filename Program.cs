using System.Diagnostics;

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

    private static string responseToNumber(int number)
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

        var answerComponents = new List<CompositionActions> { };
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
            return composeString(answerComponents.ToArray());
        else
            return number.ToString();
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
                        indexOfFirstB = 0; // all B (or lack of B's) get's replaced by Bong. at index 0;
                        break;
                    }
                case CompositionActions.SuffixWithFezz:
                    {
                        int insertFezzAtIndex = output.Count; // assume no B found initally, set the index to the end

                        if (indexOfFirstB >= 0)
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

    public static void testResponseToNumber()
    {
        // Test cases written by ChatGPT, but verified and fixed in places by a human
        var testCases = new Dictionary<int, string> {
            { 3, "Fizz" },
            { 5, "Buzz" },
            { 7, "Bang" },
            { 11, "Bong" },
            { 13, "Fezz" },
            { 3 * 5, "FizzBuzz" },
            { 3 * 7, "FizzBang" },
            { 5 * 7, "BuzzBang" },
            { 3 * 5 * 7, "FizzBuzzBang" },
            { 11 * 3, "Bong" },
            { 11 * 5, "Bong" },
            { 11 * 7, "Bong" },
            { 11 * 13, "FezzBong" },
            { 13 * 3, "FizzFezz" },
            { 13 * 5, "FezzBuzz" },
            { 13 * 7, "FezzBang" },
            { 13 * 3 * 5, "FizzFezzBuzz" },
            { 13 * 3 * 5 * 7, "FizzFezzBuzzBang" },
            { 3 * 5 * 17, "BuzzFizz" },
            { 5 * 17, "Buzz" },
            { 3 * 7 * 17, "BangFizz" },
            { 7 * 11 * 13 * 17, "BongFezz" },
            { 1, "1" },
            { 2, "2" },
            { 4, "4" },
            { 8, "8" },
            { 17, "17" }
        };

        foreach (var input in testCases.Keys)
        {
            var output = responseToNumber(input);

            Debug.Assert(output == testCases[input],
                "testResponseToNumber answered '" + output + "', but was expected to answer '" + testCases[input] + "' to input = " + input.ToString());
        }
    }

    public static void Main(string[] args)
    {
        int startInclusive = 1;
        int endInclusive = 100;

        mapOverIntegerRange(startInclusive, endInclusive, (input) => Console.WriteLine(responseToNumber(input)));
    }
}
