﻿using AOApps.Dns;
using Common.Logging;
using Common.Logging.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Spike
{
    class Program
    {
        static void Main(string[] args)
        {
            // Advertise via mDNS
            Console.WriteLine("Getting IP addresses");
            string sHostName = Dns.GetHostName();
            IPAddress[] IPs = Dns.GetHostAddresses(sHostName);
            Console.WriteLine($"Got: {String.Join(", ", (IEnumerable<IPAddress>)IPs)}");
            var service = new ServiceProfile($"Cards-Uno-{Guid.NewGuid()}", "_customservice._tcp", 54321, IPs);
            service.AddProperty("service_version", "1.0");
            Console.WriteLine("Made service profile");

            var SD = new ServiceDiscovery();
            Console.WriteLine("Made ServiceDiscovery");
            SD.Advertise(service);
            Console.WriteLine("Advertising");

            Console.ReadLine();
        }
    }
}
