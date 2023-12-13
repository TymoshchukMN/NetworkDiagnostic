// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On : 28.11.2023
// Description: Starter class

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetworkDiagnostic
{
    internal class Starter
    {
        private const string FileAddress = "..\\addresses.txt";

        /// <summary>
        /// RUn programm.
        /// </summary>
        public static void Run()
        {
            if (CheckIfFileExsit())
            {
                Process();
            }
            else
            {
                UI.PrintErrorFileExist();
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Check if files with addresses exist.
        /// </summary>
        /// <returns>
        /// true if file exist.
        /// </returns>
        private static bool CheckIfFileExsit()
        {
            bool isFileExist = false;

            if (File.Exists(FileAddress))
            {
                isFileExist = true;
            }

            return isFileExist;
        }

        /// <summary>
        /// General process.
        /// </summary>
        private static void Process()
        {
            List<string> hosts =
                File.ReadAllLines(FileAddress).ToList();

            List<StatusHost> hostList = new List<StatusHost>();

            foreach (string line in hosts)
            {
                hostList.Add(
                    new StatusHost(
                        line,
                        IPStatus.Unknown,
                        DateTime.Now));
            }

            Logger logger = new Logger();

            // Массив Byte, содержащие данные,
            // отправляемые с сообщением проверки связи ICMP
            // и возвращаемые с сообщением ответа проверки связи ICMP
            string data = "this program is used for diagnostic";

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 4000;

            // значение по умолчанию
            ConsoleKey usreInput = ConsoleKey.D0;

            do
            {
                if (Console.KeyAvailable)
                {
                    usreInput = Console.ReadKey().Key;
                }

                // доп проверка, чтобы не ждать 2 секунды, до завершения программы
                if (usreInput == ConsoleKey.Q)
                {
                    break;
                }

                string message = string.Empty;
                Parallel.For(0, hosts.Count, inxex =>
                {
                    Ping ping = new Ping();
                    string hostName = hosts[inxex];

                    PingReply reply = ping.Send(
                        hosts[inxex],
                        timeout,
                        buffer);

                    hostList.Where(
                        (x) => x.HostName == hostName).ToList().ForEach(
                            (s) =>
                            {
                                s.Status = reply.Status;
                                s.TimeOfOccurrence = DateTime.Now.ToLongTimeString();
                                s.RoundtripTime = reply.RoundtripTime;
                            });

                    message += $"{DateTime.Now.ToLongTimeString()}\t{hostName}" +
                        $"\t{reply.Status}\t{reply.RoundtripTime}\n";

                    ping.Dispose();
                });

                UI.PrintStatus(hostList);
                logger.WriteLog(message);

                // доп проверка, чтобы не ждать 2 секунды, до завершения программы
                if (usreInput == ConsoleKey.Q)
                {
                    break;
                }

                // делайем паузу в 1 секунды между отправкой ICMP
                Thread.Sleep(2000);
            }
            while (usreInput != ConsoleKey.Q);
        }
    }
}
