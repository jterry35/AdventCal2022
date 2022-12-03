string[] lines = System.IO.File.ReadAllLines("input.txt");

int runningScore = 0;

foreach (var line in lines)
{
    // split line in half
    // split each char into an array
    // compare the two arrays
    // score chars based on ascii

    string secondHalf = line.Substring(line.Length / 2);
    string firstHalf = line.Replace(secondHalf, "");

    char[] firstChars = firstHalf.ToCharArray();
    char[] secChars = secondHalf.ToCharArray();

    char[] dups = firstChars.Where(x => secChars.Contains(x)).Distinct().ToArray();
    
    foreach(char d in dups)
    {
        runningScore += GetScore(d);
    }
}

Console.WriteLine("Score = " + runningScore);



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