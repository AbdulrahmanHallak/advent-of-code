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

        Console.WriteLine(SumWithWords(input));
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
    static decimal SumWithWords(string[] input)
    {
        decimal sum = 0;
        foreach (var line in input)
        {
            int lastDigitIndex = 0;
            int firstDigitIndex = line.Length;
            string firstDigit = string.Empty;
            string lastDigit = string.Empty;

            // Code to handle the first digit.
            foreach (var numWord in numsSpelled.Keys)
            {
                var index = line.IndexOf(numWord);
                if (index != -1 && index < firstDigitIndex)
                {
                    firstDigitIndex = index;
                    firstDigit = numsSpelled[numWord].ToString();
                }
            }
            for (int i = 0; i < line.Length && i <= firstDigitIndex; i++)
            {

                if (char.GetNumericValue(line[i]) > -1)
                {
                    if (firstDigitIndex != -1 && i > firstDigitIndex)
                        break;
                    firstDigit = line[i].ToString();
                    break;
                }
            }

            // Code to handle the second digit.
            foreach (var numWord in numsSpelled.Keys)
            {
                var index = line.LastIndexOf(numWord);
                if (index != -1 && index > lastDigitIndex)
                {
                    lastDigitIndex = index;
                    lastDigit = numsSpelled[numWord].ToString();
                }
            }

            for (int i = line.Length - 1; i >= 0 && i >= lastDigitIndex; i--)
            {
                if (char.GetNumericValue(line[i]) > -1)
                {
                    if (lastDigitIndex != -1 && i < lastDigitIndex)
                        break;
                    lastDigit = line[i].ToString();
                    break;
                }
            }

            string num = firstDigit + lastDigit;
            if (!string.IsNullOrEmpty(num))
                sum += int.Parse(num);
        }
        return sum;
    }
    static readonly Dictionary<string, string> numsSpelled = new()
        {
            {"one", "1"},
            {"two", "2"},
            {"three","3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"}
        };
}
