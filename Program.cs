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
        if (isDivisibleBy(number, 3) && isDivisibleBy(number, 5))
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (isDivisibleBy(number, 5)) 
        {
            Console.WriteLine("Buzz");
        }
        else if (isDivisibleBy(number, 3))
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
        int startInclusive = 1;
        int endInclusive = 100;

        mapOverIntegerRange(startInclusive, endInclusive, responseToNumber);
    }
}
