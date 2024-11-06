class FizzBuzz
{
    static void mapOverIntegerRange(int start, int end, Action<int> action)
    {
        for (int index = start; index <= end; index++)
        {
            action(index);
        }
    }

    static void responseToNumber(int number)
    {
        if (number % 15 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (number % 5 == 0) 
        {
            Console.WriteLine("Buzz");
        }
        else if (number % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else
        {
            Console.WriteLine(number.ToString());
        }
    }

    static void Main(string[] args)
    {
        int start = 1; // inclusive
        int end = 100; // inclusive

        FizzBuzz.mapOverIntegerRange(start, end, responseToNumber);
    }
}
