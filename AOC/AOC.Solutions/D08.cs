using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D08 : DayBase
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
            var matches = new Regex(@"\w+").Matches(line);

            elements.Add(matches[0].ToString(), (matches[1].ToString(), matches[2].ToString()));
        }
        
        var directions = lines.First();

        var currentElements = elements.Keys.Where(x => x.Contains('A')).ToHashSet();

        var steps = 0;
        
        while (true)
        {
            var newCurrentElements = new HashSet<string>();
            
            var direction = directions[0];
            
            foreach (var element in currentElements)
            {
                var newElement = direction == 'L' ? elements[element].left : elements[element].right;

                newCurrentElements.Add(newElement);
            }

            if (currentElements.Count > newCurrentElements.Count)
            {
                Console.WriteLine(newCurrentElements.Count);
            }
            
            steps++;

            currentElements = newCurrentElements;

            if (newCurrentElements.All(x => x.Contains('Z')))
            {
                break;
            }
            
            directions += direction;
            directions = directions.Remove(0, 1);

        }

        return steps;
    }
}