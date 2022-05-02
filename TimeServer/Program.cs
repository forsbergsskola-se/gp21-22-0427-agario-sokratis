using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TimeServer
{
    class Program
    {
        public static void Main()
        {
            var endPoint = new IPEndPoint(IPAddress.Loopback, 44444);
            var tcpListner = new TcpListener(endPoint);
            
            Console.WriteLine("Starting...");
            
            tcpListner.Start();
            
            while (true)
            {
                byte[] buffer = new byte[100];
                
                var tcpClient = tcpListner.AcceptTcpClient();
                tcpClient.GetStream().Read(buffer, 0, 100);
                
                Console.WriteLine(Encoding.ASCII.GetString(buffer) + "The Current time is: " + DateTime.Now);
                
                tcpClient.Close();
            }
        }
    }
}

