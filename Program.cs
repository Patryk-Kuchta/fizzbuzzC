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

        public static string responseToNumber(int number)
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

        public static void Main(string[] args)
        {
            int startInclusive = 1;
            int endInclusive = 100;

            Test.testResponseToNumber();

            mapOverIntegerRange(startInclusive, endInclusive, (input) => Console.WriteLine(responseToNumber(input)));
        }
    }
}