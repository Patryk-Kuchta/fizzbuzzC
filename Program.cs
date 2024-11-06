class FizzBuzz
{
    private static void mapOverIntegerRange(int start, int end, Action<int> action)
    {
        for (int index = start; index <= end; index++)
        {
            action(index);
        }
    }

    private static bool divisibleBy(int number, int divisior)
    {
        return number % divisior == 0;
    }

    private static void responseToNumber(int number)
    {
        if (divisibleBy(number, 15)) // checking for divisibilty by both 3 and 5 at the same time
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (divisibleBy(number, 5)) 
        {
            Console.WriteLine("Buzz");
        }
        else if (divisibleBy(number, 3))
        {
            Console.WriteLine("Fizz");
        }
        else
        {
            Console.WriteLine(number.ToString());
        }
    }

    public static void Main(string[] args)
    {
        int start = 1; // inclusive
        int end = 100; // inclusive

        mapOverIntegerRange(start, end, responseToNumber);
    }
}
