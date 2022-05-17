using Agario.Interfaces;
using UnityEngine;

namespace Agario.ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObjects/NetworkSetup", fileName = "NewNetworkSetup")]
    public class NetworkSetup : ScriptableObject, INetworkSetup
    {
        [SerializeField] private string ipAddress;
        [SerializeField] private int port;
        
        public string IpAddress { get => ipAddress; }
        public int Port { get => port; }
    }
}
