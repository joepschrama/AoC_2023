namespace AdventOfCode2023
{
    public static class Day1
    {
        public static int Run(List<string> values)
        {
            return values.Sum(x => GetCalibrationValue(x));
        }

        private static int GetCalibrationValue(string value)
        {
            var numberList = value.Where(x => char.IsNumber(x)).Select(x => x.ToString());
            var firstNumber = numberList.First();
            var lastNumber = numberList.Last();
            return int.Parse(firstNumber + lastNumber);
        }
    }
}
