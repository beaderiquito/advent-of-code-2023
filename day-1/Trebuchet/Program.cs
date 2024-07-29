using System.Text.RegularExpressions;

namespace Trebuchet
{
    public class CalibrationDocumentReader
    {
        static void Main(string[] args)
        {
            // Open the file
            StreamReader sr = new StreamReader("D:\\Interview Practice\\advent-of-code-2023\\day-1\\input.txt");

            // Create dictionary for matching spelled out numbers to integers
            NumberDictionary numberDictionary = new NumberDictionary();

            // Initialize values
            int total = 0;
            string line;
            string pattern = @"[\d]|zero|one|two|three|four|five|six|seven|eight|nine";

            // Loop through each line in text file
            while ((line = sr.ReadLine()) != null)
            {
                Console.Write($"{line} ");

                // Get the first match - Look for Regex match from left to right
                int firstMatch;
                string m1 = Regex.Match(line, pattern, RegexOptions.None).Value;
                string numberString1 = numberDictionary.Value(m1) ?? m1;
                firstMatch = Int32.Parse(numberString1);
                Console.Write($"=> firstMatch={firstMatch} ");

                // Get the last match - Look for Regex match from right to left
                int lastMatch;
                string m2 = Regex.Match(line, pattern, RegexOptions.RightToLeft).Value;
                string numberString2 = numberDictionary.Value(m2) ?? m2;
                lastMatch = Int32.Parse(numberString2);
                Console.Write($"=> lastMatch={lastMatch} ");

                // Compute for the subtotal and total - first match is the tens digit, multiply by 10
                int subTotal = (10 * firstMatch) + lastMatch;
                Console.WriteLine($"=> subTotal={subTotal}");
                total += subTotal;

            }
            sr.Close();

            // Print out the total
            Console.WriteLine($"Total = {total}");
        }
    }

    public class NumberDictionary
    {
        Dictionary<string, string> numberDictionary = new Dictionary<string, string>();
        public NumberDictionary()
        {
            this.numberDictionary.Add("one", "1");
            this.numberDictionary.Add("two", "2");
            this.numberDictionary.Add("three", "3");
            this.numberDictionary.Add("four", "4");
            this.numberDictionary.Add("five", "5");
            this.numberDictionary.Add("six", "6");
            this.numberDictionary.Add("seven", "7");
            this.numberDictionary.Add("eight", "8");
            this.numberDictionary.Add("nine", "9");
        }
        public string Value(string key) => this.numberDictionary.GetValueOrDefault(key);
    }
}
