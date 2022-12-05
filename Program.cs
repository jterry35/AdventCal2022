using System.Text;

string[] lines = System.IO.File.ReadAllLines("input.txt");

// loop over each column
List<Stack<string>> cols = new List<Stack<string>>();

for(int i = 0; i < lines[0].Length; i+=3)
{
    Stack<string> localCols = new Stack<string>();

    foreach (var line in lines)
    {
        if (line.Contains("[") == false) break;

        string l = line.Substring(i, 3);
        if (string.IsNullOrWhiteSpace(l) == true) continue;

        l = l.Replace("[", "");
        l = l.Replace("]", "");
        localCols.Push(l);
    }

    cols.Add(localCols);
    i++;
}

// reverse stacks
for(int i = 0; i < cols.Count; i++)
{
    Stack<string> rev = new Stack<string>();
    while (cols[i].Count != 0)
    {
        rev.Push(cols[i].Pop());
    }

    cols[i] = rev;
}

// loop over lines to get instructions
foreach(var line in lines)
{
    if(line.StartsWith("move") == false) continue;

    string l = line.Replace("move", "");
    l = l.Replace(" from ", ",");
    l = l.Replace(" to ", ",");

    string[] l2 = l.Split(',');

    int qty = Convert.ToInt32(l2[0]);
    int fromCol = Convert.ToInt32(l2[1]) -1;
    int toCol = Convert.ToInt32(l2[2]) -1;

    for(int i = 0; i< qty; i++)
    {
        string c = cols[fromCol].Pop();
        cols[toCol].Push(c);
    }
}

string output = "";
foreach(var col in cols)
{
    output += col.Peek();
}

Console.WriteLine(output);
