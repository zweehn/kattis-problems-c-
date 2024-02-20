using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());

var stack = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToList();


for (int i = 1; i < n; i++)
{
    if ((stack[i - 1] + stack[i]) % 2 == 0)
    {
        stack.RemoveRange(i - 1, 2);
        n -= 2;
        i = Math.Max(i - 2, 1);
        if (i > 1)
        {
            i -= 2;
        }
        else
        {
            i -= 1;
        }
    }
}

Console.WriteLine(stack.Count);