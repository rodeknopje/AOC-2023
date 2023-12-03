﻿using System.Text.RegularExpressions;

namespace AOC.Solutions;

public class D03 : DayBase
{
    protected override int Day => 3;

    public override long Solve_1()
    {
        var map = GetInputCharMap();
        
        var symbols = new List<(int y, int x)>();

        for (var y = 0; y < map.GetLength(1); y++)
        for (var x = 0; x < map.GetLength(0); x++)
        {
            var current = map[y, x] + "";
            
            if (new Regex(@"([0-9]|[\.])").IsMatch(current) == false)
            {
                symbols.Add((x, y));
            }
        }

        var sum = 0;
        
        for (var y = 0; y < map.GetLength(1); y++)
        {
            var isValid = false;
            var number = "";
            
            for (var x = 0; x < map.GetLength(0); x++)
            {
                var current = map[y, x].ToString();
                
                if (new Regex("[0-9]").IsMatch(current))
                {
                    number += current;
                    
                    if (
                        symbols.Contains((x + 1, y)) ||
                        symbols.Contains((x - 1, y)) ||
                        symbols.Contains((x, y + 1)) ||
                        symbols.Contains((x, y - 1)) ||
                        symbols.Contains((x + 1, y - 1)) ||
                        symbols.Contains((x + 1, y + 1)) ||
                        symbols.Contains((x - 1, y + 1)) ||
                        symbols.Contains((x - 1, y - 1)))
                    {
                        isValid = true;
                    }
                }
                else 
                {
                    if (number.Length > 0 && isValid)
                    {
                        sum += int.Parse(number);
                    }
                    isValid = false;
                    number = "";
                }
            }
            if (number.Length > 0 && isValid)
            {
                sum += int.Parse(number);
            }
        }


        return sum;
    }

    public override long Solve_2()
    {
        var map = GetInputCharMap();
        var symbols = new Dictionary<(int y, int x), List<int>>();
    
        for (var y = 0; y < map.GetLength(1); y++)
        for (var x = 0; x < map.GetLength(0); x++)
        {
            var current = map[y, x] + "";
            if (new Regex(@"([0-9]|[\.])").IsMatch(current) == false)
            {
                symbols.Add((x,y), new List<int>());
            }
        }
    
        
        for (var y = 0; y < map.GetLength(1); y++)
        {
            var number = "";
            
            (int x, int y)? adjacent = null;
            
            for (var x = 0; x < map.GetLength(0); x++)
            {
                var current = map[y, x] + "";
                
                if (new Regex("[0-9]").IsMatch(current))
                {
                    number += current;

                    if (adjacent is not null)
                    {
                        continue;
                    }
                    if (symbols.ContainsKey((x - 1, y)))
                    {
                        adjacent = (x - 1, y);
                    }
                    if (symbols.ContainsKey((x + 1, y)))
                    {
                        adjacent = (x + 1, y);
                    }
                    if (symbols.ContainsKey((x, y + 1)))
                    {
                        adjacent = (x, y + 1);
                    }
                    if (symbols.ContainsKey((x, y -1 )))
                    {
                        adjacent = (x,y-1);
                    }
                    if (symbols.ContainsKey((x + 1, y+1)))
                    {
                        adjacent = (x + 1, y + 1);
                    }
                    if (symbols.ContainsKey((x + 1, y-1)))
                    {
                        adjacent = (x + 1, y - 1);
                    }
                    if (symbols.ContainsKey((x - 1, y+1)))
                    {
                        adjacent = (x - 1, y + 1);
                    }
                    if (symbols.ContainsKey((x - 1, y-1)))
                    {
                        adjacent = (x - 1, y - 1);
                    }
                }
                else 
                {
                    if (number.Length > 0 && adjacent is not null)
                    {
                        symbols[adjacent.Value].Add(int.Parse(number));
                    }
                    number = "";
                    adjacent = null;
                }
            }
            if (number.Length > 0 && adjacent is not null)
            {
                symbols[adjacent.Value].Add(int.Parse(number));
            }

        }

        return symbols.Values.Where(values => values.Count == 2).Sum(values => values[0] * values[1]);
    }
}