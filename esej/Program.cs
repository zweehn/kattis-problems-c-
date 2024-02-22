using System;

string line = Console.ReadLine();
var a = int.Parse(line.Split(" ")[0]);
var b = int.Parse(line.Split(" ")[1]);

int minWords = Math.Max(a, b / 2 + 1);

char[] word = "aaaaaa".ToCharArray();

for (int i = 0; i < minWords; i++)
{
    GenerateWord();
}

void GenerateWord()
{
    word[0] = (char)(word[0] + 1);
    int step = 0;

    while (word[step] > 'z')
    {
        word[step] = 'a';
        step = step + 1;
        word[step] = (char)(word[step] + 1);
    }

    foreach (char c in word) Console.Write(c);
    Console.Write(" ");
}