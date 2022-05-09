using Agario.Interfaces;
using UnityEngine;

namespace Agario
{
    public class Scale : MonoBehaviour, IPoints
    {
        [SerializeField] private int startPoints = 2;
        [SerializeField] private float scaleRate = 0.05f;
        
        public int Points { get; set; }

        private void Awake() => Points = startPoints;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var otherPoints = col.gameObject.GetComponent<IPoints>();

            if (Points > otherPoints?.Points)
            {
                UpdatePoints(otherPoints);
                UpdateScale();
            }
            else Destroy(gameObject);
            
            Debug.Log(Points);
        }

        private void UpdatePoints(IPoints otherPoints) => Points += otherPoints.Points;
        
        private void UpdateScale() => transform.localScale += SetScaleMagnitude(Points, scaleRate);
        
        private Vector3 SetScaleMagnitude(int points, float sRate)
        {
            var scale = points * sRate;
            return new Vector3(scale, scale, 0);
        } 
        
    }
}
