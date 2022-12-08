
string[] lines = System.IO.File.ReadAllLines("input.txt");

List<Folder> allFolders = new List<Folder>();

// add root
Folder root = CreateFolder(null, "/");
Folder currentFolder = root;

int lineNum = 0;

foreach (string line in lines)
{
    if (line.StartsWith("dir"))
    {
        string dir = line.Replace("dir ", "");
        CreateFolder(currentFolder, dir);
    }
    else if (line.StartsWith("$"))
    {
        if (line.StartsWith("$ cd"))
        {
            string dir = line.Replace("$ cd ", "");
            if (dir == "..") 
                currentFolder = currentFolder.Parent;
            else
                currentFolder = currentFolder.Folders.First(x => x.Name == dir);
        }
    }
    else
    {
        string[] strings = line.Split(' ');
        int fileSize = Convert.ToInt32(strings[0]);
        string name = strings[1];

        currentFolder.AddFile(name, fileSize);
    }

    lineNum++;
}


Folder CreateFolder(Folder parent, string name)
{
    Folder folder = new Folder() { Name =name };
    allFolders.Add(folder);

    folder.Parent = parent;

    if(parent != null)
        parent.Folders.Add(folder);

    return folder;
}

int overage = 0;
const int MAX = 100000;

foreach(var folder in allFolders)
{
    int size = folder.FileSizeTotal();

    if (size <= MAX)
    {
        overage += size;
        Console.WriteLine($"{folder.Name} - {size}");
    }
}

Console.WriteLine(overage);

class Folder
{
    public string Name;
    public Folder Parent;
    public List<Folder> Folders = new List<Folder>();
    public List<File> Files = new List<File>();

    internal void AddFile(string name, int fileSize)
    {
        File f = new File() { Name = name, size = fileSize };
        this.Files.Add(f);
    }
    
    public int FileSizeTotal()
    {
        int total = this.GetFileSizeTotalRecursive(this);
        return total;
    }

    private int GetFileSizeTotalRecursive(Folder root)
    {
        int sumFileSize = root.Files.Sum(x => x.size);

        //foreach(var file in root.Files)
        //{
        //    Console.WriteLine(file.ToString());
        //}

        if(root.Folders.Count > 0)
        {
            foreach(var folder in root.Folders)
            {
               sumFileSize += GetFileSizeTotalRecursive(folder);
            }
        }

        return sumFileSize;
    }

    public override string ToString()
    {
        return $"{Name} ({this.FileSizeTotal()})";
    }
}

public class File
{
    public string Name;
    public int size;

    public override string ToString()
    {
        return size.ToString() + " " + Name;
    }
}