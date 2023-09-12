namespace NetworkDiagnostic
{
    internal class Logger
    {
        private const string Path = "..\\..\\..\\Logs\\";

        public Logger(List<string> hosts)
        {
            for (int i = 0; i < hosts.Count; i++)
            {
                File.Create($"{Path}{hosts[i]}.txt").Close();
            }
        }

        public void WriteLog(string host, string message)
        {
            File.AppendAllText($"{Path}{host}.txt", message);
        }
    }
}
