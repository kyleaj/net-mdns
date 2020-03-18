using Makaretu.Dns;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleServiceBroadcast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Advertise via mDNS
            Console.WriteLine("Getting IP addresses");
            string sHostName = Dns.GetHostName();
            IPAddress[] IPs = Dns.GetHostAddresses(sHostName);
            Console.WriteLine($"Got: {String.Join(", ", (IEnumerable<IPAddress>)IPs)}");
            var service = new ServiceProfile($"Cards-Uno-{Guid.NewGuid()}", "_unocards._tcp", 54321, IPs);
            service.AddProperty("cards_discuss_version", "1.0");
            Console.WriteLine("Made service profile");

            var SD = new ServiceDiscovery();
            Console.WriteLine("Made ServiceDiscovery");
            SD.Advertise(service);
            Console.WriteLine("Advertising");

            Console.ReadLine();
        }
    }
}
