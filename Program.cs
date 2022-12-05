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
Stack<string> ReverseStack(Stack<string> stack)
{
    Stack<string> rev = new Stack<string>();
    while (stack.Count != 0)
    {
        rev.Push(stack.Pop());
    }

    return rev;
}

for(int i = 0; i < cols.Count; i++)
{
    cols[i] = ReverseStack(cols[i]);
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

    Stack<string> temp = new Stack<string>();

    for(int i = 0; i< qty; i++)
    {
        string c = cols[fromCol].Pop();
        temp.Push(c);
    }

    // now add to correct col in reverse order
    //Stack<string> revTemp = ReverseStack(temp);
    while(temp.Count > 0)
    {
        cols[toCol].Push(temp.Pop());
    }
}

string output = "";
foreach(var col in cols)
{
    output += col.Peek();
}

Console.WriteLine(output);
