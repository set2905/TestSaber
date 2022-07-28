using System.Diagnostics;


namespace SaberTest
{
    internal class SaveSystem
    {

        public string saveFilename = "save.saber";
        public string backupSaveFilename = "save.saber.bak";
        public ListRandom savedList = new ListRandom();


        public bool LoadSaveDataFromDisk()
        {
            Stream s;

            if (FileManager.GetReadStream(saveFilename, out s))
            {
                savedList.Deserialize(s);
                return true;
            }

            return false;
        }

        public void SaveDataToDisk()
        {
            Stream s;
            // if (FileManager.MoveFile(saveFilename, backupSaveFilename))
            // {
            string fullPath = AppDomain.CurrentDomain.BaseDirectory + '/' + saveFilename;
            if (FileManager.GetWriteStream(fullPath, out s))
                {
                    savedList.Serialize(s);
                    Console.WriteLine("Save successful " + fullPath);
                }
                else Console.WriteLine("Save Unsuccessful! " + fullPath);
           // }
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

        public void SaveAll()
        {
            /*
            SaveWagons();
            int lastUnlocked = AllLevels.GetLastUnlockedIndex();
            SaveLevelIndex(lastUnlocked, AllLevels.GetLastCompletedIndex());*/
        }
    }
}
