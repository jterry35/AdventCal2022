
string[] lines = System.IO.File.ReadAllLines("input.txt");

int numRows = lines.Length - 1;
int numCols = lines[0].Length - 1;

int[,] cells = new int[numRows, numCols];


// first get all cells
for(int row = 0; row < numRows; row++)
{
    string line = lines[row];

    for(int col = 0; col < numCols; col++)
    {
        cells[row, col] = Convert.ToInt32(line[col]);
    }
}

int numVis = 0;

for (int row = 0; row < numRows; row++)
{
    for (int col = 0; col < numCols; col++)
    {
        int cell = cells[row, col];

        bool r = GetCellsRightOf(row, col).Any(x => x < cell);
        bool l = GetCellsLeftOf(row, col).Any(x => x < cell);
        bool u = GetCellsUpOf(row, col).Any(x => x < cell);
        bool d = GetCellsDownOf(row, col).Any(x => x < cell);

        if (!r && !l && !u && !d)
            numVis++;
    }
}

Console.WriteLine(numVis);

List<int> GetCellsRightOf(int row, int col)
{
    List<int> r = new List<int>();

    if (col == numCols - 1)
    {
        r.Add(Int32.MaxValue);
        return r;
    }

    for(int i = col+1; i < numCols; i++)
    {
        r.Add(cells[row,i]);
    }

    return r;
}

List<int> GetCellsLeftOf(int row, int col)
{
    List<int> r = new List<int>();

    if (col == 0)
    {
        r.Add(Int32.MaxValue);
        return r;
    }

    for (int i = col-1; i > 0; i--)
    {
        r.Add(cells[row, i]);
    }

    return r;
}

List<int> GetCellsUpOf(int row, int col)
{
    List<int> r = new List<int>();

    if (row == 0)
    {
        r.Add(Int32.MaxValue);
        return r;
    }

    for (int i = row - 1; i > 0; i--)
    {
        r.Add(cells[i, row]);
    }

    return r;
}

List<int> GetCellsDownOf(int row, int col)
{
    List<int> r = new List<int>();

    if (row == numRows-1)
    {
        r.Add(Int32.MaxValue);
        return r;
    }


    for (int i = row + 1; i < numRows; i++)
    {
        r.Add(cells[i, row]);
    }

    return r;
}