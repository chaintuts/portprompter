namespace TestPortPrompter
{
    [TestClass]
    public sealed class TestPortPrompter
    {
        public class MockPortPrompter : PortPrompter
        {
            protected override bool scanIpPort(String ip, int port)
            {
                return true;
            }
        }

        [TestMethod]
        public void TestScan()
        {
            // Test one IP with two open ports
            List<string> ips = new List<string>();
            string ip = "10.10.10.1";
            int port1 = 80;
            int port2 = 53;
            ips.Add(ip);
            int[] ports = { port1, port2 };
           
            MockPortPrompter prompter = new MockPortPrompter();
            List<PortPrompter.IpPort> ipPorts = prompter.scan(ips, ports);

            Assert.IsTrue(ipPorts[0].ip == ip);
            Assert.IsTrue(ipPorts[0].port == port1);
            Assert.IsTrue(ipPorts[1].ip == ip);
            Assert.IsTrue(ipPorts[1].port == port2);
        }

    }
}
