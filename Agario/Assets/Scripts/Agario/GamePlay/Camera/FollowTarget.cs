using System;
using UnityEngine;
namespace Agario.GamePlay.Camera
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;

        private void Update()
        {
            transform.position = target.position + offset;
        }
    }
}
