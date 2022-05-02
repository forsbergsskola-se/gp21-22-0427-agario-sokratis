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
            
            tcpListner.Start();
            while (true)
            {
                byte[] buffer = new byte[100];
                
                var tcpClient = tcpListner.AcceptTcpClient();
                tcpClient.GetStream().Read(buffer, 0, 100);
                
                Console.WriteLine("Hello, this is Sokratis Time Server. The Current time is: " 
                                  + Encoding.ASCII.GetString(buffer));
                
                tcpClient.Close();
            }
        }
    }
};

