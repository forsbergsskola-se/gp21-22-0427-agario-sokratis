using Agario.Interfaces;
using Agario.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Agario.GamePlay
{
    public class Score : MonoBehaviour, IPoints
    {
        [Header("Dependencies")]
        [SerializeField] private IntValue intPoints;
        
        public int Points 
        {
            get => intPoints.Value;
            set => intPoints.Value = value;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var otherPoints = col.gameObject.GetComponent<IPoints>().Points;
            
            if (Points > otherPoints) Points += otherPoints;
            else if(Points < otherPoints) Destroy(gameObject);
        }
    }
}

