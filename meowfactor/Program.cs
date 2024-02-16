using System;

var num = long.Parse(Console.ReadLine());

long res = 1;
for (long i = 2; i < 128; i++)
    if ((num % System.Numerics.BigInteger.Pow(i, 9)) == 0)
        res = i;

Console.WriteLine(res);