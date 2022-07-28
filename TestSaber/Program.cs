using SaberTest;


//Пример работы сериализации
Random rnd = new Random();
SaveSystem saveSys = new SaveSystem();
saveSys.savedList.Add(rnd.Next(100).ToString());
saveSys.savedList.Add(rnd.Next(100).ToString());
saveSys.savedList.Add(rnd.Next(100).ToString());
saveSys.SaveDataToDisk();
saveSys.savedList = new ListRandom();
Console.WriteLine("\nThe following data has been read from disk: ");
saveSys.LoadSaveDataFromDisk(saveSys.saveFilename);

Console.WriteLine("\nLoaded class object contains: ");
foreach (string data in (List<string>)saveSys.savedList)
{
    Console.WriteLine(data);
}

Console.WriteLine("\nLoaded class objects each node relations: ");
foreach (ListNode node in (List<ListNode>)saveSys.savedList)
{
    string prev;
    string next;
    if (node.Previous != null) prev = node.Previous.Data;
    else prev = "null";

    if (node.Next != null) next = node.Next.Data;
    else next = "null";


    Console.WriteLine(prev + " << " + node.Data + " >> " + next);
}
Console.WriteLine("\nThe following BACKUP data has been read from disk: ");
saveSys.LoadSaveDataFromDisk(saveSys.backupSaveFilename);
Console.ReadLine();


