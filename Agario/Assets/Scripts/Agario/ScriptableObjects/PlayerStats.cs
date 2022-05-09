using UnityEngine;

namespace Agario
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats", fileName = "NewPlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}
