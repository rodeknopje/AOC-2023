namespace AOC.Solutions;

public class D06 : DayBase
{
    protected override int Day => 6;

    public override long Solve_1()
    {
        var times = new List<int> { 47, 70, 75, 66 };

        var distances = new List<int> { 282, 1079, 1147, 1062 };

        var score = 1;

        for (var i = 0; i < 4; i++)
        {
            var ways = 0;

            for (var j = 0; j < times[i]; j++)
            {
                var success = j * (times[i] - j) > distances[i];

                if (success)
                {
                    ways++;
                }
            }

            score *= ways;
        }

        return score;
    }

    public override long Solve_2()
    {
        return Enumerable.Range(0,47707566).Count(n => n*(47707566L-n)>282107911471062);
    }
}