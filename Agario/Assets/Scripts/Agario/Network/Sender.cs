using System;
using System.Collections;
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
        [SerializeField] private float waitTime;
        
        [Header("Data to send")]
        [SerializeField] private Transform localPlayer;
        [SerializeField] private IntValue localScore;

        private void Start() => StartCoroutine(ConnectToServer());
        
        private IEnumerator ConnectToServer()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            var client = new UdpClient();
            client.Connect(endPoint);

            var data = Encoding.ASCII.GetBytes($"{Time.time}");
            client.Send(data, data.Length);
            Debug.Log("Message sent: " + Encoding.ASCII.GetString(data));
            
            yield return new WaitForSeconds(waitTime);
            StartCoroutine(ConnectToServer());
        }        
    }
}
