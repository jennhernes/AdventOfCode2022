var input = File.ReadAllLines("./input.txt")
                .Select(x => x.Split(" -> ", StringSplitOptions.RemoveEmptyEntries))
                .Select(x => x.Select(y =>
                {
                    var temp = y.Split(',');
                    return temp.Select(z => int.Parse(z)).ToList();
                }).ToList()).ToList();
var maxx = 0;
var maxy = 0;
var minx = 500;
var miny = 500;
foreach (var seg in input)
{
    foreach (var point in seg)
    {
        minx = Math.Min(minx, point[0]);
        maxx = Math.Max(maxx, point[0]);
        miny = Math.Min(miny, point[1]);
        maxy = Math.Max(maxy, point[1]);
    }
}
Console.WriteLine($"{minx} {maxx} {miny} {maxy}");
var cave = new char[maxy + (maxy - miny), maxx + 3 * (maxx - minx)];

foreach (var seg in input)
{
    for (int i = 1; i < seg.Count; i++)
    {
        for (int j = seg[i - 1][0]; j <= seg[i][0]; j++)
        {
            cave[seg[i][1], j] = '#';
        }
        for (int j = seg[i][0]; j <= seg[i-1][0]; j++)
        {
            cave[seg[i][1], j] = '#';
        }
        for (int j = seg[i - 1][1]; j <= seg[i][1]; j++)
        {
            cave[j, seg[i][0]] = '#';
        }
        for (int j = seg[i][1]; j <= seg[i-1][1]; j++)
        {
            cave[j, seg[i][0]] = '#';
        }
    }
}

// for (int i = miny - 1; i < maxy + 1; i++)
// {
//     for (int j = minx - 1; j < maxx + 1; j++)
//     {
//         if (cave[i, j] != '#')
//         {
//             Console.Write('.');
//         }
//         else
//         {
//             Console.Write(cave[i, j]);
//         }
//     }
//     Console.WriteLine();
// }

for (int i = 0; i < cave.GetLength(1); i++)
{
    cave[maxy+2,i] = '#';
}

var sand = 0;
while (cave[0,500] != 'o')
{
    sand++;
    var i = 0;
    var j = 500;
    while (true)
    {
        if (cave[i+1,j] != '#' && cave[i+1,j] != 'o')
        {
            i++;
        }
        else if (cave[i+1,j-1] != '#' && cave[i+1,j-1] != 'o')
        {
            i++;
            j--;
        }
        else if (cave[i+1,j+1] != '#' && cave[i+1,j+1] != 'o')
        {
            i++;
            j++;
        }
        else {
            cave[i,j] = 'o';
            break;
        }
    }
}

Console.WriteLine(sand);