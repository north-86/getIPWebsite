using System;
using System.Net;
using System.Text.RegularExpressions;
using static System.Console;

namespace getIPWebsite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter the web address:");
            string url = ReadLine();
            string pattern = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$";
            if (Regex.IsMatch(url, pattern))
            {
                var uri = new Uri(url);
                WriteLine($"URL: {url}");
                IPHostEntry hostEntry = Dns.GetHostEntry(uri.Host);
                WriteLine($"IP addresses {hostEntry.HostName}:");
                foreach (IPAddress address in hostEntry.AddressList)
                {
                    WriteLine($"{address}");
                }
            }
            else
            {
                WriteLine("Error");
            }
            Console.ReadKey();
        }
    }
}
