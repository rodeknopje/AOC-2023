namespace AOC.Solutions;

public class D01 : DayBase
{
    protected override int Day => 1;

    public override long Solve_1()
    {
        return GetInputLines().Select(x =>
            x.Where(x => "0123456789".Contains(x))
        ).Select(x => int.Parse($"{x.First()}{x.Last()}")).Sum();
    }

    public override long Solve_2()
    {
        return GetInputLines().Select(x => x
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e").Where(x => "0123456789".Contains(x))
        ).Select(x => int.Parse($"{x.First()}{x.Last()}")).Sum();
    }
}