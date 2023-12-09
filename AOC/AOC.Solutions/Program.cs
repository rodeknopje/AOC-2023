using System.Diagnostics;
using AOC.Solutions;

Console.WriteLine($"1: {new D09().Solve_1()}");
Stopwatch stopWatch = new Stopwatch();
stopWatch.Start();
Console.WriteLine($"2: {new D09().Solve_2()}");
TimeSpan ts = stopWatch.Elapsed;
string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
Console.WriteLine("RunTime " + elapsedTime);
stopWatch.Stop();

