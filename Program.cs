string[] lines = System.IO.File.ReadAllLines("input.txt");
int tally = 0;

foreach (var line in lines)
{
    // grab each pair
    // expand each pair inclussive
    // check if one fully contains two
    // check if two fully contains one

    string[] parts = line.Split(',');
    int[] one = Expand(parts[0]);
    int[] two = Expand(parts[1]);

    int[] oneDistinct = one.Except(two).ToArray();
    int[] twoDistinct = two.Except(one).ToArray();

    if (oneDistinct.Length == 0)
    {
        Console.WriteLine($"{parts[1]} contains all of {parts[0]}");
        tally++;
    }
    else if (twoDistinct.Length == 0)
    {
        Console.WriteLine($"{parts[0]} contains all of {parts[1]}");
        tally++;
    }
}

Console.WriteLine($"There are {tally} overlaps");

int[] Expand(string range)
{
    // separate by hyphen
    // change to ints
    // for loop from start num to end number, adding each to return list

    List<int> result = new List<int>();

    string[] rangeArr = range.Split('-');
    int start = Convert.ToInt32(rangeArr[0]);
    int end = Convert.ToInt32(rangeArr[1]);

    for(int i = start; i <= end; i++)
    {
        result.Add(i);
    }

    return result.ToArray();
}
