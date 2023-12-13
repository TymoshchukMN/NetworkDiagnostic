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
        /// Get or Set host`s name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Get or Set ping status.
        /// </summary>
        public IPStatus Status { get; set; }

        /// <summary>
        /// Get or Set Time Of Occurrence.
        /// </summary>
        public string TimeOfOccurrence { get; set; }

        /// <summary>
        /// Get or Set RoundtripTime.
        /// </summary>
        public long RoundtripTime { get; set; }
    }
}
