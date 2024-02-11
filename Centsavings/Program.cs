using System;
using System.Collections.Generic;
using System.Linq;

string line1 = Console.ReadLine();
string line2 = Console.ReadLine();

var n = int.Parse(line1.Split(" ")[0]);
var d = int.Parse(line1.Split(" ")[1]);


int[] items = line2.Split(" ").Select(i => int.Parse(i)).ToArray();

Dictionary<(int, int), int> memo = new();

// base cases, n=0
for (int i = 0; i <= d; i++)
{
    memo[(0, i)] = 0;
}

// base cases, d=0
for (int i = 1; i <= n; i++)
{
    memo[(i, 0)] = memo[(i - 1, 0)] + items[i - 1];
}

// Recurrence
for (int i = 1; i <= n; i++)
{
    for (int j = d; j > 0; j--)
    {
        memo[(i, j)] = Math.Min(memo[(i - 1, j)] + items[i - 1], round(memo[(i - 1, j - 1)] + items[i - 1]));
    }
}

// Extract answer
int ans = int.MaxValue;
for (int i = 0; i <= d; i++)
{
    ans = Math.Min(ans, round(memo[(n, i)]));
}

Console.WriteLine(ans);

// int minValue(int to, int dividers)
// {
//     if (memo.ContainsKey((to, dividers)))
//     {
//         return memo[(to, dividers)];
//     }
//     else
//     {
//         int value = minValueInner(to, dividers);
//         memo[(to, dividers)] = value;
//         return value;
//     }
// }

// int minValueInner(int to, int dividers)
// {
//     if (to == 0)
//     {
//         return 0;
//     }
//     if (dividers == 0)
//     {
//         return items[0..to].Sum();
//     }

//     int min = int.MaxValue;
//     for (int i = 0; i < to; i++)
//     {
//         min = Math.Min(min, round(minValue(i, dividers - 1)) + round(items[i..to].Sum()));
//         //Console.WriteLine(dividers + " Min is " + min + "Value of " + i + " is: " + round(minValue(i, dividers - 1)) + " and " + round(items[(i)..to].Sum()));
//     }
//     return min;
// }
// Console.WriteLine(minValue(items.Length, d));

int round(int value)
{
    var mod = value % 10;
    if (mod < 5)
    {
        return value - mod;
    }
    else
    {
        return value - mod + 10;
    }
}


return 0;