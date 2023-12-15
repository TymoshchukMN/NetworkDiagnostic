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
            TimeOfOccurrence = time.ToLongTimeString();
        }

        /// <summary>
        /// Gets or Sets host`s name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or Sets ping status.
        /// </summary>
        public IPStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Time Of Occurrence.
        /// </summary>
        public string TimeOfOccurrence { get; set; }

        /// <summary>
        /// Gets or Sets RoundtripTime.
        /// </summary>
        public long RoundtripTime { get; set; }
    }
}
