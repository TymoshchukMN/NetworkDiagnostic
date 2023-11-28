// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On : 18.09.2023
// Description: Starter class

using System.Net.NetworkInformation;
using System.Text;

namespace NetworkDiagnostic
{
    internal class Starter
    {
        public static void Run()
        {
            List<string> hosts =
                File.ReadAllLines("..\\source\\addresses.txt").ToList();

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

                    IPStatus status = ping.Send(
                        hosts[inxex],
                        timeout,
                        buffer).Status;

                    hostList.Where(
                        (x) => x.HostName == hostName).ToList().ForEach(
                            (s) =>
                            {
                                s.Status = status;
                                s.Time = DateTime.Now.ToLongTimeString();
                            });

                    message += $"{DateTime.Now.ToLongTimeString()}\t{hostName}" +
                        $"\t{status}\n";

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
