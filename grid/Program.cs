using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


var dimensions = Console.ReadLine().Split(" ").Select(s => int.Parse(s)).ToArray();
int n = dimensions[0];
int m = dimensions[1];

int[,] grid = new int[n, m];

for (int x = 0; x < n; x++)
{
    string line = Console.ReadLine();
    for (int y = 0; y < m; y++)
    {
        grid[x, y] = line[y] - '0';
    }
}

int[,] targets = new int[n, m];
var queue = new PriorityQueue<(int x, int y), int>();
queue.Enqueue((0, 0), 0);

while (queue.TryDequeue(out var coord, out int length))
{
    var x = coord.x;
    var y = coord.y;
    //Console.WriteLine("Testing: " + x + " " + y + "Length currently is: " + length);
    if (targets[x, y] != 0) continue;
    if (x == n - 1 && y == m - 1)
    {
        Console.WriteLine(length);
        return 0;
    }


    var num = grid[coord.x, coord.y];
    targets[x, y] = length + 1;
    if (x - num >= 0)
    {
        queue.Enqueue((x - num, y), length + 1);
    }
    if (x + num < n)
    {
        queue.Enqueue((x + num, y), length + 1);
    }
    if (y - num >= 0)
    {
        queue.Enqueue((x, y - num), length + 1);
    }
    if (y + num < m)
    {
        queue.Enqueue((x, y + num), length + 1);
    }
}

Console.WriteLine("-1");
return 0;