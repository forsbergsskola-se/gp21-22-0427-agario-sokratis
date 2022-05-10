using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Agario.ScriptableObjects;
using UnityEngine;

namespace Agario.Network
{
    public class Sender : MonoBehaviour
    {
        [Header("Network")] 
        [SerializeField] private string ipAddress;
        [SerializeField] private int port;
        
        [Header("Data to send")]
        [SerializeField] private Transform localPlayer;
        [SerializeField] private IntValue localScore;

        private void FixedUpdate() => ConnectToServer();

        private void ConnectToServer()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            var client = new UdpClient();
            client.Connect(endPoint);

            var data = Encoding.ASCII.GetBytes($"{Time.time}");
            client.Send(data, data.Length);
        }        
    }
}
