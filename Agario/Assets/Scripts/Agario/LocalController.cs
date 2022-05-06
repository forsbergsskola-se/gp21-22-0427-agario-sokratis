using System;
using UnityEngine;

namespace Agario
{
    public class LocalController : MonoBehaviour
    {
        [Header("Dependencies")]
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private Rigidbody2D _localPlayer;

        [Header("Inputs")] 
        [SerializeField] private char _up;
        [SerializeField] private char _down;
        [SerializeField] private char _left;
        [SerializeField] private char _right;

        private Vector2 _velocity;
        
        private void FixedUpdate()
        {
            if (Input.GetKey((KeyCode) _up)) _velocity.y = _playerStats.Speed;
            else if (Input.GetKey((KeyCode) _down)) _velocity.y = -_playerStats.Speed;
            else _velocity.y = 0;
            
            if (Input.GetKey((KeyCode) _left)) _velocity.x = -_playerStats.Speed;
            else if (Input.GetKey((KeyCode) _right)) _velocity.x = _playerStats.Speed;
            else _velocity.x = 0;

            _localPlayer.velocity = _velocity;
        }
    }
}
