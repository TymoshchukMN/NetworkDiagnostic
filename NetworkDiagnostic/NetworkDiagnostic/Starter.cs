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
                        $"\t{status}{(char)10}";
                });

                UI.PrintStatus(message);
                logger.WriteLog(message);

                // делайем паузу в 2 секунды между отправкой ICMP
                Thread.Sleep(1500);
            }
        }
    }
}
