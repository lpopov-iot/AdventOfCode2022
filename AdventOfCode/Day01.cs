using AoCHelper;

namespace AdventOfCode
{
    public class Day01 : BaseDay
    {
        private readonly IEnumerable<string[]> _input;

        public Day01()
        {
            _input = File.ReadAllText(InputFilePath)
                .Split(Environment.NewLine+Environment.NewLine)
                .Select(x => x.Split(Environment.NewLine));
        }

        public override ValueTask<string> Solve_1()
        {
            var max = _input.Max(x => x.Sum(Convert.ToInt32));
            return new($"{max}");
        }

        public override ValueTask<string> Solve_2()
        {
            var topThree = _input.Select(x => x.Sum(Convert.ToInt32))
                .OrderByDescending(x => x)
                .Take(3);

            return new($"{topThree.Sum()}");
        }
    }
}
