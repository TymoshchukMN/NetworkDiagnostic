﻿// Author: Tymoshchuk Maksym
// Created On : 10.09.2023
// Last Modified On :
// Description: Logger. Creation log file and writong actions

namespace NetworkDiagnostic
{
    internal class Logger
    {
        private const string Path = "..\\..\\..\\Logs\\";
        private const string LogFileName = "PingLog.log";

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// Defult Ctor.
        /// </summary>
        public Logger()
        {
            File.Create($"{LogFileName}").Close();
        }

        /// <summary>
        /// Write log into log-file.
        /// </summary>
        /// <param name="message">
        /// Log message.
        /// </param>
        public void WriteLog(string message)
        {
            File.AppendAllText($"{Path}{LogFileName}", message);
        }
    }
}
