/* This file contains code for a simple port scanning program
 * 
 * Author: Josh McIntyre
 */
using System.Collections;
using static PortPrompter;

namespace portprompter
{

    // The main program class
    internal class Program
    {
        // Output the results of the scan
        static void outputScan(List<IpPort> portsOpen)
        {
            foreach (IpPort ipPort in portsOpen)
            {
                Console.WriteLine($"{ipPort.ip}:{ipPort.port}");
            }
        }

        // Print command line usage information
        static void printUsage()
        {
            Console.WriteLine("Usage: secretsetter.exe <ip>");
        }

        // The main entry point for the program
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                printUsage();
                Environment.Exit(1);
            }

            List<string> ips = args.ToList();

            PortPrompter prompter = new PortPrompter();
            List<PortPrompter.IpPort> ipPorts = prompter.scan(ips, PortPrompter.PORTS);

            outputScan(ipPorts);

        }
    }
}
