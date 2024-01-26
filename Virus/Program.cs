using System;
using System.Collections.Generic;
using System.Linq;

string line1 = Console.ReadLine();
string line2 = Console.ReadLine();

int start = 0;
int end = 10 ^ 5;

if (line1 == line2)
{
    Console.WriteLine("0");
    return 0;
}

for (int i = 0; i < Math.Min(line1.Length, line2.Length); i++)
{
    if (line1[i] != line2[i])
    {
        start = i;
        break;
    }
}


for (int i = 1; i < Math.Min(line1.Length, line2.Length); i++)
{
    if (line1[line1.Length - i] != line2[line2.Length - i])
    {
        end = line2.Length - i;
        break;
    }
}

Console.WriteLine(end - start + 1);

return 0;