using System;
using System.Collections.Generic;
using System.Linq;

string line1 = Console.ReadLine();
string line2 = Console.ReadLine();

Dictionary<(string, string), int> cache = new();

int levenstein(string a, string b)
{
    if (cache.ContainsKey((a, b))) return cache[(a, b)];
    var result = levensteinInner(a, b);
    cache[(a, b)] = result;

    return result;
}

int levensteinInner(string a, string b)
{
    if (a.Length == 0) return b.Length;
    if (b.Length == 0) return a.Length;
    if (a[0] == b[0]) return levenstein(a[1..], b[1..]);

    Console.WriteLine(a + " " + b);

    int min = int.MaxValue;
    min = Math.Min(min, levenstein(a[1..], b));
    //min = Math.Min(min, 1 + levenstein(a[1..], b[1..]));
    min = Math.Min(min, 1 + levenstein(a, b[1..]));
    return min;
}

Console.WriteLine(levenstein(line1, line2));

return 0;