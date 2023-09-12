using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDiagnostic
{
    internal class UI
    {
        public static void PrintStatus(IPStatus status)
        {
            switch (status)
            {
                case IPStatus.Success:
                    PrintChangedColor(ConsoleColor.Green, status.ToString());
                    break;
                default:
                    PrintChangedColor(ConsoleColor.Red, status.ToString());
                    break;
            }
        }

        private static void PrintChangedColor(ConsoleColor color, string str)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ForegroundColor = def;
        }
    }
}
