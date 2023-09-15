// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On :
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

                string message = string.Empty;
                Parallel.For(0, hosts.Count, inxex =>
                {
                    Ping ping = new Ping();
                    string hostName = hosts[inxex];

                    IPStatus status = ping.Send(
                        hosts[inxex],
                        timeout,
                        buffer).Status;

                    message += $"{DateTime.Now.ToLongTimeString()}\t{hostName}" +
                        $"\t{status}\n";
                    ping.Dispose();
                });

                UI.PrintStatus(message);
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
