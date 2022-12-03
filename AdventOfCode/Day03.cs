using AoCHelper;

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
                var compartment1 = backpack[..(backpack.Length / 2)];
                var compartment2 = backpack[(backpack.Length / 2)..];

                var dupe = compartment1.Intersect(compartment2).First();

                sum += dupe - (dupe > 96 ? 96 : 38);
            }

            return new($"{sum}");
        }

        public override ValueTask<string> Solve_2()
        {
            var sum = 0;

            var chunks = _input.Chunk(3);

            foreach (var chunk in chunks)
            {
                var dupe = chunk[0].Intersect(chunk[1]).Intersect(chunk[2]).First();
                sum += dupe - (dupe > 96 ? 96 : 38);
            }

            return new($"{sum}");
        }
    }
}
