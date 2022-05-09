using Agario.Interfaces;
using UnityEngine;

namespace Agario
{
    public class Scale : MonoBehaviour, IPoints
    {
        [SerializeField] private int startPoints = 2;
        [SerializeField] private float scaleRate = 0.1f;
        
        public int Points { get; set; }

        private void Awake() => Points = startPoints;

        private void OnCollisionEnter2D(Collision2D col)
        {
            var otherPoints = col.gameObject.GetComponent<IPoints>();

            if (otherPoints != null && Points > otherPoints.Points)
            {
                Points += otherPoints.Points;
                var scale = otherPoints.Points * scaleRate;
                transform.localScale += new Vector3(scaleRate , scaleRate , 0);
            }
            else Destroy(gameObject);
            
            Debug.Log(Points);
        }

    }
}
