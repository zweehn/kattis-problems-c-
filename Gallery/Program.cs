using System;
using System.Collections.Generic;
using System.Linq;


string line;
int counter = 0;
int n;
int k;

const int LEFT = 1;
const int RIGHT = 2;

line = Console.ReadLine();

{
    var split = line.Split(" ");
    n = Int32.Parse(split[0]);
    k = Int32.Parse(split[1]);
}

int[,] rooms = new int[n, 3];
int[] closed = new int[n];

while ((line = Console.ReadLine()) != null && counter < n)
{
    var split = line.Split(" ");
    rooms[counter, LEFT] = Int32.Parse(split[0]);
    rooms[counter, RIGHT] = Int32.Parse(split[1]);
    counter++;
}

Dictionary<(int, int, int), int> memory = new Dictionary<(int, int, int), int>();

int maxValue(int from, int prevclose, int remk)
{
    if (memory.ContainsKey((from, prevclose, remk)))
    {
        return memory[(from, prevclose, remk)];
    }
    else
    {
        int value = maxValueInner(from, prevclose, remk);
        memory[(from, prevclose, remk)] = value;
        return value;
    }
}

int maxValueInner(int from, int prevclose, int remk)
{
    if (from == n - 1)
    {
        if (remk > 1) return int.MinValue;
        if (remk == 1)
        {
            if (prevclose == 0) return Math.Max(rooms[from, LEFT], rooms[from, RIGHT]);
            else if (prevclose == LEFT) return rooms[from, RIGHT];
            else if (prevclose == RIGHT) return rooms[from, LEFT];
            else return 0;
        }
        else
        {
            return rooms[from, LEFT] + rooms[from, RIGHT];
        }
    }
    else if (from >= n)
    {
        return 0;
    }

    int max = Int32.MinValue;
    if (prevclose == 0)
    {
        if (remk == 0)
        {
            max = Math.Max(max, rooms[from, LEFT] + rooms[from, RIGHT] + maxValue(from + 1, 0, remk));
        }
        else
        {
            max = Math.Max(max, rooms[from, LEFT] + maxValue(from + 1, RIGHT, remk - 1)); // Close room 1
            max = Math.Max(max, rooms[from, RIGHT] + maxValue(from + 1, LEFT, remk - 1)); // Close room 2
            max = Math.Max(max, rooms[from, LEFT] + rooms[from, RIGHT] + maxValue(from + 1, 0, remk)); // Close no room
        }
    }
    else if (prevclose == LEFT)
    {
        if (remk == 0)
        {
            max = Math.Max(max, rooms[from, RIGHT] + maxValue(from + 1, 0, remk));
        }
        else
        {
            max = Math.Max(max, rooms[from, RIGHT] + maxValue(from + 1, LEFT, remk - 1)); // Close room LEFT
            max = Math.Max(max, rooms[from, LEFT] + rooms[from, RIGHT] + maxValue(from + 1, 0, remk)); // Close no room
        }
    }
    else if (prevclose == RIGHT)
    {
        if (remk == 0)
        {
            max = Math.Max(max, rooms[from, LEFT] + maxValue(from + 1, 0, remk));
        }
        else
        {
            max = Math.Max(max, rooms[from, LEFT] + maxValue(from + 1, RIGHT, remk - 1)); // Close room RIGHT
            max = Math.Max(max, rooms[from, LEFT] + rooms[from, RIGHT] + maxValue(from + 1, 0, remk)); // Close no room
        }
    }
    return max;
}

Console.WriteLine(maxValue(0, 0, k));