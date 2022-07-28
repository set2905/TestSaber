using SaberTest;


SaveSystem saveSys = new SaveSystem();
saveSys.savedList.Add("Data3");
saveSys.savedList.Add("Data2");
saveSys.savedList.Add("Data1");
saveSys.SaveDataToDisk();

Console.WriteLine(saveSys.savedList.Head.Data);
Console.WriteLine(saveSys.savedList.Tail.Data);
Console.WriteLine(saveSys.savedList.Tail.Previous.Data);
Console.ReadLine();
