namespace AdventOfCode2023
{
    public static class Day1
    {
        private static IDictionary<string, int> _numbers = new Dictionary<string, int>
        {
            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9},
        };

        public static int Run(List<string> values)
        {
            return values.Sum(x => GetCalibrationValue(x));
        }

        private static int GetCalibrationValue(string value)
        {
            var numberList = FindNumbers(value);
            var firstNumber = numberList.First();
            var lastNumber = numberList.Last();
            return int.Parse(firstNumber + lastNumber);
        }

        private static IEnumerable<string> FindNumbers(string value)
        {
            foreach(var number in _numbers)
            {
                value = value.Replace(number.Key, $"{number.Key[0]}{number.Value}{number.Key[number.Key.Length-1]}");
            }
            return value
                .Where(x => char.IsNumber(x))
                .Select(x => x.ToString());
        }
    }
}
