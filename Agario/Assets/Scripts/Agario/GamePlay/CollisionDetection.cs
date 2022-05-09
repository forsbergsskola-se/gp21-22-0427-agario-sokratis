using System;
using Agario.Events;
using UnityEngine;

namespace Agario.GamePlay
{
    public class CollisionDetection : GameEventListener
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            OnEventRaised();
        }
    }
}
