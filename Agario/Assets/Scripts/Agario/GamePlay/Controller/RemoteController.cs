using System.Net;
using System.Net.Sockets;
using System.Text;
using Agario.Network.Structs;
using Agario.ScriptableObjects;
using UnityEngine;

namespace Agario.GamePlay.Controller
{
    public class RemoteController : MonoBehaviour
    {
        [Header("Network")] 
        [SerializeField] private string ipAddress;
        [SerializeField] private int port;
        
        [Header("Dependencies")]
        [SerializeField] private Transform drone;
        [SerializeField] private IntValue stageSize;

        private Position targetPosition;

        private void Start() => targetPosition = RequestPosition();

        private Position RequestPosition()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            var client = new UdpClient();
            client.Connect(endPoint);

            var data = Encoding.ASCII.GetBytes(stageSize.Value.ToString());
            client.Send(data, data.Length);

            return new Position();
        }

    }
}
