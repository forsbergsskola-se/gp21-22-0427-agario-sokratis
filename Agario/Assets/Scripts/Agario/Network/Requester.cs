using System.Net;
using System.Net.Sockets;
using System.Text;
using Agario.Interfaces;
using UnityEngine;

namespace Agario.Network
{
    public class Requester
    {
        private string _ipAddress;
        private int _port;

        public Requester(INetworkSetup networkSetup)
        {
            _ipAddress = networkSetup.IpAddress;
            _port = networkSetup.Port;
        }

        public Vector3 ServerPosition(int range)
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(_ipAddress), _port);
            var client = new UdpClient();
            client.Connect(endPoint);

            var data = Encoding.ASCII.GetBytes(range.ToString());
            client.Send(data, data.Length);

            data = client.Receive(ref endPoint);
            var stringData = Encoding.ASCII.GetString(data);
            var position = JsonUtility.FromJson<Vector3>(stringData);

            return position;
        }
    }
}
