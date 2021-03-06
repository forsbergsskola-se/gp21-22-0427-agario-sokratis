using System;
using Agario.Network;
using Agario.ScriptableObjects;
using UnityEngine;

namespace Agario.GamePlay.Controller
{
    public class LocalController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private Rigidbody2D localPlayer;
        [SerializeField] private IntValue stageSize;

        [Header("Network")] 
        [SerializeField] private NetworkSetup nwSetup;
        
        [Header("Key Binding")] 
        [SerializeField] private char up;
        [SerializeField] private char down;
        [SerializeField] private char left;
        [SerializeField] private char right;

        private Requester requester;
        
        private void Awake() => requester = new Requester(nwSetup);

        private void Start() => localPlayer.transform.position = requester.ServerPosition(stageSize.Value);
        
        private void FixedUpdate()
        {
            localPlayer.velocity = SetVelocity();
            localPlayer.transform.position = ClampPosition(localPlayer.transform.position, stageSize.Value);
        }

        private Vector2 SetVelocity() => SetVelocityVector();
        
        private Vector2 SetVelocityVector() 
            => new (SetAxisOutput(right, left),
                    SetAxisOutput(up, down));
        
        private float SetAxisOutput(char positiveInput, char negativeInput)
        {
            if (Input.GetKey((KeyCode) positiveInput)) return playerStats.Speed;
            if (Input.GetKey((KeyCode) negativeInput)) return -playerStats.Speed;
            return 0;
        }

        private Vector3 ClampPosition(Vector3 position, int threshold)
            => new (Clamp(position.x, threshold), 
                    Clamp(position.y, threshold), 
                    0);
         
        private float Clamp(float value, int threshold) 
            => Mathf.Clamp(value, threshold * -1, threshold);
    }
}
