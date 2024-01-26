using System;
using System.Collections.Generic;
using System.Linq;


string line;
long c;
long d;

line = Console.ReadLine();

var split1 = line.Split(" ");
c = Int64.Parse(split1[0]);
d = Int64.Parse(split1[1]);


var a = 1000000L;
var b = 1000000L;
bool afinal = false;
bool bfinal = false;

line = Console.ReadLine();
var split2 = line.Split(" ");
for (long i = c; i <= d; i++)
{
    if (isFizz(split2[i - c]))
    {
        if (i < a)
        {
            a = i;
        }
        else if (afinal == false)
        {
            a = i - a;
            afinal = true;
        }
    }

    if (isBuzz(split2[i - c]))
    {
        if (i < b)
        {
            b = i;
        }
        else if (bfinal == false)
        {
            b = i - b;
            bfinal = true;
        }
    }
}


bool isFizz(string s)
{
    return s.Contains("Fizz");
}
bool isBuzz(string s)
{
    return s.Contains("Buzz");
}

Console.WriteLine(a + " " + b);