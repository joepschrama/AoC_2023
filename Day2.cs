namespace AdventOfCode2023
{
    public static class Day2
    {
        public static int Run(List<string> input)
        {
            var gameIdSum = 0;
            foreach (var game in input)
            {
                gameIdSum += GetPossibleGameId(game);
            }
            return gameIdSum;
        }

        public static int GetPossibleGameId(string game)
        {
            var allowedRedCubes = 12;
            var allowedGreenCubes = 13;
            var allowedBlueCubes = 14;

            var gameStringArray = game.Split(':');
            var gameId = gameStringArray.First().Replace("Game ", "");
            var gameSets = gameStringArray.Last().Split(";");

            foreach (var gameSet in gameSets)
            {
                var gameSetThrows = gameSet.Split(",");
                var blueCubes = gameSetThrows.FirstOrDefault(x => x.Contains("blue"))?.Replace("blue", "") ?? "0";
                var greenCubes = gameSetThrows.FirstOrDefault(x => x.Contains("green"))?.Replace("green", "") ?? "0";
                var redCubes = gameSetThrows.FirstOrDefault(x => x.Contains("red"))?.Replace("red", "") ?? "0";
                if (int.Parse(blueCubes) > allowedBlueCubes || int.Parse(greenCubes) > allowedGreenCubes || int.Parse(redCubes) > allowedRedCubes)
                {
                    return 0;
                }
            }
            return int.Parse(gameId);
        }
    }
}
