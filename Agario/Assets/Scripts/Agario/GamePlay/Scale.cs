using UnityEngine;

namespace Agario
{
    public class Scale : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        
        public void SetScale(int points) 
            => transform.localScale += new Vector3(SetScaleUnit(points), SetScaleUnit(points), 0);
        
        private float SetScaleUnit(int points) => points * stats.ScaleRate;
    }
}
