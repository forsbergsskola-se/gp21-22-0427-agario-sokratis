using System.Collections.Generic;
using UnityEngine;

namespace Agario.Events
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Values/GameEvent", fileName = "NewEvent")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            foreach (var gameEventListener in listeners)
            {
                gameEventListener.OnEventRaised();
            }
        }

        public void Register(GameEventListener listener) => listeners.Add(listener);
        
        public void Unregister(GameEventListener listener) => listeners.Remove(listener);
    }
}