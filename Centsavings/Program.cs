using System;
using System.Collections.Generic;
using System.Linq;

string line1 = Console.ReadLine();
string line2 = Console.ReadLine();

var n = int.Parse(line1.Split(" ")[0]);
var d = int.Parse(line1.Split(" ")[1]);


int[] items = line2.Split(" ").Select(i => int.Parse(i)).ToArray();

Dictionary<(int, int), int> memory = new Dictionary<(int, int), int>();

int minValue(int to, int dividers)
{
    if (memory.ContainsKey((to, dividers)))
    {
        return memory[(to, dividers)];
    }
    else
    {
        int value = minValueInner(to, dividers);
        memory[(to, dividers)] = value;
        return value;
    }
}

int minValueInner(int to, int dividers)
{
    if (to == 0)
    {
        return 0;
    }
    if (dividers == 0)
    {
        return minValue(to - 1, 0) + items[to];
    }
    else
    {
        int min = int.MaxValue;
        for (int i = 0; i < to; i++)
        {
            min = Math.Min(min, round(minValue(i, dividers - 1)) + round(items[i..to].Sum()));
            //Console.WriteLine(dividers + " Min is " + min + "Value of " + i + " is: " + round(minValue(i, dividers - 1)) + " and " + round(items[(i)..to].Sum()));
        }
        return min;
    }

}

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

Console.WriteLine(minValue(items.Length, d));

return 0;