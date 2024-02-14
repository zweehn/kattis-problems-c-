using System;
using System.Collections.Generic;
using System.Linq;

var split = Console.ReadLine().Split(" ");
var n = int.Parse(split[0]);
var m = int.Parse(split[1]);

var connected = new HashSet<int>() { 1 };
var nonInternetCables = new Dictionary<int, List<int>>();

string line;
while ((line = Console.ReadLine()) != null)
{
    var a = int.Parse(line.Split(" ")[0]);
    var b = int.Parse(line.Split(" ")[1]);
    if (connected.Contains(a))
    {
        ConnectRecursive(b);
    }
    else if (connected.Contains(b))
    {
        ConnectRecursive(a);
    }
    else
    {
        if (nonInternetCables.TryGetValue(a, out List<int> connections2))
        {
            connections2.Add(b);
        }
        else
        {
            nonInternetCables.Add(a, new List<int>() { b });
        }

        if (nonInternetCables.TryGetValue(b, out List<int> connections))
        {
            connections.Add(a);
        }
        else
        {
            nonInternetCables.Add(b, new List<int>() { a });
        }
    }
}

void ConnectRecursive(int house)
{
    connected.Add(house);
    if (nonInternetCables.TryGetValue(house, out var connections))
    {
        nonInternetCables.Remove(house);
        foreach (var connection in connections)
        {
            if (!connected.Contains(connection))
            {
                ConnectRecursive(house);
            }
        }
    }
}

bool notConnected = false;
for (int i = 1; i <= n; i++)
{
    if (!connected.Contains(i))
    {
        notConnected = true;
        Console.WriteLine(i);
    }
}
if (!notConnected)
{
    Console.WriteLine("Connected");
}