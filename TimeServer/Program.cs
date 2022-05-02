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
            var tcpListener = new TcpListener(endPoint);
            
            tcpListener.Start();
            Console.WriteLine("Start Listener");
            
            while (true)
            {
                var tcpClient = tcpListener.AcceptTcpClient();
                tcpClient.GetStream().Write(GetGreetingMessage());
                tcpClient.Close();
            }
        }
        
        private static byte[] GetGreetingMessage() 
            => Encoding.ASCII.GetBytes("The Current time is: " + DateTime.Now);
    }
}

