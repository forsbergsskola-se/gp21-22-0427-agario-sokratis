using Agario.Interfaces;
using Agario.Network;
using Agario.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Agario.GamePlay.Controller
{
    public class RemoteController : MonoBehaviour
    {
        [FormerlySerializedAs("setup")]
        [Header("Network")] 
        [SerializeField] private NetworkSetup nwSetup;
        

        [Header("Controller")] 
        [SerializeField] private float speed;
        [SerializeField] private float distance;
        
        [Header("Dependencies")]
        [SerializeField] private Transform drone;
        [SerializeField] private IntValue stageSize;

        private Requester requester;
        private Vector3 target;

        private void Awake() => requester = new Requester(nwSetup.IpAddress, nwSetup.Port);
        
        private void Start() => target = requester.ServerPosition(stageSize.Value);

        private void Update()
        {
            if (Vector3.Distance(drone.position, target) < distance)
                target = requester.ServerPosition(stageSize.Value);
            else 
                drone.position = Vector3.MoveTowards(drone.position, target, speed);
        }
    }
}
