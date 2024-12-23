using portprompter;
using System;
using System.Net.Sockets;

public class PortPrompter
{
    // A custom struct for IP, port results
    public struct IpPort
    {
        public String ip;
        public int port;
    }


    public static int[] PORTS = new int[]
    {
          20, 21, 115,          // FTP
          22,                   // SSH
          53,                   // DNS
          25, 465,              // SMTP, SMTPS
          80, 443,              // HTTP, HTTPS
          110, 995, 143, 993,   // POP3, IMAP
          515,                  // Printer
          123,                  // NTP
          3389,                 // RDP
          8333,                 // BTC
          7000,                 // AFS3 file
          8009,                 // Apache JServ
    };

    // Scan a particular port for a connection
    protected virtual bool scanIpPort(String ip, int port)
    {
        TcpClient tcp = new TcpClient();

        bool connect = tcp.ConnectAsync(ip, port).Wait(10);
        return connect;
    }

    // Scan the list of IPs for standard ports
    public List<IpPort> scan(List<String> ips, int[] ports)
    {
        List<IpPort> ipPorts = new List<IpPort>();
        foreach(String ip in ips)
        {
            foreach(int port in ports)
            {
                bool open = scanIpPort(ip, port);
                if (open)
                {
                    IpPort ipPort;
                    ipPort.ip = ip;
                    ipPort.port = port;

                    ipPorts.Add(ipPort);
                }
            }
        }

        return ipPorts;
    }

}
