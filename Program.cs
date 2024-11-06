using System.Collections.Generic;

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

        foreach (var action in list)
        {
            switch (action)
            {
                case CompositionActions.AppendFizz:
                case CompositionActions.AppendBuzz:
                case CompositionActions.AppendBang:
                    {
                        string name = action.ToString().Replace("Append", ""); // simply convert to string and remove the Append suffix
                        output.Add(name);
                        break;
                    }
                case CompositionActions.SuffixWithFezz:
                    {
                        output.Insert(0, "Fezz"); // todo, this is not really correct
                        break;
                    }
                case CompositionActions.ReverseAll:
                    {
                        output.Reverse(); 
                        break;
                    }
            }
        }
        return String.Join("|", output.ToArray()); // todo: remove the pipe symbol
    }

    public static void Main(string[] args)
    {
        int startInclusive = 1;
        int endInclusive = 100;

        mapOverIntegerRange(startInclusive, endInclusive, responseToNumber);
    }
}
