namespace NetworkDiagnostic
{
    internal class Logger
    {
        private const string Path = "..\\..\\..\\Logs\\";
        private const string LogFileName = "LingLog.log";

        public Logger()
        {
            File.Create($"{LogFileName}").Close();
        }

        public void WriteLog(string host, string message)
        {
            File.AppendAllText($"{Path}{LogFileName}", message);
        }
    }
}
