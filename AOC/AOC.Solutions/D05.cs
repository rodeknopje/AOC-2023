namespace AOC.Solutions;

public class D05 : DayBase
{
    protected override int Day => 5;

    public override long Solve_1()
    {
        var lines = GetInputLines();

        var seeds = lines.First().Split(": ").Last().Split(" ").Select(long.Parse);

        var converters = new List<List<List<(long destination, long source, long length)>>>();

        foreach (var line in lines.Skip(2).Where(x => x != ""))
        {
            if (line == "" || line.Contains('-'))
            {
                converters.Add(new List<List<(long destination, long source, long length)>>());

                continue;
            }

            converters.Last().Add(new List<(long destination, long source, long length)>());

            var numbers = line.Split(" ").Select(long.Parse).ToList();

            converters.Last().Last().Add((numbers[0], numbers[1], numbers[2]));
        }

        var lowest = long.MaxValue;

        foreach (var seed in seeds)
        {
            var seedValue = seed;

            foreach (var converterx in converters)
            {
                var converted = false;
                foreach (var converter in converterx)
                foreach (var values in converter)
                {
                    if (!converted && seedValue >= values.source && seedValue < values.source + values.length)
                    {
                        seedValue = values.destination + seedValue - values.source;

                        converted = true;
                    }
                }
            }

            lowest = seedValue < lowest ? seedValue : lowest;
        }

        return lowest;
    }

    // public override long Solve_2()
    // {
    //     var lines = GetInputLines();
    //
    //     var ranges = lines.First().Split(": ").Last().Split(" ").Select(long.Parse);
    //
    //     var converters = new List<List<List<(long destination, long source, long length)>>>();
    //
    //     foreach (var line in lines.Skip(2).Where(x => x != ""))
    //     {
    //         if (line == "" || line.Contains('-'))
    //         {
    //             converters.Add(new List<List<(long destination, long source, long length)>>());
    //
    //             continue;
    //         }
    //
    //         converters.Last().Add(new List<(long destination, long source, long length)>());
    //
    //         var numbers = line.Split(" ").Select(long.Parse).ToList();
    //
    //         converters.Last().Last().Add((numbers[0], numbers[1], numbers[2]));
    //     }
    //     
    //     
    //     foreach (var seed in seeds)
    //     {
    //         var seedValue = seed;
    //
    //         foreach (var converterx in converters)
    //         {
    //             var converted = false;
    //             foreach (var converter in converterx)
    //             foreach (var values in converter)
    //             {
    //                 if (!converted && seedValue >= values.source && seedValue < values.source + values.length)
    //                 {
    //                     seedValue = values.destination + seedValue - values.source;
    //
    //                     converted = true;
    //                 }
    //             }
    //         }
    //
    //     }
    // }

    public override long Solve_2()
    {
        var lines = GetInputLines();
    
        var seeds = lines.First().Split(": ").Last().Split(" ").Select(long.Parse).ToList();
    
        var seedRanges = new HashSet<(long start, long end)>();
    
        for (var i = 0; i < seeds.Count; i += 2)
        {
            seedRanges.Add((seeds[i], Math.Max(0, seeds[i] + seeds[i + 1] - 1 )));
        }
    
        var converters = new List<List<List<(long destination, long source, long length)>>>();
    
        var lowest = long.MaxValue;
    
        foreach (var line in lines.Skip(2).Where(x => x != ""))
        {
            if (line == "" || line.Contains('-'))
            {
                converters.Add(new List<List<(long destination, long source, long length)>>());
    
                continue;
            }
    
            converters.Last().Add(new List<(long destination, long source, long length)>());
    
            var numbers = line.Split(" ").Select(long.Parse).ToList();
    
            converters.Last().Last().Add((numbers[0], numbers[1], numbers[2]));
        }
    
    
        foreach (var converterx in converters)
        {
            var converted = false;
            
            var newSeedRanges = new HashSet<(long start, long end)>();
            
            foreach (var converter in converterx)
            {
                foreach (var seedRange in seedRanges)
                {
                    foreach (var values in converter)
                    {
                        if (
                            seedRange.end <  values.source  ||
                            seedRange.start > values.source + Math.Max(0, values.length-1))
                        {
                            newSeedRanges.Add(seedRange);
                            continue;
                        }

                        (long start, long end) newRange = (0, 0);

                        var newring = (
                            start: Math.Max(seedRange.start, values.source) - values.source + values.destination, 
                            end: Math.Min(seedRange.end, values.source + values.length)  - values.source + values.destination);

                        newSeedRanges.Add(newRange);
                    }
                }
                
            }
            seedRanges = newSeedRanges;

        }
    
    
        
        return lowest;
    }
}