const string ROCK = "A";
const string PAPER = "B";
const string SCISSORS = "C";

Dictionary<string, MyHand> handDict = new Dictionary<string, MyHand>();
handDict.Add(ROCK, new MyHand() { Me = ROCK, MyPoints = 1, ThingIBeat = SCISSORS, ThingILose = PAPER });
handDict.Add(PAPER, new MyHand() { Me = PAPER,  MyPoints = 2, ThingIBeat = ROCK, ThingILose = SCISSORS });
handDict.Add(SCISSORS, new MyHand() { Me = SCISSORS, MyPoints = 3, ThingIBeat = PAPER, ThingILose = ROCK });

string[] lines = System.IO.File.ReadAllLines("input.txt");
int totalPts = 0;

foreach(var line in lines)
{
    string[] parts = line.Split(' ');
    string myPlay = "";
    string oppPlay = parts[0];

    switch (parts[1])
    {
        case "X": // Lose
            Console.Write("Should lose ---");
            myPlay = GetHandThatWillLose(oppPlay);
            break;
        case "Y": // draw
            Console.Write("Should tie ---");
            myPlay = oppPlay;
            break;
        case "Z": // win
            Console.Write("Should win ---");
            myPlay = GetHandThatWillWin(oppPlay);
            break;
        default:
            break;
    }

    handDict[myPlay].DetermineWinner(ref totalPts, oppPlay);
}

string GetHandThatWillLose(string oppPlay)
{
    if (oppPlay == ROCK)
        return SCISSORS;
    else if (oppPlay == PAPER)
        return ROCK;
    else
        return PAPER;
}

string GetHandThatWillWin(string oppPlay)
{
    if (oppPlay == ROCK)
        return PAPER;
    else if (oppPlay == PAPER)
        return SCISSORS;
    else
        return ROCK;
}



Console.WriteLine("Score " + totalPts);








public class MyHand
{
    public string Me { get; set; }
    public int MyPoints { get; set; }
    public string ThingIBeat { get; set; }
    public string ThingILose { get; set; }

    internal void DetermineWinner(ref int totalPts, string oppPlay)
    {
        int score = 0;
        string outcome = "";

        if(oppPlay == ThingIBeat)
        {
            // i won
            score = MyPoints + 6;
            outcome = $"Win - {Me} Beats {oppPlay} = {score}";
        }
        else if(oppPlay == ThingILose)
        {
            // i lost
            score = MyPoints + 0;
            outcome = $"Lose {oppPlay} Beats {Me} = {score}";
        }
        else
        {
            // tie
            score = MyPoints + 3;
            outcome = $"Tie {Me} Ties w/ {oppPlay} = {score}";
        }

        Console.WriteLine(outcome);

        totalPts = totalPts + score; 
    }
}



