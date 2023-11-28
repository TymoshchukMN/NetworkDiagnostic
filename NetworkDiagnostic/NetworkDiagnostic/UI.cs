// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On : 18.09.2023
// Description: Users interface

using System.Net.NetworkInformation;

namespace NetworkDiagnostic
{
    internal class UI
    {
        public static void PrintStatus(List<StatusHost> hostList)
        {
            for (int i = 0; i < hostList.Count; i++)
            {
                Console.Write($"{hostList[i].Time}\t");
                Console.Write($"{hostList[i].HostName}\t");

                switch (hostList[i].Status)
                {
                    case IPStatus.Success:
                        PrintChangedColor(
                            ConsoleColor.Green,
                            hostList[0].Status.ToString());
                        break;
                    default:
                        PrintChangedColor(
                            ConsoleColor.Red,
                            hostList[0].Status.ToString());
                        break;
                }
            }
        }

        public static void PrintErrorFileExist()
        {
            Console.WriteLine("File 'addresses.txt' doesn't exist");
            Console.WriteLine("Press any key for exit....");
        }

        /// <summary>
        /// Change item color.
        /// </summary>
        /// <param name="color">
        /// Prefered color.
        /// </param>
        /// <param name="str">
        /// String for changing color.
        /// </param>
        private static void PrintChangedColor(ConsoleColor color, string str)
        {
            ConsoleColor def = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ForegroundColor = def;
        }
    }
}
