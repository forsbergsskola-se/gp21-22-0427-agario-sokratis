using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OpenWorld_MMO
{
    static class Program
    {
        public static void Main()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 44444);
            var udpClient = new UdpClient(ipEndPoint);
            
            Console.WriteLine("Waiting client...");

            var sender = new IPEndPoint(IPAddress.Any, 0);
            var data = udpClient.Receive(ref sender);
            
            Console.WriteLine($"Message receiver from{sender}: ");
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string message = "Welcome to my server";
            data = Encoding.ASCII.GetBytes(message);
            udpClient.Send(data, data.Length, sender);
        }
    }    
};

