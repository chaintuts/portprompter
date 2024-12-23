# This file contains code for a simple IP and port scanner
#
# Author: Josh McIntyre
#
import argparse
import socket

# Define a set of common open ports to check_port
# Define set of IPs (final octet) on the network we wish to check
PORTS = [ 20, 21, 115,          # FTP
          22,                   # SSH
          53,                   # DNS
          25, 465,              # SMTP, SMTPS
          80, 443,              # HTTP, HTTPS
          110, 995, 143, 993,   # POP3, IMAP
          515,                  # Printer
          123,                  # NTP
          3389,                 # RDP
          8333,                 # BTC
          7000,                 # AFS3 file
          8009,                 # Apache JServ
        ]

# Scan a particular port for a connection
# Return the ip, port tuple for an open/available port
# Otherwise return None
def _scan_ip_port(ip, port):
    
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    sock.settimeout(0.01)
    if sock.connect_ex((ip, port)) == 0:
        sock.close()
        return (ip, port)
    sock.close()
    
# Iterate over specified IPs and ports
def scan(ips, ports):
    
    ports_open = []
    for ip in ips:
        for port in ports:
            port_ret = _scan_ip_port(ip, port)
            if port_ret:
                ports_open.append(port_ret)
    
    return ports_open
            
# Print results
def output_scan(ports_open):
    
    for ip, port in ports_open:
        print(f"{ip}:{port}")

# The main entry point for the program
def main():
    
    parser = argparse.ArgumentParser(description="Scan IP(s) for commmon open ports")
    parser.add_argument("--ips", type=str, nargs="+", required=True, help="IP(s) to scan")
    args = parser.parse_args()
    
    ports_open = scan(args.ips, PORTS)
    
    output_scan(ports_open)
    
if __name__ == "__main__":
    main()