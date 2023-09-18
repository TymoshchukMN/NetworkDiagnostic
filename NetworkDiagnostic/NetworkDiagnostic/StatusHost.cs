using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkDiagnostic_v2._0
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
            Time = DateTime.Now.ToLongTimeString();
        }

        public string HostName { get; set; }

        public IPStatus Status { get; set; }

        public string Time { get; set; }
    }
}
