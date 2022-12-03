const string ROCK = "A";
const string PAPER = "B";
const string SCISSORS = "C";

Dictionary<string, MyHand> handDict = new Dictionary<string, MyHand>();
handDict.Add("X", new MyHand() { MyPoints = 1, ThingIBeat = SCISSORS, ThingILose = PAPER });
handDict.Add("Y", new MyHand() { MyPoints = 2, ThingIBeat = ROCK, ThingILose = SCISSORS });
handDict.Add("Z", new MyHand() { MyPoints = 3, ThingIBeat = PAPER, ThingILose = ROCK });

string[] lines = System.IO.File.ReadAllLines("input.txt");
int totalPts = 0;

foreach(var line in lines)
{
    string[] parts = line.Split(' ');
    handDict[parts[1]].DetermineWinner(ref totalPts, parts[0]);
}

Console.WriteLine("Score " + totalPts);








public class MyHand
{
    public int MyPoints { get; set; }
    public string ThingIBeat { get; set; }
    public string ThingILose { get; set; }

    internal void DetermineWinner(ref int totalPts, string oppPlay)
    {
        if(oppPlay == ThingIBeat)
        {
            // i won
            totalPts = totalPts + MyPoints + 6;
        }
        else if(oppPlay == ThingILose)
        {
            // i lost
            totalPts = totalPts + MyPoints + 0;
        }
        else
        {
            // tie
            totalPts = totalPts + MyPoints + 3;
        }
    }
}



