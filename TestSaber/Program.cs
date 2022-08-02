using SaberTest;


//Пример работы сериализации
Random rnd = new Random();
SaveSystem saveSys = new SaveSystem();
for (int i = 0; i <= 5; i++)
{
    saveSys.savedList.Add(new ListNode(rnd.Next(100).ToString()+"abc"));
}



saveSys.SaveDataToDisk();
saveSys.savedList = new ListRandom();
Console.WriteLine("\nThe following data has been read from disk: ");
saveSys.LoadSaveDataFromDisk(saveSys.saveFilename);

Console.WriteLine("\nLoaded class object contains: ");
foreach (string data in (List<string>)saveSys.savedList)
{
    Console.WriteLine(data);
}

Console.WriteLine("\nLoaded class objects with each node relations: ");
int index = 0;
foreach (ListNode node in saveSys.savedList)
{
    
    string prev;
    string next;
    if (node.Previous != null) prev = node.Previous.Data;
    else prev = "null";

    if (node.Next != null) next = node.Next.Data;
    else next = "null";


    Console.WriteLine(index + ") " + prev + " << " + node.Data + " >> " + next);
    index++;
}

/*
Console.WriteLine("\nThe following BACKUP data has been read from disk: ");
saveSys.LoadSaveDataFromDisk(saveSys.backupSaveFilename);*/
Console.ReadLine();


