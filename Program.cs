class FizzBuzz
{
    static void mapOverIntegerRange(int start, int end)
    {
        for (int index = start; index <= end; index++)
        {
            Console.WriteLine(index);
        }
    }

    static void Main(string[] args)
    {
        int start = 1; // inclusive
        int end = 100; // inclusive

        FizzBuzz.mapOverIntegerRange(start, end);
    }
}
