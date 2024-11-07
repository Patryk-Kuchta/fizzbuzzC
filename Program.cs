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

    // order of the action matters, they must be applied in this order
    private enum CompositionActions
    {
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
        bool showNumber = true;

        foreach (var divisor in divisorsAndNames.Keys)
            if (isDivisibleBy(number, divisor))
            {
                var action = divisorsAndNames[divisor];
                answerComponents.Add(divisorsAndNames[divisor]);
                if (action != CompositionActions.ReverseAll)
                    showNumber = false;
            }

        if (showNumber)
            return number.ToString();
        else
            return composeString(answerComponents.ToArray());
    }

    private static string composeString(CompositionActions[] list)
    {
        var output = new List<string>();
        int indexOfFirstB = -1;

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
                        string name = action.ToString().Replace("Append", "");

                        if (indexOfFirstB < 0)
                        {
                            indexOfFirstB = output.Count;
                        }

                        output.Add(name);
                        break;
                    }
                case CompositionActions.ReplaceEverythingWithBong:
                    {
                        output = new List<string> { "Bong" };
                        indexOfFirstB = 0;
                        break;
                    }
                case CompositionActions.SuffixWithFezz:
                    {
                        int insertFezzAtIndex = output.Count;

                        if (indexOfFirstB >= 0)
                        {
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

        testResponseToNumber();

        mapOverIntegerRange(startInclusive, endInclusive, (input) => Console.WriteLine(responseToNumber(input)));
    }
}
