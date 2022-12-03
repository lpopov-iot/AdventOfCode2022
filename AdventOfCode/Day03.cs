using AoCHelper;
using Spectre.Console;

namespace AdventOfCode
{
    public class Day03 : BaseDay
    {
        private readonly string[] _input;

        public Day03()
        {
            _input = File.ReadAllText(InputFilePath)
                .Split(Environment.NewLine);
        }

        public override ValueTask<string> Solve_1()
        {
            var sum = 0;

            foreach (var backpack in _input)
            {
                var compartment1 = backpack.Substring(0, backpack.Length / 2);
                var compartment2 = backpack.Substring(backpack.Length / 2, backpack.Length - backpack.Length / 2);

                var dupe = compartment1.Intersect(compartment2).First();

                sum += ConvertCharItemToIntegerScore(dupe);
            }

            return new($"{sum}");
        }

        public override ValueTask<string> Solve_2()
        {
            var sum = 0;

            var chunks = _input
                .Select((x, i) => (i, x))
                .GroupBy(x => x.i / 3)
                .Select(x => x.Select(v => v.x).ToList())
                .ToList();

            foreach (var chunk in chunks)
            {
                var dupe = chunk[0].Intersect(chunk[1]).Intersect(chunk[2]).First();
                sum += ConvertCharItemToIntegerScore(dupe);
            }

            return new($"{sum}");
        }

        private int ConvertCharItemToIntegerScore(char c)
        {
            string itemTypes = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            int output = 0;
            int ascii = c;
            if (ascii >= 97 && ascii <= 122)
            {
                // Convert lowercase characters to the range 1-26
                output = ascii - 96;
            }
            else if (ascii >= 65 && ascii <= 90)
            {
                // Convert uppercase characters to the range 27-52
                output = ascii - 38;
            }

            return output;
        }
    }
}
