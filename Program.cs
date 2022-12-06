
string str = System.IO.File.ReadAllText("input.txt");

List<char> marker = new List<char>();

for(int i = 0; i < str.Length; i++)
{
    marker.Add(str[i]);
    if(marker.Count % 14 == 0)
    {
        bool hasDup = HasDup(marker);
        if(hasDup == false)
        {
            Console.WriteLine(i+1);
            break;
        }

        marker.RemoveAt(0);
    }
}

bool HasDup(List<char> marker)
{
    var d = marker.Distinct().ToArray();
    if (d.Count() == marker.Count())
        return false;

    return true;

}
