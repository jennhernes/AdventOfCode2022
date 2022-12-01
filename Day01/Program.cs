﻿var input = File.ReadAllLines("./input.txt");

var max1 = 0;
var max2 = 0;
var max3 = 0;
var current = 0;
foreach (var line in input)
{
    if (line == "")
    {
        if (current > max1)
        {
            max3 = max2;
            max2 = max1;
            max1 = current;
        }
        else if (current > max2)
        {
            max3 = max2;
            max2 = current;
        }
        else if (current > max3)
        {
            max3 = current;
        }
        current = 0;
    }
    else
    {
        current += int.Parse(line);
    }
}

Console.WriteLine(max1 + max2 + max3);