class FizzBuzz
{
    private static void mapOverIntegerRange(int start, int end, Action<int> action)
    {
        for (int index = start; index <= end; index++)
        {
            action(index);
        }
    }

    private static bool divisible_by(int number, int divisior)
    {
        return number % divisior == 0;
    }

    private static void responseToNumber(int number)
    {
        if (divisible_by(number, 15)) // checking for divisibilty by both 3 and 5 at the same time
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (divisible_by(number, 5)) 
        {
            Console.WriteLine("Buzz");
        }
        else if (divisible_by(number, 3))
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

        FizzBuzz.mapOverIntegerRange(start, end, responseToNumber);
    }
}
