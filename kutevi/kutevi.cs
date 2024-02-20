using System;
using System.Linq;
using System.Collections.Generic;

var line1 = Console.ReadLine().Split(" ");
var n = int.Parse(line1[0]);
var k = int.Parse(line1[1]);

var options = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
var challenges = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

int[] state = new int[n];

var memo = new HashSet<(int, int)>();
for (int i = 0; i < k; i++)
{
    Console.WriteLine(backtrack(challenges[i], 0) ? "YES" : "NO");
}


bool backtrack(int challenge, int step)
{
    if (memo.Contains((challenge, step)))
    {
        return false;
    }
    if (backtrack_inner(challenge, step))
    {
        return true;
    }
    else
    {
        memo.Add((challenge, step));
        return false;
    }
}

bool backtrack_inner(int challenge, int step)
{
    if (challenge % 360 == 0)
    {
        return true;
    }
    if (step == n) return false;
    for (int i = 0; i <= 5; i++)
    {
        state[step] = i;
        if (backtrack(challenge - (i * options[step]), step + 1))
        {
            return true;
        }

        state[step] = -i;
        if (backtrack(challenge - (-i * options[step]), step + 1))
        {
            return true;
        }
    }
    return false;
}