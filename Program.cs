using System.Diagnostics;

namespace FizzBuzzNamespace
{
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

        private static string responseToNumber(int number)
        {
            // order of the action matters, they must be applied in this order
            SimpleCompositionAction[] definedActions = [
                new SimpleCompositionAction(3, "Fizz"),
                new SimpleCompositionAction(5, "Buzz"),
                new SimpleCompositionAction(7, "Bang"),

                new ReplacerCompositionAction(11, "Bong"),
                new SuffixBeforeBCompositionAction(13, "Fezz"),
                new ReverseAllCompositionAction(17)
            ];

            var output = new List<string>();

            foreach (var action in definedActions)
                if (action.isMeetingActionCondition(number))
                {
                    output = action.apply(output);
                }

            if (output.Count == 0)
                return number.ToString();
            else
                return String.Join("", output.ToArray());
        }

        public static void testResponseToNumber()
        {
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
}