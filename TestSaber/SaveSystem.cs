using System.Diagnostics;


namespace SaberTest
{
    internal class SaveSystem
    {

        public string saveFilename = "save.saber";
        public string backupSaveFilename = "save.saber.bak";
        public ListRandom savedList = new ListRandom();


        public bool LoadSaveDataFromDisk(string fName)
        {
            Stream s;

            if (FileManager.GetReadStream(fName, out s))
            {
                savedList.Deserialize(s);
                return true;
            }

            return false;
        }

        public void SaveDataToDisk()
        {
            Stream s;
            if (FileManager.MoveFile(saveFilename, backupSaveFilename))
            {
                string fullPath = AppDomain.CurrentDomain.BaseDirectory + '/' + saveFilename;
                if (FileManager.GetWriteStream(fullPath, out s))
                {
                    savedList.Serialize(s);
                    Console.WriteLine("Save to disk successful!");
                }
                else Console.WriteLine("Save to disk Unsuccessful! ");
            }
        }

        public void DeleteSaveData()
        {
            if (FileManager.DeleteFile(saveFilename))
            {
                Console.WriteLine("Save file deleted!");
            }
            else
            {
                Console.WriteLine("Failed to delete save file!");
            }
        }
    }
}
