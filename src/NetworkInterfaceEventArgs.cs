using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace AOApps.Dns
{
    /// <summary>
    ///   The event data for <see cref="MulticastService.NetworkInterfaceDiscovered"/>.
    /// </summary>
    public class IPEventArgs : EventArgs
    {
        /// <summary>
        ///   The sequece of detected network interfaces.
        /// </summary>
        /// <value>
        ///   A sequence of network interfaces.
        /// </value>
        public IEnumerable<IPAddress> NetworkInterfaces { get; set; }
    }
}

