// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string[]? data;
data = File.ReadAllLines("../../../Input.txt");
int sum = 0;
int tempValue = 0;
bool valid = false;
bool test = false;
int prevSum = 0;

for (var y = 0; y < data.Count(); y++)
{
    for (var x = 0; x < data[y].Length; x++)
    {
        char c = data[y][x];

        if (char.IsDigit(c))
        {
            tempValue = (tempValue * 10) + (c - '0');
            if (BordersSpecialChar(x, y, data))
            {
                valid = true;
            }
        }
        else// (c == '.')
        {
            if (valid)
                sum += tempValue;
            valid = false;
            tempValue = 0;
        }

        prevSum = sum;
    }
    if (valid)
        sum += tempValue;
    valid = false;
    tempValue = 0;
}

Console.WriteLine(sum);


for (var y = 0; y < data.Count(); y++)
{
    for (var x = 0; x < data[y].Length; x++)
    {
        char c = data[y][x];
        if (c == '*')
        {
            var number = BordersNumber(x, y, data);
            if (number == 2)
            {
                test = false;
            }
            //find 2 number parts

            //build numbers

            //Calcualte ratio

            //calcualte sum 


        }
    }
}



int BordersNumber(int x, int y, string[] lines)
{
    int[] results = new int[2];
    int numbers = 0;
    if (x > 0 && y > 0 && char.IsDigit(lines[y - 1][x - 1]))
    {
        results[numbers] = GetNumber(x - 1, y - 1, lines);
        numbers++;
    }
    if (numbers > 0) return results[0] * results[1];

    return 0;
    /*
    if (x > 0 && char.IsDigit(lines[y][x - 1]))
    {
        result1 += 1;
    }
    if (x > 0 && y < lines.Count() - 1 && char.IsDigit(lines[y + 1][x - 1]))
    {
        result1 += 1;
    }
    if (y > 0 && char.IsDigit(lines[y - 1][x]))
    {
        result1 += 1;
    }
    if (y < lines.Count() - 1 && char.IsDigit(lines[y + 1][x]))
    {
        result1 += 1;
    }
    if (x < lines[y].Length - 1 && y > 0 && char.IsDigit(lines[y - 1][x + 1]))
    {
        result1 += 1;
    }
    if (x < lines[y].Length - 1 && char.IsDigit(lines[y][x + 1]))
    {
        result1 += 1;
    }
    if (x < lines[y].Length - 1 && y < lines.Count() - 1 && char.IsDigit(lines[y + 1][x + 1]))
    {
        result1 += 1;
    }

    return result1;*/
}


bool BordersSpecialChar(int x, int y, string[] lines)
{
    bool result = false;
    if (x > 0 && y > 0 && !result)
    {
        result = IsSpecialChar(lines[y - 1][x - 1]);
    }
    if (x > 0 && !result)
    {
        result = IsSpecialChar(lines[y][x - 1]);
    }
    if (x > 0 && y < lines.Count() - 1 && !result)
    {
        result = IsSpecialChar(lines[y + 1][x - 1]);
    }
    if (y > 0 && !result)
    {
        result = IsSpecialChar(lines[y - 1][x]);
    }
    if (y < lines.Count() - 1 && !result)
    {
        result = IsSpecialChar(lines[y + 1][x]);
    }
    if (x < lines[y].Length - 1 && y > 0 && !result)
    {
        result = IsSpecialChar(lines[y - 1][x + 1]);
    }
    if (x < lines[y].Length - 1 && !result)
    {
        result = IsSpecialChar(lines[y][x + 1]);
    }
    if (x < lines[y].Length - 1 && y < lines.Count() - 1 && !result)
    {
        result = IsSpecialChar(lines[y + 1][x + 1]);
    }

    return result;
}

bool IsSpecialChar(char c)
{
    if (char.IsDigit(c) || c == '.')
        return false;
    return true;
}

int GetNumber(int x, int y, string[] lines)
{
    int result = 0;
    int start = x;
    do
    {
        start--;
    } while (x > 0 && char.IsDigit(lines[y][start]));
    start++;
    while (char.IsDigit(lines[y][start]))
    {
        result = result * 10 + lines[y][start] - '0';
        data[y][start] = 'N';
        start++;
    }


    return result;

}