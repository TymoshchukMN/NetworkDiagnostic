﻿// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On : 28.11.2023
// Description: Logger. Creation log file and writong actions

using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace NetworkDiagnostic
{
    internal class Logger
    {
        private const string Path = "..\\";
        private const string DirName = "Logs";
        private const string CommonLogFileName = "PingLog.log";
        private readonly string fullPath = $"{Path}{DirName}";

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Ctor with creating log files fo each host.
        /// </summary>
        /// <param name="hosts">
        /// hosts.
        /// </param>
        public Logger(List<StatusHost> hosts)
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            for (ushort i = 0; i < (ushort)hosts.Count; ++i)
            {
                if (File.Exists($"{fullPath}\\{hosts[i].HostName}.txt"))
                {
                    File.Delete($"{fullPath}\\{hosts[i].HostName}.txt");
                }
            }
        }

        /// <summary>
        /// Write log into log-file.
        /// </summary>
        /// <param name="message">
        /// Log message.
        /// </param>
        public void WriteLog(string message)
        {
            File.AppendAllText($"{fullPath}\\{CommonLogFileName}", message);
        }

        /// <summary>
        /// Write log into log-filefor each host.
        /// </summary>
        /// <param name="hosts">
        /// List of hosts.
        /// </param>
        public void WriteLogHosts(List<StatusHost> hosts)
        {
            for (ushort i = 0; i < (ushort)hosts.Count; ++i)
            {
                string log = hosts[i].TimeOfOccurrence + ';'
                    + hosts[i].RoundtripTime + (char)10;

                File.AppendAllText($"{fullPath}\\{hosts[i].HostName}.txt", log);
            }
        }
    }
}