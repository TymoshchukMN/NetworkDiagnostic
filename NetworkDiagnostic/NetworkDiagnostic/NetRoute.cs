using System;
using System.Diagnostics;
using System.IO;

namespace NetworkDiagnostic
{
    public class NetRoute
    {
        public void GetRoutes(string logName)
        {
            var proc1 = new ProcessStartInfo();

            proc1.UseShellExecute = true;
            proc1.FileName = "cmd.exe";
            proc1.WorkingDirectory = $"{Directory.GetCurrentDirectory()}";
            Console.WriteLine(proc1.WorkingDirectory);
            proc1.UseShellExecute = false;
            proc1.Arguments = $" /c route print > ..\\Logs\\{logName}.txt ";
            Console.WriteLine(proc1.Arguments);

            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);
        }
    }
}
