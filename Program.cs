
string[] lines = System.IO.File.ReadAllLines("input.txt");

int numRows = lines.Length;
int numCols = lines[0].Length;

int[,] cells = new int[numRows, numCols];


// first get all cells
for (int row = 0; row < numRows; row++)
{
    string line = lines[row];

    for (int col = 0; col < numCols; col++)
    {
        char c = line[col];
        string cs = c.ToString();
        int num = Convert.ToInt32(cs);
        cells[row, col] = num;
    }
}

int numVis = 0;

for (int row = 1; row < numRows - 1; row++)
{
    for (int col = 1; col < numCols - 1; col++)
    {
        int cell = cells[row, col];

        var r = GetCellsRightOf(row, col);
        bool visFromRight = r.All(x => x < cell);

        var l = GetCellsLeftOf(row, col);
        bool visFromLeft = l.All(x => x < cell);

        var u = GetCellsUpOf(row, col);
        bool visFromTop = u.All(x => x < cell);

        var d = GetCellsDownOf(row, col);
        bool visFromBottom = d.All(x => x < cell);

        if (visFromRight || visFromLeft || visFromTop || visFromBottom)
            numVis++;
    }
}

numVis += numCols * 2;
numVis += numRows * 2;
numVis -= 4;
Console.WriteLine(numVis);

List<int> GetCellsRightOf(int row, int col)
{
    List<int> r = new List<int>();

    for (int i = col + 1; i < numCols; i++)
    {
        r.Add(cells[row, i]);
    }

    return r;
}

List<int> GetCellsLeftOf(int row, int col)
{
    List<int> r = new List<int>();

    for (int i = col - 1; i >= 0; i--)
    {
        r.Add(cells[row, i]);
    }

    return r;
}

List<int> GetCellsUpOf(int row, int col)
{
    List<int> r = new List<int>();

    for (int i = row - 1; i >= 0; i--)
    {
        r.Add(cells[i, col]);
    }

    return r;
}

List<int> GetCellsDownOf(int row, int col)
{
    List<int> r = new List<int>();


    for (int i = row + 1; i < numRows; i++)
    {
        r.Add(cells[i, col]);
    }

    return r;
}