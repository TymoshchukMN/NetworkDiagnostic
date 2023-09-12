﻿using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace NetworkDiagnostic
{
    internal class Starter
    {
        public static void Run()
        {
            List<string> hosts =
                File.ReadAllLines("..\\..\\..\\Sorce\\addresses.txt").ToList();

            Logger logger = new Logger();

            // Массив Byte, содержащие данные,
            // отправляемые с сообщением проверки связи ICMP
            // и возвращаемые с сообщением ответа проверки связи ICMP
            string data = "this program is used for diagnostic";

            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 4000;

            for (; ;)
            {
                Parallel.For(0, hosts.Count, inxex =>
                {
                    Ping ping = new Ping();
                    string hostNma = hosts[inxex];

                    string message = DateTime.Now.ToLongTimeString();
                    IPStatus status = ping.Send(
                        hosts[inxex],
                        timeout,
                        buffer).Status;

                    Console.WriteLine($"{message}\t{hostNma}\t{status}");

                    message += $"\t{hostNma}\t{status}{(char)10}";
                    logger.WriteLog(hostNma, message);

                    // делайем паузу в 2 секунды между отправкой ICMP
                    Thread.Sleep(2000);
                });
            }
        }
    }
}
