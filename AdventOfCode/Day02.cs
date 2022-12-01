using AoCHelper;

namespace AdventOfCode
{
    public class Day02 : BaseDay
    {
        private readonly string _input;

        public Day02()
        {
            _input = File.ReadAllText(InputFilePath);
        }

        public override ValueTask<string> Solve_1()
        {
            return new($"p1");
        }

        public override ValueTask<string> Solve_2()
        {
            return new($"p2");
        }
    }
}
