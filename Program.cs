class FizzBuzz
{
    static void mapOverIntegerRange(int start, int end)
    {
        for (int index = start; index <= end; index++)
        {
            Console.WriteLine(responseToNumber(index));
        }
    }

    static string responseToNumber(int number)
    {
        if (number % 15 == 0)
        {
            return "FizzBuzz";
        }
        else if (number % 5 == 0) 
        {
            return "Buzz";
        }
        else if (number % 3 == 0)
        {
            return "Fizz";
        }
        else
        {
            return number.ToString();
        }
    }

    static void Main(string[] args)
    {
        int start = 1; // inclusive
        int end = 100; // inclusive

        FizzBuzz.mapOverIntegerRange(start, end);
    }
}
