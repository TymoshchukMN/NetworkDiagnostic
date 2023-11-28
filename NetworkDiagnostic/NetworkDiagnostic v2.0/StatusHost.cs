using System;
using System.Net.NetworkInformation;


namespace NetworkDiagnostic
{
    internal class StatusHost
    {
        public StatusHost(
           string hostName,
           IPStatus status,
           DateTime time)
        {
            HostName = hostName;
            Status = status;
            Time = time.ToLongTimeString();
        }

        public string HostName { get; set; }

        public IPStatus Status { get; set; }

        public string Time { get; set; }
    }
}
