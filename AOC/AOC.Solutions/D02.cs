using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D02 : DayBase
{
    protected override int Day => 2;

    public override long Solve_1()
    {
        var regex = new Regex(@"(\d+\s(blue|red|green))");

        var lines = GetInputLines();

        var sum = 0;

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];

            var validGame = true;

            foreach (var match in regex.Matches(line).Select(x => x + ""))
            {
                int blue = 0, red = 0, green = 0;

                var count = int.Parse(match.Split(" ")[0]);

                if (match.Contains("red"))
                    red = count;
                if (match.Contains("green"))
                    green = count;
                if (match.Contains("blue"))
                    blue = count;

                if (red > 12 || green > 13 || blue > 14)
                {
                    validGame = false;
                }
            }

            if (validGame)
            {
                sum += i + 1;
            }
        }

        return sum;
    }

    public override long Solve_2()
    {
        var regex = new Regex(@"(\d+\s(blue|red|green))");

        var totalPower = 0;

        foreach (var line in GetInputLines())
        {
            int maxBlueCubes = 0, maxRedCubes = 0, maxGreenCubes = 0;

            foreach (var match in regex.Matches(line).Select(x => x.ToString()))
            {
                var count = int.Parse(match.Split(" ")[0]);

                if (match.Contains("blue"))
                    maxBlueCubes = maxBlueCubes > count ? maxBlueCubes : count;
                if (match.Contains("red"))
                    maxRedCubes = maxRedCubes > count ? maxRedCubes : count;
                if (match.Contains("green"))
                    maxGreenCubes = maxGreenCubes > count ? maxGreenCubes : count;
            }

            var power = maxGreenCubes * maxBlueCubes * maxRedCubes;

            totalPower += power;
        }

        return totalPower;
    }
}