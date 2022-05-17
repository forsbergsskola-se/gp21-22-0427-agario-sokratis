using Agario.Network;
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

        private Requester requester;
        private Vector3 target;

        private void Awake() => requester = new Requester(ipAddress, port);
        
        private void Start() => target = requester.ServerPosition(stageSize.Value);

    }
}
