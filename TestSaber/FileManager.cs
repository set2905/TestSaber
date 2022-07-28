
namespace SaberTest
{
    public static class FileManager
    {
        public static bool GetWriteStream(string fullPath, out Stream writeStream)
        {
            try
            {

                Console.WriteLine("Writing file at " + fullPath);
                writeStream = new FileInfo(fullPath).OpenWrite();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to write to {fullPath} with exception {e}");
                writeStream = null;
                return false;
            }
        }

        public static bool GetReadStream(string fileName, out Stream result)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (!File.Exists(fullPath))
            {
                File.WriteAllText(fullPath, "");
            }
            try
            {
                result = new FileInfo(fullPath).OpenRead();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to read from {fullPath} with exception {e}");
                result = null;
                return false;
            }
        }

        public static bool DeleteFile(string fileName)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (!File.Exists(fullPath))
            {
                Console.WriteLine("File does not exist!");
                return true;
            }
            try
            {
                File.Delete(fullPath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to delete file at " + fullPath + "; Exception: " + e.Message);
                return false;
            }
        }

        public static bool MoveFile(string fileName, string newFileName)
        {
            var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            var newFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, newFileName);

            try
            {
                if (File.Exists(newFullPath))
                {
                    File.Delete(newFullPath);
                }

                if (!File.Exists(fullPath))
                {
                    File.WriteAllText(fullPath, "");
                }

                File.Move(fullPath, newFullPath);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed to move file from {fullPath} to {newFullPath} with exception {e}");
                return false;
            }

            return true;
        }
    }
}
