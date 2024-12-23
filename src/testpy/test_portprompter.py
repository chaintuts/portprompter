# This file contains unit tests for PortPrompter library functionality
#
# Author: Josh McIntyre
#
import hashlib
import unittest
from unittest.mock import patch, Mock

import portprompter

class TestPortPrompter(unittest.TestCase):

    @patch("portprompter._scan_ip_port")
    def test_generate_address_privkey_btc(self, mock_scan_ip_port):
        
        ip = "10.10.10.1"
        port = 80
        
        mock_scan_ip_port.return_value = (ip, port)
        
        ip_ports = portprompter.scan([ip], [port])
        
        assert ip_ports[0][0] == ip
        assert ip_ports[0][1] == port

        
       
