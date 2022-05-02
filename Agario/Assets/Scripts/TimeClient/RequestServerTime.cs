using System.Net;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace TimeClient
{
    public class RequestServerTime : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        
        public void SendRequest()
        {
            var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 44444);
            var clientEndPoint = new IPEndPoint(IPAddress.Loopback, 44445);
            var tcpClient = new TcpClient(clientEndPoint);
            var buffer = new byte[100];
            
            tcpClient.Connect(serverEndPoint);
            tcpClient.GetStream().Read(buffer, 0, buffer.Length);
            textMeshPro.text = Encoding.ASCII.GetString(buffer);
            tcpClient.Close();
        }
    }
}
