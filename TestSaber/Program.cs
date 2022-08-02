using SaberTest;
using TestSaber;


//Пример работы сериализации
Random rnd = new Random();
SaveSystem saveSys = new SaveSystem();
for (int i = 0; i <= 5; i++)
{
    saveSys.savedList.Add(new ListNode(rnd.Next(100).ToString() + "abc"));
}
saveSys.savedList.Shuffle();


saveSys.SaveDataToDisk();
saveSys.savedList = new ListRandom();
Console.WriteLine("\nThe following data has been read from disk: ");
saveSys.LoadSaveDataFromDisk(saveSys.saveFilename);

Console.WriteLine("\nLoaded class object contains: ");
foreach (ListNode node in saveSys.savedList)
{
    Console.WriteLine(node.Data);
}

Console.WriteLine("\nLoaded class objects with each node relations: ");
int index = 0;
foreach (ListNode node in saveSys.savedList)
{

    string prev;
    string next;
    string random;
    if (node.Previous != null) prev = node.Previous.Data;
    else prev = "null";

    if (node.Next != null) next = node.Next.Data;
    else next = "null";

    if (node.Random != null) random = node.Random.Data;
    else random = "null";


    Console.WriteLine(index + ") [" + prev + " << " + node.Data + " >> " + next + "] Random node: index " + saveSys.savedList.IndexOf(node.Random) + ", Data " + random);
    index++;
}

/*
Console.WriteLine("\nThe following BACKUP data has been read from disk: ");
saveSys.LoadSaveDataFromDisk(saveSys.backupSaveFilename);*/
Console.ReadLine();


