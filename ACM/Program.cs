using System;
using System.Collections.Generic;
using System.Linq;

string line = null;
var tries = new Dictionary<string, int>();
var totalTime = 0;
var totalProblems = 0;
while ((line = Console.ReadLine()) != "-1")
{
    var submission = line.Split(" ");
    var duration = int.Parse(submission[0]);
    var problem = submission[1];
    var right = submission[2] == "right";

    if (!right)
    {
        tries[problem] = (tries.ContainsKey(problem) ? tries[problem] : 0) + 1;
    }
    else
    {
        var problemTime = (tries.ContainsKey(problem) ? tries[problem] : 0) * 20 + duration;
        totalTime += problemTime;
        totalProblems += 1;
    }

}
Console.WriteLine($"{totalProblems} {totalTime}");