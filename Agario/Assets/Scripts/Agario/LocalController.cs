using UnityEngine;

namespace Agario
{
    public class LocalController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private PlayerStats playerStats;
        [SerializeField] private Rigidbody2D localPlayer;

        [Header("Key Binding")] 
        [SerializeField] private char up;
        [SerializeField] private char down;
        [SerializeField] private char left;
        [SerializeField] private char right;

        private void FixedUpdate() => localPlayer.velocity = SetVelocity();
       
        private Vector2 SetVelocity() 
            => new (SetAxisOutput(right, left),
                    SetAxisOutput(up, down));
        
        private float SetAxisOutput(char positiveInput, char negativeInput)
        {
            if (Input.GetKey((KeyCode) positiveInput)) return playerStats.Speed;
            if (Input.GetKey((KeyCode) negativeInput)) return -playerStats.Speed;
            return 0;
        }
    }
}
