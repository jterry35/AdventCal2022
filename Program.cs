string[] lines = System.IO.File.ReadAllLines("input.txt");

int runningScore = 0;

List<string> group = new List<string>();
int numLines = 0;
foreach (var line in lines)
{
    // grab 3 lines
    // find common char in all 3
    // get score for char

    group.Add(line);
    numLines++;

    if(numLines == 3)
    {
        runningScore += ProcessGroup(group);
        numLines = 0;
        group.Clear();
    }
}



Console.WriteLine("Score = " + runningScore);

int ProcessGroup(List<string> group)
{

    char[] one = group[0].ToCharArray();
    char[] two = group[1].ToCharArray();
    char[] three = group[2].ToCharArray();

    char[] dups = one.Where(x => two.Contains(x) && three.Contains(x)).Distinct().ToArray();

    if(dups.Length > 1 || dups.Length == 0)
    {
        throw new Exception("argument exception");
    }

    return GetScore(dups[0]);
}


int GetScore(char dup)
{
    int ascii = (int)dup;
    int subtractor = 0;
    int score = 0;

    if (ascii < 97) // capital
    {
        subtractor = 64;
        score = dup - subtractor + 26;
    }
    else
    {
        subtractor = 96;
        score = dup - subtractor;
    }

    

    return score;
}