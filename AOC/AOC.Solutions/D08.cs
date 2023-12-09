using System.Text.RegularExpressions;

namespace AOC.Solutions;

public partial class D08 : DayBase
{
    protected override int Day => 8;
    
    public override long Solve_1()
    {
        var lines = GetInputLines();
        
        var elements = new Dictionary<string, (string left, string right)>();
        
        foreach (var line in lines.Skip(2))
        {
            var matches = new Regex(@"\w+").Matches(line);

            elements.Add(matches[0].ToString(), (matches[1].ToString(), matches[2].ToString()));

        }

        var element = "AAA";
        
        var directions = lines.First();

        var steps = 0;
        
        while (element != "ZZZ")
        {
            var direction = directions[0];
            
            element = direction == 'L' ? elements[element].left : elements[element].right;

            directions += direction;
            directions = directions.Remove(0, 1);

            steps++;
        }

        return steps;
    }

    public override long Solve_2()
    {
        var lines = GetInputLines();
        
        var elements = new Dictionary<string, (string left, string right)>();
        
        foreach (var line in lines.Skip(2))
        {
            var matches = MyRegex().Matches(line);

            elements.Add(matches[0].ToString(), (matches[1].ToString(), matches[2].ToString()));
        }
        
        var directions = lines.First();

        var currentElements = elements.Keys.Where(x => x.Contains('A')).ToHashSet();

        var steps = 0;

        var numbers = new List<long>();
        
        while (currentElements.Any())
        {
            // if (currentElements.Count == 1)
            // {
            //     Console.WriteLine("hoi");
            // }
            
            var newCurrentElements = new HashSet<string>();
            
            var direction = directions[0];
            
            steps++;

            
            foreach (var element in currentElements)
            {
                var newElement = direction == 'L' ? elements[element].left : elements[element].right;

                
                if(newElement.Contains('Z'))
                {
                    numbers.Add(steps);
                }
                else
                {
                    newCurrentElements.Add(newElement);
                }
            }
            
            

            currentElements = newCurrentElements;
            
            directions += direction;
            directions = directions.Remove(0, 1);

        }

        return GetLeasCommonMultiple(numbers.ToArray());
    }
    
    public long GetLeasCommonMultiple(long[] numbers)
    {
        var highest = numbers.Max();
        var current = highest;

        while (numbers.All(x => x % current == 0) == false)
        {
            current += highest;
        }

        return current;
    }

    [GeneratedRegex("\\w+")]
    private static partial Regex MyRegex();
}