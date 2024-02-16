using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;


var n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    var line = Console.ReadLine();

    parseTree(line);
}

static int parseTree(string nodeString)
{
    Regex r = MyRegex();
    Console.WriteLine("Parsing: " + nodeString);
    Match m = r.Match(nodeString);

    int weight = 0;

    if (m.Groups[1].Value.StartsWith("["))
    {
        weight += parseTree(m.Groups[1].Value);
    }
    else
    {
        Console.WriteLine("Left:" + m.Groups[1].Value);
        weight += int.Parse(m.Groups[1].Value);
    }

    if (m.Groups[2].Value.StartsWith("["))
    {
        weight += parseTree(m.Groups[2].Value);
    }
    else
    {
        Console.WriteLine("Right:" + m.Groups[2].Value);
        weight += int.Parse(m.Groups[2].Value);
    }

    return weight;
}

partial class Program
{
    [GeneratedRegex("\\[(.+),(.+)\\]")]
    private static partial Regex MyRegex();
}

Ach du scheiße ist das kompliziert.
Jede node einen Baum weiter unten darf einfach nur halb so viel Wert sein, wie weiter oben.
Es wird gesucht, welche die häufigste Folge dieser Doppelungen ist, und diese 