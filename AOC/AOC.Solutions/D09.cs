namespace AOC.Solutions;

public class D09 : DayBase
{
    protected override int Day => 9;

    public override long Solve_1()
    {
        return GetSequenceDifferencesSum('A');
    }

    public override long Solve_2()
    {
        return GetSequenceDifferencesSum('B');
    }

    private int GetSequenceDifferencesSum(char part)
    {
        var sequences = GetInputLines().Select(line => line.Split(" ").Select(int.Parse)).Select(sequence => sequence.ToList()).ToList();

        var sum = 0;
        
        foreach (var sequence in sequences)
        {
            if (part == 'B')
            {
                sequence.Reverse();
            }
            
            var histories = new List<List<int>>
            {
                sequence
            };

            while (histories.Last().Any(x => x != 0))
            {
                var newHistory = new List<int>();

                for (var i = 1; i < histories.Last().Count; i++)
                {
                    newHistory.Add(histories.Last()[i] - histories.Last()[i-1]);
                }
                
                histories.Add(newHistory);
            }

            var lastDifference = 0;
            
            for (var i = histories.Count - 1; i >= 0; i--)
            {
                lastDifference += histories[i].Last();
                histories[i].Add(lastDifference);
            }

            sum += lastDifference;
        }
        
        return sum;
    }
}