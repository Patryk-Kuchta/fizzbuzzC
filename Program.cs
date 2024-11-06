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

    private static void responseToNumber(int number)
    {
        var divisorsAndNames = new Dictionary<int, string>
        {
            { 3, "Fizz" },
            { 5, "Buzz" },

        };

        List<string> answerComponents = new List<string> {};

        foreach (var divisor in divisorsAndNames.Keys)
            if (isDivisibleBy(number, divisor)) {
                answerComponents.Add(divisorsAndNames[divisor]);
            }

        if (answerComponents.Count > 0) 
            Console.WriteLine(composeString(answerComponents.ToArray()));
        else
            Console.WriteLine(number.ToString());
    }

    private static string composeString(string[] list)
    {
        return String.Join("", list);
    }

    public static void Main(string[] args)
    {
        int startInclusive = 1;
        int endInclusive = 100;

        mapOverIntegerRange(startInclusive, endInclusive, responseToNumber);
    }
}
