using UnityEngine;

namespace Agario.GamePlay
{
    public class PlayerScore : Score
    {
        [SerializeField] private PlayerStats stats;
        
        private void Awake() => Points = stats.StartPoints;
    }
}
