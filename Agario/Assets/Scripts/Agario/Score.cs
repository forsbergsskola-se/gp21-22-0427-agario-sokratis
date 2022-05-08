using Agario.Interfaces;
using UnityEngine;

namespace Agario
{
    public class Score : MonoBehaviour, IPoints
    {
        [SerializeField] private int startPoints = 2;
        
        public int Points { get; set; }

        private void Awake() => Points = startPoints;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var otherPoints = col.gameObject.GetComponent<IPoints>();
            
            if (otherPoints != null && Points > otherPoints.Points) Points += otherPoints.Points;
            else Destroy(gameObject);
            
            Debug.Log(Points);
        }

    }
}
