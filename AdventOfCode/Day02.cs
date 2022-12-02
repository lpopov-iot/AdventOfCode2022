using AoCHelper;

namespace AdventOfCode
{
    public class Day02 : BaseDay
    {
        private readonly string[] _input;

        private Dictionary<char, char> _wins = new Dictionary<char, char>()
        {
            {'A', 'Y'},
            {'B', 'Z'},
            {'C', 'X'},
        };

        private Dictionary<char, char> _losses = new Dictionary<char, char>()
        {
            {'A', 'Z'},
            {'B', 'X'},
            {'C', 'Y'},
        };

        private Dictionary<char, char> _draws = new Dictionary<char, char>()
        {
            {'A', 'X'},
            {'B', 'Y'},
            {'C', 'Z'},
        };

        private Dictionary<char, int> _scores = new Dictionary<char, int>()
        {
            { 'X', 1 },
            { 'Y', 2 },
            { 'Z', 3 },
        };

        public Day02()
        {
            _input = File.ReadAllText(InputFilePath)
                .Split(Environment.NewLine);
        }

        public override ValueTask<string> Solve_1()
        {
            var totalScore = 0;

            foreach (var outcome in _input)
            {
                var playA = outcome[0];
                var playB = outcome[^1];

                if (_wins[playA] == playB)
                {
                    totalScore += 6;
                }
                else if (_draws[playA] == playB)
                {
                    totalScore += 3;
                }

                totalScore += _scores[outcome[^1]];
            }

            return new($"{totalScore}");
        }

        public override ValueTask<string> Solve_2()
        {
            var totalScore = 0;

            foreach (var outcome in _input)
            {
                var neededResult = outcome[^1];
                var playA = outcome[0];

                if (neededResult == 'Y')
                {
                    var playB = _draws[playA];
                    totalScore += _scores[playB];
                    totalScore += 3;
                }

                if (neededResult == 'X')
                {
                    var playB = _losses[playA];
                    totalScore += _scores[playB];
                }

                if (neededResult == 'Z')
                {
                    var playB = _wins[playA];
                    totalScore += _scores[playB];
                    totalScore += 6;
                }
            }

            return new($"{totalScore}");
        }
    }
}
