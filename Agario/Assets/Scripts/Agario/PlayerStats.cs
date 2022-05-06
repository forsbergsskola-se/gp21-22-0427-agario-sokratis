using UnityEngine;

namespace Agario
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerStats", fileName = "NewPlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}
