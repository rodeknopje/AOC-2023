using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D04 : DayBase
{
    protected override int Day => 4;

    private Regex _numberRegex = new Regex(@"[0-9]+");
    
    public override long Solve_1()
    {
        var sum = 0;
        
        foreach (var line in GetInputLines())
        {
            var nums1 = _numberRegex.Matches(line.Split("|").First().Split(":").Last()).Select(x => x.ToString());
            var nums2 = _numberRegex.Matches(line.Split("|").Last()).Select(x => x.ToString());;
           
            var x = nums1.Intersect(nums2).ToArray();

            if (x.Any())
            {
                sum += (int)Math.Pow(2, x.Length - 1);
            }
        }

        return sum;
    }

    public override long Solve_2()
    {

        var lines = GetInputLines();

        var cards = new long[lines.Count];
        
        Array.Fill(cards,1);
        
        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];

            var nums1 = _numberRegex.Matches(line.Split("|").First().Split(":").Last()).Select(x => x.ToString());
            var nums2 = _numberRegex.Matches(line.Split("|").Last()).Select(x => x.ToString());;

            var wins = nums1.Intersect(nums2).Count();

            for (var j = 0; j < wins; j++)
            {
                if (j < lines.Count)
                {
                    cards[i+j+1] += cards[i];
                }
            }
        }
        
        return cards.Sum();
    }


}
