namespace AdventOfCode2023
{
    public static class Day2
    {
        // Part 2
        public static int Run(List<string> input)
        {
            var gamePowerSum = 0;
            foreach (var game in input)
            {
                gamePowerSum += GetGamePower(game);
            }
            return gamePowerSum;
        }

        // Part 1
        public static int Run_part1(List<string> input)
        {
            var gameIdSum = 0;
            foreach (var game in input)
            {
                gameIdSum += GetPossibleGameId(game);
            }
            return gameIdSum;
        }

        // Part 1
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


        // Part 2
        public static int GetGamePower(string game)
        {
            var minRedCubes = 0;
            var minGreenCubes = 0;
            var minBlueCubes = 0;

            var gameSets = game.Split(':').Last().Split(";");
            foreach (var gameSet in gameSets)
            {
                var gameSetThrows = gameSet.Split(",");
                var blueCubes = gameSetThrows.FirstOrDefault(x => x.Contains("blue"))?.Replace("blue", "") ?? "0";
                var greenCubes = gameSetThrows.FirstOrDefault(x => x.Contains("green"))?.Replace("green", "") ?? "0";
                var redCubes = gameSetThrows.FirstOrDefault(x => x.Contains("red"))?.Replace("red", "") ?? "0";
                if (int.Parse(blueCubes) > minBlueCubes) minBlueCubes = int.Parse(blueCubes);
                if (int.Parse(greenCubes) > minGreenCubes) minGreenCubes = int.Parse(greenCubes);
                if (int.Parse(redCubes) > minRedCubes) minRedCubes = int.Parse(redCubes);
            }

            return minRedCubes * minGreenCubes * minBlueCubes;
        }
    }
}
