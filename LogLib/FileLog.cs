namespace LogLib
{
    public class FileLog
    {
        public void Log(string message)
        {
            string path = "C:\\log\\mylog.txt";
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int len = message.Length;
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.AppendAllText(path, datetime + ">>" + message + "[" + len + "]\n");
        }

        public void Log(string message, string filename)
        {
            string path = "C:\\log\\" + filename + ".txt";
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int len = message.Length;
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.AppendAllText(path, datetime + ">>" + message + "[" + len + "]\n");
        }
    }
}