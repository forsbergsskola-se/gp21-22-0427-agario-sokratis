using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Agario.Network.Structs;


namespace AgarioServer
{
    internal class Program
    {
        public static void Main()
        { 
            var endPoint = new IPEndPoint(IPAddress.Any, 44444);
            var udpClient = new UdpClient(endPoint);
            Console.WriteLine("Server is running");

            while (true)
            {
                var sender = new IPEndPoint(IPAddress.Any, 0);
                var data = udpClient.Receive(ref sender);
                
                Console.WriteLine(udpClient.Client + " connected. Message: " + Encoding.ASCII.GetString(data));

                var position = new Position();
                var response = JsonSerializer.Serialize(position);
                var dataToSend = Encoding.ASCII.GetBytes(response);
                
                udpClient.Send(dataToSend, dataToSend.Length);
            }
        }
    }
}