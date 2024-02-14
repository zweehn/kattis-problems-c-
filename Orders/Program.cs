using System;
using System.Collections.Generic;
using System.Linq;

_ = Console.ReadLine();
var items = Console.ReadLine().Split(" ").Select(i => int.Parse(i));
_ = Console.ReadLine();
var orders = Console.ReadLine().Split(" ").Select(i => int.Parse(i));

HashSet<int> ambiguous = new HashSet<int>();
var values = new Dictionary<int, int[]>();
var maxOrder = orders.Max();

foreach (var (item, index) in items.Select((item, index) => (item, index)))
{
    var prev = values.ToDictionary(k => k.Key, v => v.Value);

    {
        int value = 0;
        while (value <= maxOrder)
        {
            value += item;
            if (values.ContainsKey(value))
            {
                ambiguous.Add(value);
            }
            else
            {
                values[value] = (values.ContainsKey(value - item) ? values[value - item] : new int[0]).Concat(new int[] { index + 1 }).ToArray();
            }
        }
    }

    foreach (var (v, i) in prev)
    {
        int value = v;
        while (value <= maxOrder)
        {
            value += item;
            if (values.ContainsKey(value))
            {
                ambiguous.Add(value);
            }
            else
            {
                values[value] = values[value - item].Concat(new int[] { index + 1 }).ToArray();
            }
        }
    }
}

foreach (var order in orders)
{
    if (ambiguous.Contains(order))
    {
        Console.WriteLine("Ambiguous");
    }
    else if (values.ContainsKey(order))
    {
        Console.WriteLine(string.Join(' ', values[order]));
    }
    else
    {
        Console.WriteLine("Impossible");
    }
}

