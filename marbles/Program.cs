using System;
using System.Collections.Generic;
using System.Linq;

while (true)
{
    int n = int.Parse(Console.ReadLine());
    if (n == 0) break;

    var tree = new Dictionary<int, Node>();
    var notRoot = new HashSet<int>();

    for (int v = 0; v < n; v++)
    {
        var parts = Console.ReadLine().Split(" ").Select(p => Int32.Parse(p)).ToList();
        var v1 = parts[0];
        var m = parts[1];
        var d = parts[2];
        var children = parts.Skip(3).ToList();
        tree.Add(v1, new Node(v1, m, d, children));
        foreach (var child in children)
        {
            // Element that is a child cannot be a root node
            notRoot.Add(child);
        }
    }
    int root = tree.Keys.First(id => !notRoot.Contains(id));

    // DFS
    int moves = moveMarblesUp(tree, root, -1);
    Console.WriteLine(moves);

}

int moveMarblesUp(Dictionary<int, Node> tree, int currentNode, int parent)
{
    int result = 0;
    foreach (int child in tree[currentNode].children)
    {
        result += moveMarblesUp(tree, child, currentNode);
    }

    //Console.WriteLine($"{currentNode} with {tree[currentNode].marbles} marbles");

    if (tree[currentNode].marbles != 1 && parent != -1)
    {
        result += Math.Abs(tree[currentNode].marbles - 1);
        // Move marbles a node up
        tree[parent] = tree[parent] with { marbles = tree[parent].marbles + tree[currentNode].marbles - 1 };
    }

    //Console.WriteLine(result);

    return result;
}

record Node(int id, int marbles, int d, List<int> children);