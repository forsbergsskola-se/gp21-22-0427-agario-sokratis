using UnityEngine;

namespace Agario
{
    public class Scale : MonoBehaviour
    {
        [SerializeField] private PlayerStats stats;
        public void SetScale(int points)
        {
            var scale = points * stats.ScaleRate;
            transform.localScale += new Vector3(scale, scale, 0);
        }
    }
}
