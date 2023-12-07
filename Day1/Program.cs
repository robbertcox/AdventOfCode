// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

string[] lines = File.ReadAllLines("../input.txt");

int sum = 0;
Dictionary<string, int> map = new Dictionary<string, int>()
{
    //{"zero", 0 },
    {"one" ,   1},
    {"two" ,  2},
    {"three" , 3},
    {"four" , 4},
    {"five" , 5},
    {"six" , 6},
    {"seven" , 7},
    {"eight" , 8},
    {"nine" , 9 },
};

Dictionary<string, int> reverse = map.ToDictionary(k => new string(k.Key.Reverse().ToArray()), k => k.Value);

foreach (string line in lines)
{
    int first = GetValue(line, map);
    int last = GetValue(new string(line.Reverse().ToArray()), map.ToDictionary(k => new string(k.Key.Reverse().ToArray()), k => k.Value));
    sum += first *10 + last;
    //foreach (char c in line)
    //{
    //    if (char.IsDigit(c))
    //    {
    //        if (first == null) first = int.Parse(c.ToString());
    //        last = int.Parse(c.ToString());
    //    }
    //}
    //    sum += ((int)first * 10) + last;
}
Console.WriteLine($"Result = {sum}");



int GetValue(string line, Dictionary<string, int> map)
{
    int index = 0;
    int digit = 0;
    foreach (var c in line)
    {
        var sub = line.AsSpan(index++);
        foreach (var n in map)
        {
            if (sub.StartsWith(n.Key))
            {
                digit = n.Value;
                goto end;
            }
        }

        if ((int)c >= 48 && (int)c <= 57)
        {
            digit = ((int)c) - 48;
            break;
        }
    }
end:
    return digit;
}
