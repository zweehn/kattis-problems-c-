using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

var games = int.Parse(Console.ReadLine());
var memo = new Dictionary<(int b, int d, string currentPlayer), bool>();

for (int n = 0; n < games; n++)
{
    var game = Console.ReadLine().Split(" ");
    var b = int.Parse(game[0]);
    var d = int.Parse(game[1]);
    var player = game[2];

    if (canForceWin(b, d, player))
    {
        Console.WriteLine($"{player} can win");
    }
    else
    {
        Console.WriteLine($"{player} cannot win");
    }
}


bool canForceWin(int b, int d, string currentPlayer)
{
    if (memo.ContainsKey((b, d, currentPlayer)))
    {
        return memo[(b, d, currentPlayer)];
    }
    var result = canForceWinInner(b, d, currentPlayer);
    memo[(b, d, currentPlayer)] = result;
    //Console.WriteLine($"{b}x{d} CurrentPlayer: {currentPlayer} Canwin: {result}");

    return result;
}

bool canForceWinInner(int b, int d, string currentPlayer)
{
    if (b == 1 && d == 1) return false;

    if (b > 1 && d == 1 && currentPlayer == "Vicky") return true;
    if (b == 1 && d > 1 && currentPlayer == "Harry") return true;

    if (b - 10 > d && currentPlayer == "Vicky") return true;
    if (b < d - 10 && currentPlayer == "Harry") return true;

    if (currentPlayer == "Harry")
    {
        for (int i = 1; i < d; i++)
        {
            if (!canForceWin(b, i, "Vicky") && !canForceWin(b, d - i, "Vicky")) return true;
        }
    }

    if (currentPlayer == "Vicky")
    {
        for (int i = 1; i < b; i++)
        {
            if (!canForceWin(i, d, "Harry") && !canForceWin(b - i, d, "Harry")) return true;
        }
    }

    return false;
}
