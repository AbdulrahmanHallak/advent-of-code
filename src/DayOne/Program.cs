namespace AdventOfCode.DayOne;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "input.txt");
        using StreamReader stream = new StreamReader(File.OpenRead(path));

        var input = new string[1000];
        for (int i = 0; i < 1000; i++)
            input[i] = stream.ReadLine()!;

        Console.WriteLine(SumOfAllCaliberation(input));
    }
    static decimal SumOfAllCaliberation(string[] input)
    {
        decimal sum = 0;
        foreach (var line in input)
        {
            string firstDigit = string.Empty;
            string lastDigit = string.Empty;

            ReadOnlySpan<char> lineChars = line.AsSpan();
            for (int i = 0; i < lineChars.Length; i++)
            {
                if (char.GetNumericValue(lineChars[i]) > -1)
                {
                    firstDigit += lineChars[i];
                    break;
                }
            }
            for (int i = lineChars.Length - 1; i >= 0; i--)
            {
                if (char.GetNumericValue(lineChars[i]) > -1)
                {
                    lastDigit += lineChars[i];
                    break;
                }
            }

            string num = firstDigit + lastDigit;
            if (!string.IsNullOrEmpty(num))
                sum += int.Parse(num);
        }
        return sum;
    }
}
