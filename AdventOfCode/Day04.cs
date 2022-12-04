using AoCHelper;

namespace AdventOfCode
{
    public class Day04 : BaseDay
    {
        private readonly string[] _input;

        public Day04()
        {
            _input = File.ReadAllText(InputFilePath)
                .Split(Environment.NewLine);
        }

        public override ValueTask<string> Solve_1()
        {
            var rangesContained = 0;

            foreach (var pair in _input)
            {
                var pairs = pair.Split(',');

                var isOverlapping = AreOverlapping(pairs);
                rangesContained += isOverlapping;
            }

            return new($"{rangesContained}");
        }

        public override ValueTask<string> Solve_2()
        {
            var numOverlappingAtAll = 0;

            foreach (var pair in _input)
            {
                var pairs = pair.Split(',');

                var isOverlapping = AreOverlappingAtAll(pairs);
                numOverlappingAtAll += isOverlapping;
            }

            return new($"{numOverlappingAtAll}");
        }

        private int AreOverlappingAtAll(string[] pairs)
        {
            var pair1 = pairs[0].Split('-');
            var pair2 = pairs[1].Split('-');

            if (int.Parse(pair1[0]) <= int.Parse(pair2[1]))
            {
                if (int.Parse(pair1[1]) == int.Parse(pair2[0]))
                {
                    return 1;
                }

                if (int.Parse(pair2[0]) < int.Parse(pair1[1]) )
                {
                    return 1;
                }

                if (int.Parse(pair1[1]) > int.Parse(pair2[0]) )
                {
                    return 1;
                }
            }

            return 0;
        }

        private int AreOverlapping(string[] pairs)
        {
            var pair1 = pairs[0].Split('-');
            var pair2 = pairs[1].Split('-');

            if (int.Parse(pair1[0]) <= int.Parse(pair2[0]))
            {
                if (int.Parse(pair1[1]) >= int.Parse(pair2[1]))
                {
                    return 1;
                }
            }

            if (int.Parse(pair1[0]) >= int.Parse(pair2[0]))
            {
                if (int.Parse(pair1[1]) <= int.Parse(pair2[1]))
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}
